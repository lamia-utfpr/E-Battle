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

    [SerializeField]
    private GameObject nomePlayer;

    [SerializeField]
    private GameObject Jogador;

    [SerializeField]
    private GameObject rolarDado;

    [SerializeField]
    private GameObject cameraTab;

    void Start()
    {
        nomePlayer.GetComponent<Text>().text = player.name;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0, 50, 0);
        if (rolarDado.transform.position == (cameraTab.transform.position + new Vector3(0, 0, 1)))
        {
            nomePlayer.GetComponent<Text>().color = new Color(255, 255, 255, 0);
            Jogador.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
        else
        {
            nomePlayer.GetComponent<Text>().color = new Color(0, 0, 0, 255);
            Jogador.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
