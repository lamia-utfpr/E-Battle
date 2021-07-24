using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour
{


    // Use this for initialization
    private void Start()
    {

    }

    public void initDado()
    {
        if (GameObject.Find("Players").GetComponent<MvP1>().getDadoMaior())
        {
            GameObject.Find("DadoD8").transform.position = GameObject.Find("rolarDado").transform.position + new Vector3(0, 0, 1);
            GameObject.Find("DadoD6").transform.position = new Vector3(3000, 3000, 0);
        }
        else
        {
            GameObject.Find("DadoD6").transform.position = GameObject.Find("rolarDado").transform.position + new Vector3(0, 0, 1);
            GameObject.Find("DadoD8").transform.position = new Vector3(3000, 3000, 0);
        }
    }
}

