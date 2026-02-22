using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public Transform teleportDestination;
    public TutorialManager tutorialManager;

    private void OnTriggerEnter(Collider other)
    {
        var xrOrigin = other.GetComponentInParent<Unity.XR.CoreUtils.XROrigin>();

        if (xrOrigin != null)
        {
            xrOrigin.transform.position = teleportDestination.position;
            tutorialManager.TeleportCleared();
        }
    }
}