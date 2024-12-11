using UnityEngine;

public class ControllerRaycast : MonoBehaviour
{
    public Transform controllerTransform; // Assign the controller Transform in the Inspector
    public float rayDistance = 10f;       // Maximum raycast distance
    public LayerMask interactableLayer;   // Layer for objects that can interact

    private GameObject lastHoveredObject = null; // To track the last object hit by the ray

    void Update()
    {
        // Cast a ray from the controller's position and orientation
        Ray ray = new Ray(controllerTransform.position, controllerTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != lastHoveredObject)
            {
                // Reset the last hovered object's color
                if (lastHoveredObject != null)
                {
                    lastHoveredObject.GetComponent<ColorChangeOnHover>()?.ResetColor();
                }

                // Change the color of the newly hit object
                hitObject.GetComponent<ColorChangeOnHover>()?.ChangeColor(Color.green);

                // Update the last hovered object
                lastHoveredObject = hitObject;
            }
        }
        else
        {
            // Reset the last hovered object's color if the ray hits nothing
            if (lastHoveredObject != null)
            {
                lastHoveredObject.GetComponent<ColorChangeOnHover>()?.ResetColor();
                lastHoveredObject = null;
            }
        }

        // Optional: Visualize the ray in the Scene view
        Debug.DrawRay(controllerTransform.position, controllerTransform.forward * rayDistance, Color.red);
    }
}
