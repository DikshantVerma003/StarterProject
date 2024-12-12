using UnityEngine;
using UnityEngine.UI;

public class HoverAndGrab : MonoBehaviour
{
    [Header("Materials")]
    public Material originalMaterial; // Idle material
    public Material hoverMaterial;    // Hover material
    public Material grabMaterial;     // Grab material

    [Header("UI Indicator")]
    public GameObject grabIndicator; // Assign the UI element in the Inspector

    private Renderer objectRenderer;
    private bool isGrabbed = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }

        if (grabIndicator != null)
        {
            grabIndicator.SetActive(false); // Ensure the indicator starts hidden
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

                // Show the grab indicator
                if (grabIndicator != null)
                {
                    grabIndicator.SetActive(true);
                }
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

                // Hide the grab indicator
                if (grabIndicator != null)
                {
                    grabIndicator.SetActive(false);
                }
            }
        }
    }
}
