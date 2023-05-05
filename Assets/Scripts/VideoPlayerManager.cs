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
        // �� �������� �����ϴ� ������ �̸� �ε��Ѵ�
        videoClips.Add("root", Resources.Load<VideoClip>("Videos/root"));
        videoClips.Add("left", Resources.Load<VideoClip>("Videos/left"));
        videoClips.Add("right", Resources.Load<VideoClip>("Videos/right"));
    }

    public void PlayVideo(string question)
    {
        // ������ �ε��ϰ� ����Ѵ�
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
        // ���� �������� Ŭ���� ��
        PlayVideo("left");
    }

    public void OnRightButtonClicked()
    {
        // ������ �������� Ŭ���� ��
        PlayVideo("right");
    }
}
