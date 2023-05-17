using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionData : MonoBehaviour
{
    public List<string> questions = new List<string>()
    {
        "슬픔은 나누면",
        "30년 뒤의 \n되고 싶은 내 모습",
        "인생의 찐친은",
        "일할 때",
        "꿈을 꿀 때",
        "나는 일의",
        "휴일에 보통",
        "모닝 루틴이",
        "길을 걷다가\n두 갈림길이 나오면",
        "사람들 대하는 일이",
        "현재 내게\n더 어려운 것은",
        "나는 미래 인생 계획을"
    };

    public List<string> answers = new List<string>()
    {
        "반이된다:B",
        "배가된다:C",
        "상상이 된다:D",
        "상상이 안 된다:D",
        "손가락 안에 \n 꼽는다:C",
        "손가락, 발가락 \n다 필요하다:B",
        "체계적으로\n 계획하여\n 마무리짓는다:A",
        "다양한 \n방향으로 \n펼쳐 나간다:D",
        "현실에서\n 일어날 법한 \n일을 꾼다:A",
        "한 번도\n 상상 못해본\n 판타지 세계를 꾼다:B",
        "과정을 중시:D",
        "결과를 중시:A",
        "약속을 나간다:B",
        "집에서 휴식을 취한다:C",
        "있다:A",
        "없다:D",
        "많은 흔적이\n 남아있는\n 길을 간다:B",
        "아무도\n 가보지 않은\n 길을 간다:C",
        "어렵다:C",
        "아니다:B",
        "남을 챙기는 것:B",
        "나를 위하는 것:C",
        "세워놨다:A",
        "안 세워놨다:D"
    };

   public List<string> flavors = new List<string>()
    {
        "스위스초코",
        "리조(쌀)",
        "교토우지말차",
        "패션후르츠소르베",
        "베리베리요거트",
        "수박",
        "구운피스타치오",
        "프렌치바닐라",
        "흑임자",
        "돼지또"
    };
}
