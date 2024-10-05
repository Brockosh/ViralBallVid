using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image fillColour;

    private void Start()
    {
        if (slider != null) 
        {
            slider = GetComponent<Slider>();
        }

        GameManager.instance.progressManager.onProgressUpdated += UpdateSliderValue;
        fillColour.color = Color.green;
    }

    private void UpdateSliderValue(float Value)
    {
        slider.value = Value;
    }
}
