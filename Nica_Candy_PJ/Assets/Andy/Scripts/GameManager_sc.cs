using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_sc : MonoBehaviour
{
    public static GameManager_sc inst;
    public int level;

    public GameObject nica;

    private float gameTime = 0;

    public float GetGameTime()
    {
        return gameTime;
    }
    // public int gameTimeShow;

    public Nicas_position ENica;
    public int score;

    public Sprite[] preCandies;
    public GameObject preGO;

    public Spawn_Candy_sc SpawnPointLeft;
    public Spawn_Candy_sc SpawnPointRight;

    public Sprite[] nums;

    public Image imgTens;
    public Image imgDigit;
    int totalTime = 60;

    /// <summary>
    /// 大便一場只有一個
    /// </summary>
    int UnkoNokori = 1;

    public GameObject resultBoard;
    public Text scoreText;
    public bool IsGameover = false;

    void Awake()
    {
        inst = this;
        preCandies = Resources.LoadAll<Sprite>("asset/Candies Sprite/images/candies");
    }

    private void Start()
    {
        IsGameover = false;
        gameTime = 0;
        totalTime = 60;
        AudioManager.inst.PlayBGM(EAudioScene.GameScene.ToString());
    }

    void Update()
    {
        if (IsGameover)
        {
            return;
        }

        //計時
        TimeCounting();


        LevelUpdate();

        NicaMove();
    }

    private void NicaMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 28);
            ENica = Nicas_position.Left;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            ENica = Nicas_position.NONE;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(4.6f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, -28);
            ENica = Nicas_position.Right;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            ENica = Nicas_position.NONE;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            ENica = Nicas_position.NONE;
        }
    }

    private void TimeCounting()
    {
        gameTime += Time.deltaTime;
        totalTime = 60 - (int)gameTime;
        ShowTimeCounting();
        if (totalTime <= 0)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        IsGameover = true;
        resultBoard.SetActive(true);
        scoreText.text = score.ToString();
    }

    private void ShowTimeCounting()
    {
        int tens = totalTime / 10;
        int digit = totalTime % 10;
        imgTens.sprite = nums[tens];
        if (digit <= 0)
        {
            imgDigit.sprite = nums[0];
        }

        imgDigit.sprite = nums[digit];
    }

    private void LevelUpdate()
    {
        if (gameTime >= 20)
        {
            switch (level)
            {
                case 0:
                    LevelUp();
                    break;
            }
        }

        if (gameTime >= 40)
        {
            switch (level)
            {
                case 1:
                    LevelUp();
                    break;
            }
        }
    }

    private void LevelUp()
    {
        level++;
    }

    public void UIScoreUpdate()
    {
        int tens = score / 10;
        int digit = score % 10;
        //todo:圖片
    }

    public int Nika_where()
    {
        return (int)ENica;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetUnko()
    {
        return UnkoNokori;
    }

    public void UnkoHasSpawned()
    {
        UnkoNokori = 0;
    }
}