using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCountText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myTMP;
    void Start()
    {
        if (myTMP == null)
            myTMP = GetComponent<TextMeshProUGUI>();
        GameManager.instance.ballManager.onBallCountChanged += UpdateHUD;
    }

    private void UpdateHUD(int ballCount)
    {
        myTMP.text = ballCount.ToString();
    }
}
