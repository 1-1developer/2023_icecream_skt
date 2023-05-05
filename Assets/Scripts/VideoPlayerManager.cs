using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private Dictionary<string, VideoClip> videoClips = new Dictionary<string, VideoClip>();

    void Start()
    {
        LoadVideoClips();
        PlayVideo("root");
    }

    void LoadVideoClips()
    {
        // 각 선택지에 대응하는 영상을 미리 로드한다
        videoClips.Add("root", Resources.Load<VideoClip>("Videos/root"));
        videoClips.Add("left", Resources.Load<VideoClip>("Videos/left"));
        videoClips.Add("right", Resources.Load<VideoClip>("Videos/right"));
    }

    public void PlayVideo(string question)
    {
        // 영상을 로드하고 재생한다
        if (videoClips.ContainsKey(question))
        {
            videoPlayer.clip = videoClips[question];
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Video clip not found for question: " + question);
        }
    }

    public void OnLeftButtonClicked()
    {
        // 왼쪽 선택지를 클릭할 때
        PlayVideo("left");
    }

    public void OnRightButtonClicked()
    {
        // 오른쪽 선택지를 클릭할 때
        PlayVideo("right");
    }
}
