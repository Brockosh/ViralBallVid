using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image fill;

    private void Start()
    {
        if (slider != null) 
        {
            slider = GetComponent<Slider>();
        }

        GameManager.instance.progressManager.onProgressUpdated += UpdateSliderValue;
        GameManager.instance.progressManager.onUpdateProgressColor += UpdateFillColor;
    }

    private void UpdateSliderValue(float Value)
    {
        slider.value = Value;
    }

    private void UpdateFillColor(Color color)
    {
        fill.color = color;
    }
}
