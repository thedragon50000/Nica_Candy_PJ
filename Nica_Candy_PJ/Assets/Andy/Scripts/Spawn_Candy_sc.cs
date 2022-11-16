using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawn_Candy_sc : MonoBehaviour
{
    private float countdown;
    private float currentTime = 0;

    //todo: modify by Unity Inspector
    public bool isLeftOrRight;

    //todo: modify by Unity Inspector
    public Vector3 goal = new Vector3(5, 0, -4);


    public GameObject unko;
    public GameObject candy;

    public Sprite[] CandySprites;

    void Awake()
    {
        countdown = Random.Range(0, 2);
        candy = GameManager_sc.inst.preGO;
        CandySprites = GameManager_sc.inst.preCandies;
    }

    private void Update()
    {
        if (GameManager_sc.inst.IsGameover)
        {
            return;
        }

        if (Time.time - currentTime >= countdown)
        {
            SpawnCandy_n_Reset_Countdown();
        }
    }


    private void SpawnCandy_n_Reset_Countdown()
    {
        if (GameManager_sc.inst.GetUnko() > 0)
        {
            int i = Random.Range(0, 100);
            switch (i)
            {
                case 88:
                    SpawnShit(GameManager_sc.inst.GetLevel());
                    break;
                default:
                    NewCandy(GameManager_sc.inst.GetLevel());
                    break;
            }

            if (GameManager_sc.inst.GetGameTime() >= 30)
            {
                SpawnShit(GameManager_sc.inst.GetLevel());
                print("unnnnnnnnnnko");
            }
        }
        else
        {
            NewCandy(GameManager_sc.inst.GetLevel());
        }
    }

    private void SpawnShit(int level)
    {
        GameObject go = Instantiate(unko, transform.position, Quaternion.identity);
        GameManager_sc.inst.UnkoHasSpawned();
        go.AddComponent<CandyMove_sc>();
        go.GetComponent<CandyMove_sc>().Init(level, goal, isLeftOrRight);
        countdown = Random.Range(1, 4);
        currentTime = Time.time;
    }

    private void NewCandy(int level)
    {
        GameObject obj = Instantiate(candy, transform.position, Quaternion.identity);
        candy.GetComponent<SpriteRenderer>().sprite = CandySprites[Random.Range(0, CandySprites.Length - 1)];
        obj.AddComponent<CandyMove_sc>();
        obj.GetComponent<CandyMove_sc>().Init(level, goal, isLeftOrRight);
        countdown = Random.Range(1, 4);
        currentTime = Time.time;
    }
}

public enum Nicas_position
{
    NONE,
    Left,
    Right
}