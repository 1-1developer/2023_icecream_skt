using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using LKCSTest;
using UnityEngine.UI;

public class GelatoVideoManager : MonoBehaviour
{
    public PrintGelato printGelato;
    public VideoPlayer videoPlayer;
    public VideoPlayer resaultvideoPlayer;
    public RenderTexture renderTexture;
    public GameObject QuizScreen;
    public GameObject ResaultScreen;
    public GameObject StartScreen;
    [Header("Audio")]
    public AudioSource _audio;
    public AudioClip cilp;


    [Header("QuizTexts")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI A1;
    public TextMeshProUGUI A1c;
    public TextMeshProUGUI A2;
    public TextMeshProUGUI A2c;

    [Header("rasaults")]
    public Image youare;
    //public TextMeshProUGUI youare2;
    public Sprite[] type;
    public Image youare2;
    //public TextMeshProUGUI yourType;
    public TextMeshProUGUI[] icecreamsNames;
    public Toggle[] icecreambt;
    public Image[] icecreams;
    //public Sprite[] cups;
    public Sprite[] corns;
    public GameObject UIGroup;


    public QuestionData data;
    public VideoClip startLoopClip;
    public VideoClip[] S1;
    public VideoClip[] S2_Action;
    public VideoClip[] S2_Looping;
    public VideoClip[] S3_Action;
    public VideoClip[] S4_con;
    public VideoClip[] S4_resaults;


    public bool isStart =false;
     bool getresault =false;
    float pazeNum = -2;
    
    int scoreA = 0;
    int scoreB = 0;
    int scoreC = 0;
    int scoreD = 0;

    public bool isAnswered;
    int Quizindex = 0;
    int ranSeed;
    int Seed2;
    int Seed3; // 0: 콘 / 1:컵
    public int printcup; // 0: 콘 / 1:컵

    List<string> setQustions = new List<string>(); //랜덤선택할 5질문
    List<string> setAnswers = new List<string>(); //랜덤선택할 5질문

    public void setisAnswered(bool an)
    {
        isAnswered = an;

        if(pazeNum == -3)
        {
            StartScreen.SetActive(false);
            QuizScreen.SetActive(false);
            videoPlayer.clip = S1[5];
            videoPlayer.Play();
            pazeNum = 0;
            isAnswered = false;
            Debug.Log($"QI:{Quizindex}");
            setQuizText();
        }
    }
    public void setQuizText()
    {
        question.text = "Q. "+setQustions[Quizindex].Replace("\\n", "\n"); ;
        A1.text = setAnswers[Quizindex * 2].Split(":")[0].Replace("\\n", "\n");
        A1c.text = setAnswers[Quizindex * 2].Split(":")[1];
        A2.text = setAnswers[Quizindex * 2 + 1].Split(":")[0].Replace("\\n", "\n"); ;
        A2c.text = setAnswers[Quizindex * 2 + 1].Split(":")[1];
    }
    public void QuizindexPlus()
    {
        Quizindex++;
        Debug.Log($"QI:{Quizindex}");
    }
    // Start is called before the first frame update
    void Start()
    {
        //비디오 플레이어 설정
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.clip = S1[4];
        videoPlayer.Play();
        isAnswered = false;
        videoPlayer.loopPointReached += OnVideoClipFinished;
        resaultvideoPlayer.loopPointReached += OnResaultVideoClipFinished;
        initializeGelato();
        _audio = GetComponent<AudioSource>();
    }

    private void OnResaultVideoClipFinished(VideoPlayer source)
    {
        if(getresault)
        {
            UIGroup.SetActive(true);
            youare2.gameObject.SetActive(false);
            setResaultpage(GetMaxValue(), Seed3);
            ResaultScreen.SetActive(true);
            getresault = false;
        }
    }

    void SetQuestioinList()
    {
        while (setQustions.Count < 6)
        {
            int index = Random.Range(0, data.questions.Count);
            string selectedQ = data.questions[index];

            if (!setQustions.Contains(selectedQ))
            {
                setQustions.Add(selectedQ);
                setAnswers.Add(data.answers[index*2]);
                setAnswers.Add(data.answers[index*2+1]);
            }
        }
        ranSeed = Random.Range(0,4);
        Seed2= Random.Range(0,2);
        Seed3= Random.Range(0, 2);
    }
    void OnVideoClipFinished(VideoPlayer vp)
    {
        if (isAnswered ||( pazeNum % 2 == 1 && pazeNum < 7))//|| pazeNum==11)
        {
            QuizScreen.SetActive(false);
            pazeNum++;
            Debug.Log($"pazeNum:{pazeNum}");
            if(pazeNum <7)
            {
                setQuizText();
            }
        }
        switch (pazeNum)
        {
            case -3: //대기화면
                videoPlayer.clip = S1[4];
                break;
            case -2: //질문1 
                videoPlayer.clip = S1[4];
                pazeNum++;
                break;
            case -1: //문열리는 영상
                StartScreen.SetActive(false);
                QuizScreen.SetActive(false);
                videoPlayer.clip = S1[5];
                pazeNum++;
                break;
            case 0: //시작루핑-질문2
                QuizScreen.SetActive(true);
                videoPlayer.clip = S1[0];
                break;
            case 1:  //다음액션
                videoPlayer.clip = S1[1];
                break;
            case 2: //아이스크림 색 루핑 -질문3
                QuizScreen.SetActive(true);
                videoPlayer.clip = S1[2];
                break;
            case 3: //색 넣음 영상
                videoPlayer.clip = S2_Action[ranSeed];
                break;
            case 4: //골프장 루핑 -질문4         
                QuizScreen.SetActive(true);
                VideoClip nextClip = S2_Looping[ranSeed];
                videoPlayer.clip = nextClip;
                break;
            case 5: //
                videoPlayer.clip = S3_Action[ranSeed * 2 + Seed2];
                break;
            case 6:
                QuizScreen.SetActive(true);
                videoPlayer.clip = S1[3];
                break;
            case 7:
                _audio.PlayOneShot(cilp);
                QuizScreen.SetActive(false);
                videoPlayer.clip = S4_con[(ranSeed * 2 + Seed2) * 2 + Seed3];
                pazeNum++;
                break;
            case 8:
                videoPlayer.Pause();
                youare2.gameObject.SetActive(true);
                getresault = true;
                resaultvideoPlayer.clip = S4_resaults[GetMaxValue()];
                ResaultScreen.SetActive(true);
                pazeNum++;
                break;
            default:
                break;
        }
        if(pazeNum !=9)
            videoPlayer.Play();
        else 
            videoPlayer.Pause();
        isAnswered = false;
    }

  
    public void CalScore(TextMeshProUGUI bt)
    {
        switch (bt.text)
        {
            case "A":
                scoreA++;
                break;
            case "B":
                scoreB++;
                break;
            case "C":
                scoreC++;
                break;
            case "D":
                scoreD++;
                break;
            default:
                break;
        }
        Debug.Log($"A:{scoreA} ,B:{scoreB} ,C:{scoreC} ,D:{scoreD} ");
    }
    public int GetMaxValue()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        dict.Add("0", scoreA);
        dict.Add("1", scoreB);
        dict.Add("2", scoreC);
        dict.Add("3", scoreD);

        List<int> values = new List<int>(dict.Values);
        values.Sort();

        int maxValue = values[values.Count - 1];
        int resault = 0;
        foreach (KeyValuePair<string, int> pair in dict)
        {
            if (pair.Value == maxValue)
            {
                resault = int.Parse(pair.Key);
            }
        }
        return resault;
    }

