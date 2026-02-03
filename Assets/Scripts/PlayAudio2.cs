using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio2 : MonoBehaviour
{
    public float fadeTimeInSeconds;
    public AudioMixerSnapshot unmutedSnapshot;
    public AudioMixerSnapshot mutedSnapshot;

    private AudioSource audio;
    private AudioMixer mixer;


    private void Start()
    {
        {
            audio = GetComponent<AudioSource>();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();

        }
    }
}
