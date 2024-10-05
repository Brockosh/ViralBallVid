using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public bool hasEscaped = false;
    [SerializeField] private float timeBeforeDestroy = 3f;

    public void StartEscapedProcess()
    {
        StartCoroutine(RunEscapedProcess());
    }

    public IEnumerator RunEscapedProcess()
    {
        hasEscaped = true;
        GameManager.instance.CallOnBallEscaped();
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}
