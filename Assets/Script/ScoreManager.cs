using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI 관련 기능을 사용하기 위해 추가


public class ScoreManager : MonoBehaviour
{
    public static int score = 0;  // 게임 점수를 저장하는 정적 변수
    public Text scoreText;        // 점수를 표시할 Text 컴포넌트

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;         // 점수 추가
        UpdateScoreText();       // 점수 텍스트 업데이트
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;  // Text 컴포넌트에 점수 표시
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
