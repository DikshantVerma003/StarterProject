using UnityEngine;

public class HoverAndGrab : MonoBehaviour
{
    [Header("Materials")]
    public Material originalMaterial;
    public Material hoverMaterial;
    public Material grabMaterial;

    private Renderer objectRenderer;
    private bool isHovered = false;
    private bool isGrabbed = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
        else
        {
            Debug.LogWarning("Please assign the Original Material and ensure the Renderer exists.");
        }
    }

    public void OnHoverEnter()
    {
        if (!isGrabbed && hoverMaterial != null)
        {
            objectRenderer.material = hoverMaterial;
            isHovered = true;
        }
    }

    public void OnHoverExit()
    {
        if (!isGrabbed && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
            isHovered = false;
        }
    }

    public void OnGrab()
    {
        if (grabMaterial != null)
        {
            objectRenderer.material = grabMaterial;
            isGrabbed = true;
        }
    }

    public void OnRelease()
    {
        if (isHovered && hoverMaterial != null)
        {
            objectRenderer.material = hoverMaterial;
        }
        else if (originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
        isGrabbed = false;
    }
}
