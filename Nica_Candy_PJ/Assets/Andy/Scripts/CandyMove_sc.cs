using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CandyMove_sc : MonoBehaviour
{
    public ECandyFrom EFrom;
    private Vector3 spawnPosition;

    public GameObject shining;

    private float sindo = 0;

    public float speedLevel = 1;
    private Vector3 goal;

    void Start()
    {
        switch (gameObject.name.Contains("Poop"))
        {
            case false:
                shining = this.gameObject.transform.GetChild(0).gameObject;
                break;
            case true:
                print("大便沒有特效");
                break;
        }

        //紀錄出生位置，用lerp往終點移動
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (GameManager_sc.inst.IsGameover)
        {
            return;
        }

        TranslateCandy_n_CandyDie();
        RotateCandy();
        MicrifyCandy_n_Destroy();
        CatchHandan();
    }

    /// <summary>
    /// 糖果往終點移動
    /// </summary>
    private void TranslateCandy_n_CandyDie()
    {
        if (gameObject.name.Contains("Poop"))
        {
            //不可迴避的便便
            transform.position = Vector3.Lerp(spawnPosition, GameManager_sc.inst.nica.transform.position, sindo);
            if (sindo >= 1)
            {
                //大便好吃
                AudioManager.inst.PlaySFX(EAudioScene.UnkoCatched.ToString());
            }
        }
        else
        {
            transform.position = Vector3.Lerp(spawnPosition, goal, sindo);
            if (transform.lossyScale.x <= 0.4f)
            {
                shining.SetActive(false);
                SpriteRenderer render = GetComponent<SpriteRenderer>();
                render.material.color = Color.gray;
            }
        }

        sindo += 0.5f * speedLevel * Time.deltaTime;
    }

    /// <summary>
    /// 判斷是否接到糖果
    /// </summary>
    private void CatchHandan()
    {
        if (gameObject.name.Contains("Poop"))
        {
            return;
        }

        if (transform.lossyScale.x <= 0.7f && transform.lossyScale.x > 0.4f)
        {
            switch (GameManager_sc.inst.Nika_where() == (int)EFrom)
            {
                case true:
                    CandyEaten();
                    break;
            }
        }

        if (transform.lossyScale.x <= 1)
        {
            shining.SetActive(true);
        }
    }

    /// <summary>
    /// 接到糖果的void
    /// </summary>
    private void CandyEaten()
    {
        switch (gameObject.name.Contains("Poop"))
        {
            case true:
                print("catch Unko");
                break;
        }

        CandyScore();
        Destroy(gameObject);
    }

    /// <summary>
    /// 分數+1
    /// </summary>
    private void CandyScore()
    {
        GameManager_sc.inst.score++;
        GameManager_sc.inst.UIScoreUpdate();
    }

    /// <summary>
    /// 糖果轉啊
    /// </summary>
    void RotateCandy()
    {
        transform.Rotate(0, 0, 0.5f * speedLevel);
    }

    /// <summary>
    /// 不斷縮小，到底了就刪除
    /// </summary>
    void MicrifyCandy_n_Destroy()
    {
        if (transform.lossyScale.x >= 0.1f)
        {
            transform.localScale -=
                new Vector3(0.5f * speedLevel * Time.deltaTime,
                    0.5f * speedLevel * Time.deltaTime, 0);
            transform.position += new Vector3(0, 0, 0.5f * speedLevel * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init(int i, Vector3 v3, bool isleft)
    {
        goal = v3;
        switch (gameObject.name.Contains("Poop"))
        {
            case true:
                speedLevel = 0.5f;
                break;
            case false:
                switch (isleft)
                {
                    case true:
                        EFrom = ECandyFrom.fromLeft;
                        break;
                    case false:
                        EFrom = ECandyFrom.fromRight;
                        break;
                }

                switch (i)
                {
                    case 0:
                        speedLevel = 1;
                        break;
                    case 1:
                        speedLevel = 2.5f;
                        break;
                    case 2:
                        speedLevel = 5;
                        break;
                }

                break;
        }
    }

    public enum ECandyFrom
    {
        NONE,
        fromLeft,
        fromRight
    }
}