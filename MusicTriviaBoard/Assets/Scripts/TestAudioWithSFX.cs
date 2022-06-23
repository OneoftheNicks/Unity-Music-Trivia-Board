using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioWithSFX : MonoBehaviour
{
    public AudioClip[] audioClips = new AudioClip[5];
    public AudioSource playSFX; 

    //define rng
    //private Random rng = new Random();

    // Start is called before the first frame update
    void Start()
    {
        //set default
        playSFX.clip = audioClips[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestSFX()
    {
        int rng = Random.Range(0, 6);

        switch(rng)
        {
            case 0:
                playSFX.clip = audioClips[0];
                playSFX.Play();
                break;
            case 1:
                playSFX.clip = audioClips[1];
                playSFX.Play();
                break;
            case 2:
                playSFX.clip = audioClips[2];
                playSFX.Play();
                break;
            case 3:
                playSFX.clip = audioClips[3];
                playSFX.Play();
                break;
            case 4:
                playSFX.clip = audioClips[4];
                playSFX.Play();
                break;
        }
    }
}
