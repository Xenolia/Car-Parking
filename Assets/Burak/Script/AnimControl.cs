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

    private float golfTimer;

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
            if (isRunning)
            {
                animator.SetTrigger("Run");
            }
            else
            {
                // Trigger RunBack when mouse leaves
                animator.SetTrigger("RunBack"); 
            }
        }
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
