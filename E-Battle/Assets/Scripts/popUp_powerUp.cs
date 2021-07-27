using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popUp_powerUp : MonoBehaviour
{
    // Start is called before the first frame update

    private static Text texto;
    private static bool naTela = false;
    private static bool tirarTela = false;

    private static float tempoTela = 4.0f;

    private static string nomePlayer;
    private static string nomePower;

    private static int popUpSpeed = 850;

    void Start()
    {
        GameObject.Find("popUp_powerUp").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
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
            GameObject.Find("popUp_powerUp").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUp").transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find("popUp_powerUp").transform.position, GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, GameObject.Find("Camera_Tabuleiro").transform.position.y / 2 + 120, 1)) < 0.001f)
            {
                tirarTela = true;
                naTela = false;
                GameObject.Find("popUp_powerUp/texto_popUp").GetComponent<Text>().text = "O player " + nomePlayer + " pegou o power up " + nomePower + "!";
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
                tempoTela = 4.0f;
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

}