    public void setResaultpage(int resault, int cup)
    {
        resaultvideoPlayer.clip = S4_resaults[resault];
        switch (resault)
        {
            case 0:
                //yourType.text = "A타입";
                youare.sprite = type[0];

                setIcecreamsBt(cup, 0, 1, 2);
                break;
            case 1:
                //yourType.text = "B타입";
                youare.sprite = type[1];
                setIcecreamsBt(cup, 3, 4, 5);
                break;
            case 2:
                //yourType.text = "C타입";
                youare.sprite = type[2];
                setIcecreamsBt(cup, 6, 7);
                break;
            case 3:
                //yourType.text = "D타입";
                youare.sprite = type[3];
                setIcecreamsBt(cup, 8, 9);
                break;
            default:
                break;
        }
    }
    public void setPaze(int num)
    {
        pazeNum = num;
    }
    public void debugName(GameObject g)
    {
        Debug.Log(g.name);
    }
      
    public void setIcecreamsBt(int cub,int a,int b, int c)
    {
        icecreamsNames[0].text = data.flavors[a];
        icecreamsNames[1].text = data.flavors[b];
        icecreamsNames[2].text = data.flavors[c];

        icecreams[0].sprite = corns[a];
        icecreams[1].sprite = corns[b];
        icecreams[2].sprite = corns[c];


        for (int i = 0; i < 3; i++)
        {
            icecreambt[i].gameObject.SetActive(true);
        }
    }
    public void setIcecreamsBt(int cub, int a, int b)
    {
        icecreamsNames[0].text = data.flavors[a];
        icecreamsNames[1].text = data.flavors[b];

        icecreams[0].sprite = corns[a];
        icecreams[1].sprite = corns[b];

        for (int i = 0; i < 2; i++)
        {
            icecreambt[i].gameObject.SetActive(true);
        }
    }

