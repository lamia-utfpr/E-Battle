using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_powerUp : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource som;
    public AudioClip comemora;
    

    private static Text texto;
    private static bool naTela = false;

    private static bool tirarTela = false;

    private static float tempoTela = 6.0f;
    private static string nomePlayer;
    private static string nomePower;
    private static int popUpSpeed = 850;

    void Start()
    {
        GameObject.Find("popUp_powerUp").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras1").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras2").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
        GameObject.Find("popUp_powerUpAtras3").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
    }


    public static bool get_naTela()
    {
        return naTela;
    }

    // Update is called once per frame
    void Update()
    {

        if (naTela)
        {
            som = GameObject.Find("Audio Source").GetComponent<AudioSource>();
            som.clip = comemora;
            som.Play();
            GameObject.Find("popUp_powerUp").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUp").transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1), popUpSpeed * Time.deltaTime);

            if (Vector3.Distance(GameObject.Find("popUp_powerUp").transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1)) < 0.001f)
            {
                tirarTela = true;
                naTela = false;
                GameObject.Find("popUp_powerUp/texto_popUp").GetComponent<Text>().text = "O grupo " + nomePlayer + " pegou o super poder " + nomePower + "!";
            }
        }

        if (tirarTela)
        {
            removerTela();
        }
    }

    public static void removerTela()
    {
        if (tempoTela > 1)
        {
            tempoTela -= Time.deltaTime;
        }
        else
        {

            GameObject.Find("popUp_powerUp").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUp").transform.position, new Vector3(0, 2000, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find("popUp_powerUp").transform.position, new Vector3(0, 2000, 1)) < 500f)
            {
                tirarTela = false;
                tempoTela = 6.0f;
                GameObject.Find("popUp_powerUp").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
            }
        }
    }

    public static void mostrarPopUp(string nomeplayer, string nomepower)
    {
        if (!naTela)
        {
            nomePlayer = nomeplayer;
            nomePower = nomepower;
            naTela = true;
            GameObject.Find("popUp_powerUp/texto_popUp").GetComponent<Text>().text = "";
        }

    }

    public static void mostrarPopUpAtras(string nomeplayer, string nomepower, int indice)
    {
        switch (indice)
        {
            case 1:
                GameObject.Find("popUp_powerUpAtras1").GetComponent<popUp_powerUpAtras>().setInfo1(nomeplayer, nomepower);
                break;
            case 2:
                GameObject.Find("popUp_powerUpAtras2").GetComponent<popUp_powerUpAtras>().setInfo2(nomeplayer, nomepower);
                break;
            case 3:
                GameObject.Find("popUp_powerUpAtras3").GetComponent<popUp_powerUpAtras>().setInfo3(nomeplayer, nomepower);
                break;
        }
    }

}