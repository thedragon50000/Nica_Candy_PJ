using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_add_sc1 : MonoBehaviour
{
    void Start()
    {
        ButtonDecide();
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
                case "restart":
                    obj.GetComponent<CandyButton_sc>().btnAction += ReloadScene;
                    break;
                default:
                    print(obj.ToString());
                    break;
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
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