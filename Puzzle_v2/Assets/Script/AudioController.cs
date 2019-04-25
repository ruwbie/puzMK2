using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] bgm_;
    AudioSource audiosource_;

    // Start is called before the first frame update
    void Start()
    {
        audiosource_ = GetComponent<AudioSource>();
        StartCoroutine("Playlist");
    }

    IEnumerator Playlist()
    {
        audiosource_.clip = bgm_[0];
        audiosource_.Play();
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            if(audiosource_.isPlaying == false)
            {
                audiosource_.clip = bgm_[1];
                audiosource_.Play();
                audiosource_.loop = true;
            }
        }
    }
}
