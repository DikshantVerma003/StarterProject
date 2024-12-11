using UnityEngine;

public class ColorChangeOnHover : MonoBehaviour
{
    private Color originalColor; // Store the original color
    private Material objectMaterial;

    void Start()
    {
        // Get the object's material and save its original color
        objectMaterial = GetComponent<Renderer>().material;
        originalColor = objectMaterial.color;
    }

    public void ChangeColor(Color newColor)
    {
        // Change the color of the material
        objectMaterial.color = newColor;
    }

    public void ResetColor()
    {
        // Reset the material color to the original
        objectMaterial.color = originalColor;
    }
}
