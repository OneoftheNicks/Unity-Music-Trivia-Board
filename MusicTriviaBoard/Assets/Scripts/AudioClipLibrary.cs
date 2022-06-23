using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioClipLibrary : MonoBehaviour
{
    public Slider timer;
    public Text displayTimer;
    public AudioClip[] AudioAssets = new AudioClip[30];
    private AudioSource track;

    private float watch = 20.0f;
    private int index = 0;
    public void SetIndex(int x)
    {
        index = x;
    }

    public void setWatch(float watch)
    {
        this.watch = watch;
        displayTimer.text = watch.ToString("F1");
    }

    private void Start()
    {
        watch = 20.0f;
        displayTimer.text = watch.ToString("F1");
        stopWatch = false;
        track = gameObject.GetComponent<AudioSource>();
    }

    private bool stopWatch;
    //private bool played = false;
    public void swapState()
    {
        stopWatch = !stopWatch;
    }

    // Update is called once per frame
    void Update()
    {
        //start/stop
        if(stopWatch)
        {
            watch -= Time.smoothDeltaTime;
            timer.value += Time.smoothDeltaTime;
            displayTimer.text = watch.ToString("F1");

            if(!track.isPlaying)
            track.Play();
        }
        else
        {
            track.Pause();
        }

        if(watch < 0.0f)
        {
            stopWatch = false;
            watch = 20.0f;
            timer.value = 0;
        }

        track.clip = AudioAssets[index];
    }

    public void ResetTimer()
    {
        stopWatch = false;
        watch = 20.0f;
        displayTimer.text = watch.ToString("F1");
        timer.value = 0;
        track.Stop();
    }

}
