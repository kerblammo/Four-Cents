using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundboardSnippet : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;

    public void PlaySound()
    {
        int index = Random.Range(0, clips.Count);
        AudioClip clip = clips[index];
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
