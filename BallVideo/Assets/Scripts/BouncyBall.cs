using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    [SerializeField] private float timeBeforeDestroy = 3f;
    [SerializeField] private Rigidbody2D rb;
    private float maxVelocity = 10;
    public bool hasEscaped = false;

    private void Start()
    {
        if (rb != null)
            rb = GetComponent<Rigidbody2D>();
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.collisionManager.CallOnCollisionOccurred();
    }
}
