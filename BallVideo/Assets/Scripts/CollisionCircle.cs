using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCircle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;


    private void Start()
    {
        
    }

    private void Update()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
