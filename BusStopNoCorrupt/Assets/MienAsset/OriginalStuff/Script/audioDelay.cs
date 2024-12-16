using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 45f;
    private Coroutine loopCoroutine;

    private void OnEnable()
    {
        loopCoroutine = StartCoroutine(audioWithDelay());
    }

    private void OnDisable()
    {
        if (loopCoroutine != null)
        {
            StopCoroutine(loopCoroutine);
        }
    }

    private IEnumerator audioWithDelay(){
        while (true){
            yield return new WaitForSeconds(delay);
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }
}
