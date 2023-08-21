using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip rollingSound, jumpingSound, loseSound, winSound, takeKeySound, doorOpenSound;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        rollingSound = Resources.Load<AudioClip>("roll");
        jumpingSound = Resources.Load<AudioClip>("jump");
        //loseSound = Resources.Load<AudioClip>("lose");
        //winSound = Resources.Load<AudioClip>("win");
        takeKeySound = Resources.Load<AudioClip>("takeKey");
        doorOpenSound = Resources.Load<AudioClip>("doorOpen");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            
            case "rolling":
                audioSrc.PlayOneShot(rollingSound);
                break;
            case "jumping":
                audioSrc.PlayOneShot(jumpingSound);
                break;
            // case "lose":
            //     audioSrc.PlayOneShot(loseSound);
            //     break;
            // case "win":
            //     audioSrc.PlayOneShot(winSound);
            //     break;
            case "takeKey":
                audioSrc.PlayOneShot(takeKeySound);
                break;
            case "doorOpen":
                audioSrc.PlayOneShot(doorOpenSound);
                break;
        }
    }


}
