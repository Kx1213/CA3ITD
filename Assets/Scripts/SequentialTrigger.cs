using UnityEngine;

public class SequentialTrigger : MonoBehaviour
{
    public TutorialManager tutorialManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Unity.XR.CoreUtils.XROrigin>())
        {
            tutorialManager.TriggerCleared();
        }
    }
}