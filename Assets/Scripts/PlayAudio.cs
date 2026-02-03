using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//if using this script and no audiosource is applied, unity will add one

public class PlayAudio : MonoBehaviour
{
    public float fadeTimeInSeconds;

    private AudioSource audio;

    private void Start()
    {
        {
            audio = GetComponent<AudioSource>();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeAudio(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(FadeAudio(true));
        }
    }

    private IEnumerator FadeAudio(bool fadeIn)
    {
        float timer = 0;
        //if fadein is true, set to 0, else set to 1
        float start = fadeIn ? 0 : audio.volume;
        //if fadeIn is true, set to 1, else set to 0
        float end = fadeIn ? 1 : 0;
        //? = true/false true : false

        if (fadeIn) audio.Play();
        while (timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(start, end, timer/fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null; //waits 1 frame; WaitForSeconds(x) is a cooldown
        }

        audio.volume = end;
        if (!fadeIn) audio.Pause();
    }

}
