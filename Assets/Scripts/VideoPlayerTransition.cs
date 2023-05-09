using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerTransition : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Camera transitionCamera;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public float fadeDuration = 1f;

    private int currentClipIndex = 0;
    private Material material;
    private float fadeTimer = 0f;

    private void Start()
    {
        //transitionCamera.targetTexture = renderTexture;
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.clip = videoClips[currentClipIndex];
        videoPlayer.Play();

        videoPlayer.loopPointReached += OnVideoClipFinished;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TransitionToNextClip();
        }

        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float alpha = fadeTimer / fadeDuration;
            material.color = new Color(1f, 1f, 1f, alpha);
        }
    }

    public void TransitionToNextClip()
    {
        currentClipIndex = (currentClipIndex + 1) % videoClips.Length;
        VideoClip nextClip = videoClips[currentClipIndex];

        fadeTimer = 0f;
        material.color = Color.black;

        videoPlayer.Stop();
        videoPlayer.clip = nextClip;
        videoPlayer.Play();
    }
    void OnVideoClipFinished(VideoPlayer vp)
    {
        // Switch to the next clip
        currentClipIndex++;
        if (currentClipIndex >= videoClips.Length)
        {
            currentClipIndex = 0;
        }

        videoPlayer.clip = videoClips[currentClipIndex];
        videoPlayer.Play();
    }
}