    public void initializeGelato()
    {
        scoreA = 0;
        scoreB = 0;
        scoreC = 0;
        scoreD = 0;
        //QuizScreen.SetActive(false);
        setQustions.Clear();
        setAnswers.Clear();
        icecreambt[0].gameObject.SetActive(false);
        icecreambt[1].gameObject.SetActive(false);
        icecreambt[2].gameObject.SetActive(false);
        ResaultScreen.SetActive(false);

        pazeNum = -3;
        videoPlayer.clip = S1[4];
        Quizindex = 0;

        SetQuestioinList();

        question.text = setQustions[Quizindex];
        Debug.Log(setQustions[0]);
        Debug.Log(setQustions[1]);
        Debug.Log(setQustions[2]);
        Debug.Log(setQustions[3]);
        Debug.Log(setQustions[4]);
        A1.text = setAnswers[0].Split(":")[0];
        A1c.text = setAnswers[0].Split(":")[1];
        A2.text = setAnswers[1].Split(":")[0];
        A2c.text = setAnswers[1].Split(":")[1];

        youare2.gameObject.SetActive(false);
        getresault = false;

        QuizScreen.SetActive(false);
        UIGroup.SetActive(false);
        StartScreen.SetActive(true);
        isStart = false;
    }
    public void StartGelato()
    {
        isStart = true;
        QuizScreen.SetActive(true);
        StartScreen.SetActive(false);
        setQuizText();
        Debug.Log($"QI:{Quizindex}");
    }


    public void imageChange(int cup)
    {
        printcup = cup;

        switch (GetMaxValue())
        {
            case 0:
                for (int i = 0; i < icecreambt.Length; i++)
                {
                    //icecreambt[i].GetComponent<Animator>().Play();
                }
                setIcecreamsBt(cup, 0, 1, 2);
                for (int i = 0; i < icecreambt.Length; i++)
                {
                    icecreambt[i].gameObject.SetActive(true);
                }
                break;
            case 1:
                for (int i = 0; i < icecreambt.Length; i++)
                {
                    icecreambt[i].gameObject.SetActive(false);
                }
                setIcecreamsBt(cup, 3, 4, 5);
                for (int i = 0; i < icecreambt.Length; i++)
                {
                    icecreambt[i].gameObject.SetActive(true);
                }
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    icecreambt[i].gameObject.SetActive(false);
                }
                setIcecreamsBt(cup, 6, 7);
                for (int i = 0; i < 2; i++)
                {
                    icecreambt[i].gameObject.SetActive(true);
                }
                break;
            case 3:
                for (int i = 0; i < 2; i++)
                {
                    icecreambt[i].gameObject.SetActive(false);
                }
                setIcecreamsBt(cup, 8, 9);
                for (int i = 0; i < 2; i++)
                {
                    icecreambt[i].gameObject.SetActive(true);
                }
                break;
            default:
                break;
        }

    }
}
