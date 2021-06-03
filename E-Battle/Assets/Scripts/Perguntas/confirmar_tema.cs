using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class confirmar_tema : MonoBehaviour
{
    public AudioSource audioConfirmTema;
    List<string> group_names = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void confirmarTema()
    {
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().confirmar_tema();
    }


    public void temaPartida()
    {
        if (verificarNomesPreenchidos())
        {
            List<string> texto_pergunta = new List<string>();


            for (int i = 0; i < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; i++)
            {
                group_names.Add(GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().text);
            }

            tabelaDosTemas.confirmar_temaPartida();
            MvP1.set_quantiaPlayers(GameObject.Find("quantia_jogadores_slider").GetComponent<slider_quantiaplayer>().getValorSlider());
            MvP1.set_groupNames(group_names);
            apresentarPergunta.setTempoMaximo(GameObject.Find("config_jogo/quantia_tempo_slider").GetComponent<Slider>().value + 1);
            HUD.setPlayer(group_names[0]);
            //        GameObject.Find("config_jogo").transform.position = new Vector3(3000, 3000, 0);
            //        GameObject.Find("Camera_Tabuleiro").transform.localScale = new Vector3(3.5f, 3.5f, 1);
            //       audioConfirmTema = GameObject.Find("confirmar_selecao_tema").GetComponent<AudioSource>();
            //        audioConfirmTema.Play();


            SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
        }
        else
        {
            popUp_preencherNomesGrupos.mostrarPopUp();
        }


    }


    private bool verificarNomesPreenchidos()
    {

        for (int i = 0; i < (int)GameObject.Find("config_jogo/quantia_jogadores_slider").GetComponent<Slider>().value; i++)
        {
            if (GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().interactable &&
             String.IsNullOrWhiteSpace(GameObject.Find("PlayerName" + (i + 1)).GetComponent<InputField>().text))
                return false;
        }

        return true;

    }

}
