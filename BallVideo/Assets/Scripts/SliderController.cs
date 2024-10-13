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
        fill.color = GameManager.instance.gameModeSettings.sliderFillColor;
    }

    private void UpdateSliderValue(float Value)
    {
        slider.value = Value;
    }
}
