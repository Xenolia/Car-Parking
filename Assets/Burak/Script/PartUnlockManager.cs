using UnityEngine;
using TMPro;

public class PartUnlockManager : MonoBehaviour
{
    public static PartUnlockManager instance;

    [Header("UI References")]
    [Tooltip("Assign the Light GameObjects corresponding to Part 1, Part 2, Part 3")]
    [SerializeField] private GameObject[] partLights;
    [SerializeField] private TextMeshProUGUI collectedText;

    private const string PartPrefPrefix = "PartUnlocked_";

    private void Awake()
    {
        instance = this;
        LoadPartStates();
    }

    /// <summary>
    /// Loads the saved state for all parts and updates the lights.
    /// </summary>
    public void LoadPartStates()
    {
        for (int i = 0; i < partLights.Length; i++)
        {
            if (partLights[i] == null) continue;

            bool isUnlocked = IsPartUnlocked(i);
            partLights[i].SetActive(isUnlocked);
        }
        UpdateCollectedText();
    }

    private void UpdateCollectedText()
    {
        if (collectedText == null) return;

        int count = 0;
        for (int i = 0; i < partLights.Length; i++)
        {
            if (IsPartUnlocked(i)) count++;
        }
        collectedText.text = $"Parts Collected {count}/{partLights.Length}";

        if (count == partLights.Length)
        {
            OnAllPartsCollected();
        }
    }

    private void OnAllPartsCollected()
    {
       
        FindObjectOfType<MenuController>().UnlockWithParts();
    }

    /// <summary>
    /// Unlocks a specific part index (0-based), saves it, and turns on the light.
    /// </summary>
    /// <param name="index">Index of the part (0, 1, or 2)</param>
    public void UnlockPart(int index)
    {
        if (index < 0 || index >= partLights.Length)
        {
            Debug.LogWarning($"Invalid Part Index: {index}");
            return;
        }

        PlayerPrefs.SetInt(PartPrefPrefix + index, 1);
        PlayerPrefs.Save(); // Force save to disk

        // Update visual immediately
        if (partLights[index] != null)
        {
            partLights[index].SetActive(true);
        }
        UpdateCollectedText();

        Debug.Log($"Part {index} Unlocked!");
    }

    /// <summary>
    /// Checks if a part is already unlocked.
    /// </summary>
    public bool IsPartUnlocked(int index)
    {
        return PlayerPrefs.GetInt(PartPrefPrefix + index, 0) == 1;
    }

    /// <summary>
    /// Editor helper to reset progress
    /// </summary>
    [ContextMenu("Reset All Parts")]
    public void ResetParts()
    {
        for (int i = 0; i < partLights.Length; i++)
        {
            PlayerPrefs.DeleteKey(PartPrefPrefix + i);
            if (partLights[i] != null)
                partLights[i].SetActive(false);
        }
        UpdateCollectedText();
        Debug.Log("All parts reset.");
    }
}
