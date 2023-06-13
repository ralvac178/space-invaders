using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackGroundSong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    public void ChangeSound()
    {
        StartCoroutine(Waiting());
        audioSource.clip = clip;
        audioSource.Play();
    }

    public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5);
        StopAllCoroutines();
    }
}
