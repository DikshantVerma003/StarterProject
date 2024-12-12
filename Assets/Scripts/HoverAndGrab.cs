using UnityEngine;

public class HoverAndGrab : MonoBehaviour
{
    [Header("Materials")]
    public Material originalMaterial; // Idle material
    public Material hoverMaterial;    // Hover material
    public Material grabMaterial;     // Grab material

    private Renderer objectRenderer;
    private bool isGrabbed = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }

    public void OnHoverEnter()
    {
        if (!isGrabbed && hoverMaterial != null)
        {
            objectRenderer.material = hoverMaterial;
        }
    }

    public void OnHoverExit()
    {
        if (!isGrabbed && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detect if the collider belongs to a controller
        if (other.CompareTag("Controller"))
        {
            Debug.Log("Object grabbed via collision!");
            if (grabMaterial != null)
            {
                objectRenderer.material = grabMaterial;
                isGrabbed = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Detect if the collider belongs to a controller
        if (other.CompareTag("Controller"))
        {
            Debug.Log("Object released via collision!");
            if (originalMaterial != null)
            {
                objectRenderer.material = originalMaterial;
                isGrabbed = false;
            }
        }
    }
}
