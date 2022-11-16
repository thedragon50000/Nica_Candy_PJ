using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_add_sc : MonoBehaviour
{
    public GameObject infoBoard;

    private bool isScrollShowing;

    void Start()
    {
        ButtonDecide();
        isScrollShowing = false;
        infoBoard.SetActive(false);
        AudioManager.inst.PlayBGM(EAudioScene.StartScene.ToString());
    }

    private void ButtonDecide()
    {
        foreach (Transform obj in transform)
        {
            obj.gameObject.AddComponent<CandyButton_sc>();
            obj.gameObject.AddComponent<BoxCollider2D>();
            switch (obj.name)
            {
                case "twitter":
                    obj.GetComponent<CandyButton_sc>().btnAction +=
                        () => Application.OpenURL("https://twitter.com/NicaWolper");
                    break;
                case "youtube":
                    obj.GetComponent<CandyButton_sc>().btnAction += () =>
                        // Application.OpenURL("https://www.youtube.com/channel/UCUOr_gncX_qdhezesVS3sqQ");
                        Application.OpenURL(
                            "https://www.youtube.com/watch?v=KEOxYWPE8I0&list=PLwBytrFZyEW7Dda3fagcsafkdJbnhvcbf");
                    break;
                case "Info":
                    obj.GetComponent<CandyButton_sc>().btnAction += ShowInfo;
                    break;
                case "play":
                    obj.GetComponent<CandyButton_sc>().btnAction += GameStart;
                    break;
                default:
                    print(obj.ToString());
                    break;
            }
        }
    }

    private void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (isScrollShowing)
            {
                case true:
                    isScrollShowing = false;
                    infoBoard.SetActive(false);
                    break;
                default:
                    print("Scroll is not showing.");
                    break;
            }
        }
    }

    private void ShowInfo()
    {
        isScrollShowing = true;
        infoBoard.SetActive(true);
    }

    public class CandyButton_sc : MonoBehaviour
    {
        public Action btnAction;

        private void OnMouseUp()
        {
            print(gameObject + " clicked");
            btnAction?.Invoke();
        }
    }
}