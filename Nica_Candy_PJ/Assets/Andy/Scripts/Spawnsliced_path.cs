using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnsliced_path : MonoBehaviour
{
    public Sprite[] spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = Resources.LoadAll<Sprite>("asset/Candies Sprite/images/candies");
    }

    // Update is called once per frame
    void Update()
    {
    }
}