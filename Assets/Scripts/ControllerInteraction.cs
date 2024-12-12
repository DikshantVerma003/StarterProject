using UnityEngine;

public class ControllerInteraction : MonoBehaviour
{
    public Transform rayOrigin;       // Reference to the controller's tip
    public float rayDistance = 10f;   // Ray distance

    private HoverAndGrab currentObject;

    void Update()
    {
        // Visualize the ray in the Scene View for debugging
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * rayDistance, Color.green);

        // Shoot the ray
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            HoverAndGrab hoverScript = hit.collider.GetComponent<HoverAndGrab>();

            if (hoverScript != null)
            {
                // Handle hover enter
                if (currentObject != hoverScript)
                {
                    if (currentObject != null)
                    {
                        currentObject.OnHoverExit();
                    }

                    currentObject = hoverScript;
                    currentObject.OnHoverEnter();
                }
            }
        }
        else if (currentObject != null)
        {
            currentObject.OnHoverExit();
            currentObject = null;
        }
    }
}
