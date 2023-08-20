using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioClip[] sfxClip;
    // Start is called before the first frame update
    void Start()
    {
        if (!bgmSource)
        {
            return;
        }
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmSource.Play();
    }

    public void PlaySFX(Vector3 position, int indexAudio)
    {
        AudioSource.PlayClipAtPoint(sfxClip[indexAudio], position);
    }
}
