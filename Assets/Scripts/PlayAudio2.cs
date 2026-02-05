using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio2 : MonoBehaviour
{
    public float fadeTime;
    public AudioMixerSnapshot unmutedSnapshot;
    public AudioMixerSnapshot mutedSnapshot;

    private AudioSource audio;
    private AudioMixer mixer;
    private float[] weights;
    private AudioMixerSnapshot[] snapshots;

    private void Start()
    {
        {
            audio = GetComponent<AudioSource>();
            mixer = audio.outputAudioMixerGroup.audioMixer;

            snapshots = new AudioMixerSnapshot[]
            {
                unmutedSnapshot,
                mutedSnapshot
            };

            weights = new float[2];
            //makes an array of size 2
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            weights[0] = 1;
            weights[1] = 0;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            weights[0] = 0;
            weights[1] = 1;
            mixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
    }
}
