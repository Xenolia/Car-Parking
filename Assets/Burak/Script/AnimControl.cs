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

    private Transform currentTarget; 
    private float golfTimer;
    private bool isWaitingForRunStart;

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


            // Immediately mark as NOT Idle so we don't transition back early
            animator.SetBool("Idle", false);

            if (isRunning)
            {
                Debug.Log("SetRun(true) called");
                animator.SetTrigger("Run");
                ResetGolfTimer();
                isWaitingForRunStart = true;
                // Movement will be started by Animation Event "StartRunMovement"
            }
            else
            {
                Debug.Log("SetRun(false) called");
                // Stop waiting for Run Start (so we don't move forward if the event fires later)
                if (isWaitingForRunStart)
                {
                    Debug.Log("Run Cancelled (Movement prevented), but playing RunBack.");
                    isWaitingForRunStart = false;
                }

                animator.SetTrigger("RunBack");
                // Movement will be started by Animation Event "StartRunBackMovement"
            } 
        }
    }

    /// <summary>
    /// Call this via Animation Event at the frame where the character starts running.
    /// </summary>
    public void StartRunMovement()
    {
        Debug.Log("Event: StartRunMovement fired");

        // FIX: If we cancelled the run early (isWaitingForRunStart is false), ignore this event!
        if (!isWaitingForRunStart)
        {
             Debug.Log("Event Ignored: Run was cancelled.");
             return;
        }

        isWaitingForRunStart = false; 
        currentTarget = runTarget;
        if (animator != null) animator.SetBool("Idle", false);
    }
    
    /// <summary>
    /// Call this via Animation Event at the frame where the character starts running back.
    /// </summary>
    public void StartRunBackMovement()
    {
        Debug.Log("Event: StartRunBackMovement fired");
        currentTarget = startTarget;
        if (animator != null) animator.SetBool("Idle", false);
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
