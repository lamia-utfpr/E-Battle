using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour
{

    [SerializeField]
    private GameObject players;

    [SerializeField]
    private GameObject dadoD8;

    [SerializeField]
    private GameObject dadoD6;

    [SerializeField]
    private GameObject rolarDado;



    // Use this for initialization
    private void Start()
    {

    }

    public void initDado()
    {
        if (players.GetComponent<MvP1>().getDadoMaior())
        {
            dadoD8.transform.position = rolarDado.transform.position + new Vector3(0, 0, 1);
            dadoD6.transform.position = new Vector3(3000, 3000, 0);
        }
        else
        {
            dadoD6.transform.position = GameObject.Find("rolarDado").transform.position + new Vector3(0, 0, 1);
            dadoD8.transform.position = new Vector3(3000, 3000, 0);
        }
    }
}

