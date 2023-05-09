using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using LKCSTest;

public class ManagerTest : MonoBehaviour
{
    public GameObject initBt;
    public PrintTest printTest;
    public TextMeshProUGUI tx;
    //public PrintTest printTest;
    public RenderTexture renderTexture;
    public Camera transitionCamera;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public float fadeDuration = 1f;

    private int currentClipIndex = 0;
    private Material material;
    private float fadeTimer = 0f;
    private int Selectvideoindex = 0;
    private void Start()
    {

        //transitionCamera.targetTexture = renderTexture;
        videoPlayer.targetTexture = renderTexture;
        tx.text = "ss";
        videoPlayer.clip = videoClips[currentClipIndex];
        //videoPlayer.isLooping = true;
        initBt.SetActive(false);

        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoClipFinished;
    }

    private void Update()
    {
    }

    void OnVideoClipFinished(VideoPlayer vp)
    {
        if(Selectvideoindex == 0)
        {
            playVideo(0);
            return;
        }
        else if(Selectvideoindex == 1)
        {
            videoPlayer.Pause();
            printTest.printStringButton_Click();
            tx.text = "video1 print";
            initBt.SetActive(true);
        }
        else if (Selectvideoindex == 2)
        {
            videoPlayer.Pause();
            printTest.printNormalButton_Click();
            tx.text = "video2 print";
            initBt.SetActive(true);
        }
    }

    public void playVideo(int clipindex)
    {
        Selectvideoindex = clipindex;
        videoPlayer.clip = videoClips[clipindex];
        videoPlayer.Play();
        tx.text = $"video{clipindex} play";
    }
}
