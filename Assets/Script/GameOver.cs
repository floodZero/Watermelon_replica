using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel; // Game Over 패널

    public AudioSource bgm; // BGM 사운드
    public AudioSource gameOverSound; // Game Over 사운드

    void Start()
    {
        gameOverPanel.SetActive(false); // 게임 시작 시 게임 오버 패널을 비활성화
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
            bgm.Stop(); // 게임 BGM 정지
            gameOverSound.Play(); // 게임 오버 사운드 실행
            Time.timeScale = 0; // 게임 시간 정지
        }
    }

    public void RetryGame()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();  // 점수 관리자 찾기
        if (scoreManager != null)
        {
            scoreManager.ResetScore();  // 점수 리셋
        }
        Time.timeScale = 1; // 게임 시간 재개
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
    }
}
