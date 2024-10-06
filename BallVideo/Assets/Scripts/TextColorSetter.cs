using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorSetter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    [SerializeField]
    private Color textColor;

    private void Start()
    {
        if (myTMP == null)
        {
            myTMP = GetComponent<TextMeshProUGUI>();
        }

        myTMP.color = textColor;
    }
}
