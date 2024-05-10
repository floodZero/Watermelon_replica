using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits; // 과일 프리팹 배열
    public Transform spawnPoint; // 과일이 생성될 위치

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFruit();
        }
    }

    void SpawnFruit()
    {
        int randomIndex = Random.Range(0, fruits.Length); // 랜덤 인덱스 선택
        Instantiate(fruits[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}
