using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIAudioPlayer : MonoBehaviour
{
    public AudioClip touchSound;    // 터치 효과음
    public AudioClip intro;    //인트로보이스
    public GelatoVideoManager gelato;
    private AudioSource audioSource;
    public AudioSource audioSource2;

    public Button[] bts;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        for (int i = 0; i < bts.Length; i++)
        {
            bts[i].onClick.AddListener(PlayTouchSound);
        }
        audioSource2.PlayOneShot(intro);
    }
    public void PlayTouchSound()
    {
        audioSource.PlayOneShot(touchSound);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!gelato.isStart && (timer > 20f))
        {
            audioSource2.PlayOneShot(intro);
            timer = 0;
        }
        if (gelato.isStart)
        {
            audioSource2.Stop();
        }
    }
}
