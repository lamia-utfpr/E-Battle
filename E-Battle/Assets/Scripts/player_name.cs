using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class player_name : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject player;

    void Start()
    {
        GameObject.Find(this.name + "/Text").GetComponent<Text>().text = player.name;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 50, 0);
        if (GameObject.Find("rolarDado").transform.position == (GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 0, 1)))
        {
            GameObject.Find(this.name + "/Text").GetComponent<Text>().color = new Color(255, 255, 255, 0);
            GameObject.Find(this.name).GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        else
        {
            GameObject.Find(this.name + "/Text").GetComponent<Text>().color = new Color(0, 0, 0, 255);
            GameObject.Find(this.name).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
