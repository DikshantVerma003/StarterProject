using Meta.XR.MRUtilityKit;
using UnityEngine;
using static Meta.XR.MRUtilityKit.MRUK;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Animator monstrAnimator;
    [SerializeField] private Rigidbody monstorRigidbody;
    [SerializeField] private GameObject onDeadParticleEffect;
    [SerializeField] private GameObject actionFigure; // Assign in Inspector

    public bool isGrabbed = false;

    public void ReleaseMonstor()
    {
        monstrAnimator.enabled = true;
        monstorRigidbody.isKinematic = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == actionFigure)
        {
            ActionFigureHealth figureHealth = actionFigure.GetComponent<ActionFigureHealth>();
            if (figureHealth != null)
            {
                figureHealth.TakeDamage(10); // Enemy deals 10 damage
            }
        }
    }


    public void OnMonstorGrabbed()
    {
        isGrabbed = true;
        monstorRigidbody.isKinematic = true;
    }

    public void OnMonstorReleased()
    {
        isGrabbed = false;
        monstorRigidbody.isKinematic = false;
    }


}
