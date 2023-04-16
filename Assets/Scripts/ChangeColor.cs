using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float changeInterval = 1f; // The time interval between color changes

    private Renderer objectRenderer; // The object's renderer component
    private Color currentColor; // The current color of the object

    private void Start()
    {
        // Get the object's renderer component
        objectRenderer = GetComponent<Renderer>();

        // Set the current color to the initial material color
        currentColor = objectRenderer.material.color;

        // Start the color changing coroutine
        StartCoroutine(ChangingColor());
    }

    private IEnumerator ChangingColor()
    {
        while (true)
        {
            // Generate a random color
            Color newColor = new Color(Random.value, Random.value, Random.value);

            // Lerp the color over the change interval
            for (float t = 0; t < changeInterval; t += Time.deltaTime)
            {
                objectRenderer.material.color = Color.Lerp(currentColor, newColor, t / changeInterval);
                yield return null;
            }

            // Set the current color to the new color
            currentColor = newColor;
        }
    }
}
