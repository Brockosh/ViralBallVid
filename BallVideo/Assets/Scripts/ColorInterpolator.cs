using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInterpolator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public List<Color> pastelColors;      
    public float transitionTime = 2f;     
    private int currentColorIndex = 0;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(InterpolateColors());
    }

    private IEnumerator InterpolateColors()
    {
        while (true)
        {
            Color startColor = pastelColors[currentColorIndex];
            Color endColor = pastelColors[(currentColorIndex + 1) % pastelColors.Count];
            float elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                spriteRenderer.color = Color.Lerp(startColor, endColor, elapsedTime / transitionTime);
                elapsedTime += Time.deltaTime;
                yield return null; 
            }

            spriteRenderer.color = endColor;

            currentColorIndex = (currentColorIndex + 1) % pastelColors.Count;

            yield return new WaitForSeconds(1f); 
        }
    }
}