using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInterpolator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    private Color[] coloursToInterpolate;      
    public float transitionTime = 2f;     
    private int currentColorIndex = 0;

    void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        coloursToInterpolate = GameManager.instance.gameModeSettings.coloursToUse;
        StartCoroutine(InterpolateColors());
}

    private IEnumerator InterpolateColors()
    {
        while (true)
        {
            Color startColor = coloursToInterpolate[currentColorIndex];
            Color endColor = coloursToInterpolate[(currentColorIndex + 1) % coloursToInterpolate.Length];
            float elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                spriteRenderer.color = Color.Lerp(startColor, endColor, elapsedTime / transitionTime);
                elapsedTime += Time.deltaTime;
                yield return null; 
            }

            spriteRenderer.color = endColor;

            currentColorIndex = (currentColorIndex + 1) % coloursToInterpolate.Length;

            yield return new WaitForSeconds(1f); 
        }
    }
}