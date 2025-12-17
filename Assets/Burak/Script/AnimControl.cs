using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimControl : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Assign the Decor Character's Animator")]
    [SerializeField] private Animator animator;
    [Tooltip("Assign the Race Button from the UI")]
    [SerializeField] private GameObject raceButton;
    
    [Header("Timing")]
    [Tooltip("Minimum time between Golf triggers")]
    [SerializeField] private float minGolfTime = 12f;
    [Tooltip("Maximum time between Golf triggers")]
    [SerializeField] private float maxGolfTime = 18f;

    [Header("Teleport Targets")]
    [Tooltip("Target position to snap to when Run ends")]
    [SerializeField] private Transform runTarget;
    [Tooltip("Target position to snap to when RunBack ends")]
    [SerializeField] private Transform startTarget;
    [Tooltip("Movement speed")]
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Delay before running starts")]
    [SerializeField] private float delayTime = 0.5f;

    private Transform currentTarget;
    private Coroutine moveCoroutine;
    private float golfTimer;
    private bool isInRunDelay;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        ResetGolfTimer();
        SetupButtonEvents();
    }

    private void Update()
    {
        HandleGolfTimer();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (currentTarget != null)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
            
            // Check if reached destination (very close)
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
            {
                 // We have arrived
                 transform.position = currentTarget.position; // Snap exactly
                 currentTarget = null; // Stop moving
                 if (animator != null) animator.SetBool("Idle", true);
            }
        }
    }

    private void HandleGolfTimer()
    {
        if (animator == null) return;

        golfTimer -= Time.deltaTime;
        if (golfTimer <= 0)
        {
            // Trigger the "Golf" animation parameter
            animator.SetTrigger("Golf");
            ResetGolfTimer();
        }
    }

    private void ResetGolfTimer()
    {
        golfTimer = Random.Range(minGolfTime, maxGolfTime);
    }

    /// <summary>
    /// Called automatically when the Race Button is highlighted (Pointer Enter)
    /// </summary>
    public void SetRun(bool isRunning)
    {
        if (animator != null)
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);

            // Immediately mark as NOT Idle so we don't transition back early
            animator.SetBool("Idle", false);

            if (isRunning)
            {
                animator.SetTrigger("Run");
                ResetGolfTimer();
                isInRunDelay = true;
                moveCoroutine = StartCoroutine(StartMoveDelay(runTarget));
            }
            else
            {
                // If we cancel before the Run actually started moving...
                if (isInRunDelay)
                {
                    if (moveCoroutine != null) StopCoroutine(moveCoroutine);
                    isInRunDelay = false;
                    
                    animator.ResetTrigger("Run");
                    animator.SetBool("Idle", true);
                    return; // Skip RunBack
                }

                animator.SetTrigger("RunBack");
                moveCoroutine = StartCoroutine(StartMoveDelay(startTarget));
            } 
        }
    }

    private System.Collections.IEnumerator StartMoveDelay(Transform target)
    {
        yield return new WaitForSeconds(delayTime);
        isInRunDelay = false; // Delay finished
        currentTarget = target;
    }

    /// <summary>
    /// Adds EventTrigger listeners to the Race Button at runtime
    /// so the user doesn't have to manually configure events.
    /// </summary>
    private void SetupButtonEvents()
    {
        if (raceButton == null)
        {
            Debug.LogWarning("AnimControl: Race Button is not assigned!");
            return;
        }

        // Get or Add EventTrigger component to the button
        EventTrigger trigger = raceButton.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = raceButton.AddComponent<EventTrigger>();
        }

        // Add PointerEnter (Hover Start)
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((data) => { SetRun(true); });
        trigger.triggers.Add(entryEnter);

        // Add PointerExit (Hover End)
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => { SetRun(false); });
        trigger.triggers.Add(entryExit);
    }
}
