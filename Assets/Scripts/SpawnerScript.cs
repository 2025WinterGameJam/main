using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    float startTime; //ステージ開始時間
    float elaspedTime;//経過時間

    public int lineCount;                                   //線路の数
    public float betweenIni = 3;                            //電車が出現する間隔(秒)
    public int spawnerCount;
    public GameObject [] spawnerArray = new GameObject[6];  //スポナーの配列
    public GameObject[] trainArray = new GameObject[1];     //電車の配列(Prefab的な)

    public GameObject conveat;

    public struct spawnerSt
    {
        public GameObject spawnerObj;
        public bool used;
    }

    public spawnerSt[] spStArray = new spawnerSt[6]; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        elaspedTime = 0.0f;

        for(int i = 0; i < spawnerCount; i++)
        {
            spStArray[i].spawnerObj = spawnerArray[i];
            spStArray[i].used = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elaspedTime = Time.time - startTime;

        if (elaspedTime >= betweenIni)
        {
            int r = UnityEngine.Random.Range(0, spawnerCount);

            Vector2 spawn = spStArray[r].spawnerObj.transform.position;
            //int rPair = r / 2;
            //spStArray[rPair].used = true;
            //spStArray[rPair + 1].used = true;

            Vector2 spawnCon = spawn;
            if(spawn.x < 0)
            {
                spawnCon.x += 8;
            }
            else
            {
                spawnCon.x -= 8;
            }

            //GameObject obj = Instantiate(trainArray[0], spawn, Quaternion.identity);
            GameObject img = Instantiate(conveat, spawnCon, Quaternion.identity);
            StartCoroutine(InstTrainDelay(spawn, 3f));

            startTime = Time.time;
            elaspedTime = 0.0f;
        }
    }

    //電車を生成する
    public void InstTrain(Vector2 spawn)
    {
        GameObject obj = Instantiate(trainArray[0], spawn, Quaternion.identity);
    }
    IEnumerator InstTrainDelay(Vector2 spawn, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(trainArray[0], spawn, Quaternion.identity);
    }
}
