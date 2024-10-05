using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public bool hasEscaped = false;
    [SerializeField] private float timeBeforeDestroy = 0.2f;

    public void StartEscapedProcess()
    {
        StartCoroutine(RunEscapedProcess());
    }

    public IEnumerator RunEscapedProcess()
    {
        hasEscaped = true;
        yield return new WaitForSeconds(timeBeforeDestroy);
        GameManager.instance.CallOnBallEscaped();
        Destroy(gameObject);
    }
}
