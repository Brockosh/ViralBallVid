using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> ballCollisionSounds;
    private bool isSubscribed = false;

    private void Start()
    {
        GameManager.instance.collisionManager.onCollisionOccurred += PlayRandomSound;
        GameManager.instance.ballManager.onBallCountChanged += CheckForUnsubscribe;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartRepeatSoundsCorouotine();
        }
    }

    private void PlayRandomSound()
    {
        AudioSource.PlayClipAtPoint(ballCollisionSounds[Random.Range(0, ballCollisionSounds.Count)], Vector3.zero);
    }

    private void StartRepeatSoundsCorouotine()
    {
        StartCoroutine(PlayRandomSoundsOnRepeat());
    }

    private IEnumerator PlayRandomSoundsOnRepeat()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            PlayRandomSound();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void CheckForUnsubscribe(int ballCount)
    {
        if (!isSubscribed)
        {
            if (ballCount > 9) 
            {
                isSubscribed = true;
                GameManager.instance.collisionManager.onCollisionOccurred -= PlayRandomSound;
                StartRepeatSoundsCorouotine();
            }
        }
    }
}
