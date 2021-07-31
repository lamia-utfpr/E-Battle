using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class popUp_powerUpAtras : MonoBehaviour
{
    // Start is called before the first frame update

    public static string nomePlayerAtras1;
    public static string nomePowerAtras1;

    public static string nomePlayerAtras2;
    public static string nomePowerAtras2;

    public static string nomePlayerAtras3;
    public static string nomePowerAtras3;

    private static float tempoTela1 = 15f;
    private static float tempoTela2 = 15f;
    private static float tempoTela3 = 15f;
    private static int popUpSpeed = 400;
    static bool show1, show2, show3, tirar1, tirar2, tirar3;

    void Start()
    {
        show1 = false;
        show2 = false;
        show3 = false;
        tirar1 = false;
        tirar2 = false;
        tirar3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (show1)
        {
            Show1();
        }

        if (tirar1)
        {
            removerTela1();
        }

        if (show2)
        {
            Show2();
        }

        if (tirar2)
        {
            removerTela2();
        }
    
        if (show3)
        {
            Show3();
        }

        if (tirar3)
        {
            removerTela3();
        }
    }


    private void Show1()
    {
        GameObject.Find("popUp_powerUpAtras1").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras1").transform.position, GameObject.Find("HUD_principal").transform.position + new Vector3(100, -150, 1), popUpSpeed * Time.deltaTime);

        if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras1").transform.position, GameObject.Find("HUD_principal").transform.position + new Vector3(100, -150, 0)) <= 1f)
        {
            tirar1 = true;
            show1 = false;
            GameObject.Find("popUp_powerUpAtras1/texto_popUp").GetComponent<Text>().text = "O grupo " + nomePlayerAtras1 + " ganhou o super poder " + nomePowerAtras1 + " por estar 10 casas atrás do primeiro!";
        }
    }

    private void Show2()
    {
        GameObject.Find("popUp_powerUpAtras2").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras2").transform.position, GameObject.Find("popUp_powerUpAtras1").transform.position + new Vector3(0, -90, 1), popUpSpeed * Time.deltaTime);

        if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras2").transform.position, GameObject.Find("popUp_powerUpAtras1").transform.position + new Vector3(0, -90, 1)) <= 1f)
        {
            tirar2 = true;
            show2 = false;
            GameObject.Find("popUp_powerUpAtras2/texto_popUp").GetComponent<Text>().text = "O grupo " + nomePlayerAtras2 + " ganhou o super poder " + nomePowerAtras2 + " por estar 10 casas atrás do primeiro!";
        }
    }

    private void Show3()
    {
        GameObject.Find("popUp_powerUpAtras3").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras3").transform.position, GameObject.Find("popUp_powerUpAtras2").transform.position + new Vector3(0, -90, 1), popUpSpeed * Time.deltaTime);

        if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras3").transform.position, GameObject.Find("popUp_powerUpAtras2").transform.position + new Vector3(0, -90, 1)) <= 1f)
        {
            tirar3 = true;
            show3 = false;
            GameObject.Find("popUp_powerUpAtras3/texto_popUp").GetComponent<Text>().text = "O grupo " + nomePlayerAtras3 + " ganhou o super poder " + nomePowerAtras3 + " por estar 10 casas atrás do primeiro!";
        }
    }

    public void setInfo1(string nomeplayer, string nomepower)
    {
        nomePlayerAtras1 = nomeplayer;
        nomePowerAtras1 = nomepower;
        show1 = true;
    }

    public void setInfo2(string nomeplayer, string nomepower)
    {
        nomePlayerAtras2 = nomeplayer;
        nomePowerAtras2 = nomepower;
        show2 = true;
    }

    public void setInfo3(string nomeplayer, string nomepower)
    {
        nomePlayerAtras3 = nomeplayer;
        nomePowerAtras3 = nomepower;
        show3 = true;
    }

    public static void removerTela1()
    {
        if (tempoTela1 > 1)
        {
            tempoTela1 -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("popUp_powerUpAtras1").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras1").transform.position, new Vector3(0, 2000, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras1").transform.position, new Vector3(0, 2000, 1)) < 500f)
            {

                tirar1 = false;
                tempoTela1 = 15f;
                GameObject.Find("popUp_powerUpAtras1").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
            }
        }
    }

    public static void removerTela2()
    {
        if (tempoTela2 > 1)
        {
            tempoTela2 -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("popUp_powerUpAtras2").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras2").transform.position, new Vector3(0, 2000, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras2").transform.position, new Vector3(0, 2000, 1)) < 500f)
            {

                tirar2 = false;
                tempoTela2 = 15f;
                GameObject.Find("popUp_powerUpAtras2").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
            }
        }
    }

    public static void removerTela3()
    {
        if (tempoTela3 > 1)
        {
            tempoTela3 -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("popUp_powerUpAtras3").transform.position = Vector3.MoveTowards(GameObject.Find("popUp_powerUpAtras3").transform.position, new Vector3(0, 2000, 1), popUpSpeed * Time.deltaTime);
            if (Vector3.Distance(GameObject.Find("popUp_powerUpAtras3").transform.position, new Vector3(0, 2000, 1)) < 500f)
            {

                tirar3 = false;
                tempoTela3 = 15f;
                GameObject.Find("popUp_powerUpAtras3").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 1);
            }
        }
    }
}
