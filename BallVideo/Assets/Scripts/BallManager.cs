using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject referenceObject;
    [SerializeField] private int newSpawnAmount = 2;
    [SerializeField] private Transform spawnRegion;
    

    private void Start()
    {
        GameManager.instance.onBallEscaped += SpawnBall;
    }

    private void SpawnBall()
    {
        for (int i = 0; i < newSpawnAmount; i++) 
        {
            Instantiate(referenceObject, Random.insideUnitCircle, Quaternion.identity);
        }

    }


}
