using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("XR Origin")]
    public Transform xrOrigin; // Drag XR Origin here

    [Header("Trigger Zones")]
    public GameObject[] triggerZones;

    [Header("Teleport Zones")]
    public GameObject[] teleportZones;

    [Header("Congrats UI")]
    public GameObject congratsUI;

    private int currentTriggerIndex = 0;
    private int currentTeleportIndex = 0;

    void Start()
    {
        for (int i = 0; i < triggerZones.Length; i++)
            triggerZones[i].SetActive(i == 0);

        foreach (GameObject tp in teleportZones)
            tp.SetActive(false);

        congratsUI.SetActive(false);
    }

    public void TriggerCleared()
    {
        triggerZones[currentTriggerIndex].SetActive(false);
        currentTriggerIndex++;

        if (currentTriggerIndex < triggerZones.Length)
        {
            triggerZones[currentTriggerIndex].SetActive(true);
        }
        else
        {
            teleportZones[0].SetActive(true);
        }
    }

    public void TeleportCleared()
    {
        teleportZones[currentTeleportIndex].SetActive(false);
        currentTeleportIndex++;

        if (currentTeleportIndex < teleportZones.Length)
        {
            teleportZones[currentTeleportIndex].SetActive(true);
        }
        else
        {
            ShowCongrats();
        }
    }

    void ShowCongrats()
    {
        congratsUI.SetActive(true);

        // Spawn in front of player
        Vector3 forwardPos = xrOrigin.position + xrOrigin.forward * 2f;
        congratsUI.transform.position = forwardPos;

        // Face player
        congratsUI.transform.LookAt(xrOrigin);
        congratsUI.transform.Rotate(0, 180, 0);
    }
}