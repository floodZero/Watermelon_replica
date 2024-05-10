using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    // 공개 변수로 힘의 크기와 방향을 인스펙터에서 조절할 수 있게 합니다.
    public float forceMagnitude = 3f;
    // 과일의 종류
    public string fruitType;
    // 다음 단계 과일의 프리팹
    public GameObject nextStageFruitPrefab;

    // 루한 루프를 방지하기 위한 다른 과일과의 충돌 가능 플래그
    public bool canCollideWithOtherFruit = false;

    private bool isMerging = false; // 현재 과일이 병합 중인지 여부를 나타내는 플래그

    public AudioSource mergeSound; // 합체 사운드


    void Start()
    {
        this.canCollideWithOtherFruit = false;
        Invoke("EnableCollider", 0.5f); // 0.5초 후에 Collider 활성화
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EnableCollider()
    {
        this.canCollideWithOtherFruit = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (this.canCollideWithOtherFruit && otherFruit != null && otherFruit.fruitType == this.fruitType && !this.isMerging && !otherFruit.isMerging)
        {
            this.isMerging = true;
            otherFruit.isMerging = true;

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();  // 점수 관리자 찾기
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);  // 점수 10점 추가
            }

            mergeSound.Play(); // 합체 사운드 재생

            Vector3 spawnPosition = (this.transform.position + otherFruit.transform.position) / 2; // 두 과일의 중간 위치 계산
            Instantiate(nextStageFruitPrefab, spawnPosition, Quaternion.identity); // 다음 단계 과일 생성
            Destroy(otherFruit.gameObject); // 다른 과일 파괴
            Destroy(this.gameObject); // 현재 과일 파괴
        }
        else
        {
            // 충돌 지점에서의 충돌 법선 벡터를 가져옵니다.
            Vector2 collisionNormal = collision.contacts[0].normal;
            // 충돌 법선과 반대 방향으로 힘을 적용합니다.
            Vector2 forceDirection = -collisionNormal;

            // Rigidbody2D 컴포넌트를 가져와서 힘을 추가합니다.
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
            }
        }
    }
}