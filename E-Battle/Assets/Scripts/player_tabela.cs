using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class player_tabela : MonoBehaviour
{

    [SerializeField]
    private GameObject tabela;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pegarPlayer()
    {
        tabela.GetComponent<setarTabelaPlayers>().acaoPowerUp(this.transform.GetChild(0).GetComponent<Text>().text);
    }
}
