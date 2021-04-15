using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip booSound, cheerSound, scoreSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In the soundManager");
        booSound = Resources.Load<AudioClip>("boo");
        cheerSound = Resources.Load<AudioClip>("cheer");
        scoreSound = Resources.Load<AudioClip>("score");
        audioSrc = GetComponent<AudioSource>();
        
        //audioSrc.clip = booSound;
        //audioSrc.Play();
        //audioSrc.PlayOneShot(booSound);

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "boo":
                audioSrc.PlayOneShot(booSound);
                break;
            case "cheer":
                audioSrc.PlayOneShot(cheerSound);
                break;
            case "score":
                //Debug.Log("Score sound is playing");
                audioSrc.PlayOneShot(scoreSound);
                break;
        }
    }
}
