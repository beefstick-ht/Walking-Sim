using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//if using this script and no audiosource is applied, unity will add one

public class PlayAudio : MonoBehaviour
{
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
            audio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Pause();
        }
    }
}
