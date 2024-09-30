using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BouncyBall>())
        {
            if (collision.GetComponent<BouncyBall>().hasEscaped != true)
            {
                collision.GetComponent<BouncyBall>().RunEscapedProcess();
                Debug.Log("Collision");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        if (collision.gameObject.GetComponent<BouncyBall>())
        {
            if (collision.gameObject.GetComponent<BouncyBall>().hasEscaped != true)
            {
                collision.gameObject.GetComponent<BouncyBall>().StartEscapedProcess();
                Debug.Log("Collision");
            }
        }
    }
}
