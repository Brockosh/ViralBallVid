using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public event Action onCollisionOccurred;


    public void CallOnCollisionOccurred()
    {
        onCollisionOccurred?.Invoke();
    }
}
