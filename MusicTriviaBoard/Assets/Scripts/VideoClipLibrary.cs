using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoClipLibrary : MonoBehaviour
{
    private VideoPlayer track;
    public VideoClip[] VideoAssets = new VideoClip[30];
    public GameObject videoSystem;

    private int index = 0;
    public void SetIndex(int x)
    {
        index = x;
    }

    // Update is called once per frame
    void Update()
    {
        track.clip = VideoAssets[index];
    }

    private void Start()
    {
        track = gameObject.GetComponent<VideoPlayer>();
    }

    public void ShowAnswer()
    {
        track.Play();
        videoSystem.SetActive(true);
    }

    public void EndVideo()
    {
        track.Stop();
        videoSystem.SetActive(false);
    }
}
