using UnityEngine;

public class ControllerInteraction : MonoBehaviour
{
    public Transform rayOrigin; // Assign the controller's position
    public float rayDistance = 10f;

    private HoverAndGrab currentObject;

    void Update()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            HoverAndGrab hoverScript = hit.collider.GetComponent<HoverAndGrab>();

            if (hoverScript != null)
            {
                if (currentObject != hoverScript)
                {
                    if (currentObject != null)
                    {
                        currentObject.OnHoverExit();
                    }

                    currentObject = hoverScript;
                    currentObject.OnHoverEnter();
                }

                // Implement grab logic (e.g., based on controller input)
                if (Input.GetButtonDown("Grab"))
                {
                    currentObject.OnGrab();
                }
                else if (Input.GetButtonUp("Grab"))
                {
                    currentObject.OnRelease();
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
