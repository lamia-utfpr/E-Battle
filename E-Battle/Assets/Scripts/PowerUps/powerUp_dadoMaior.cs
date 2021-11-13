using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp_dadoMaior
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject players;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void aumentarDado(){
        GameObject.Find("Players").GetComponent<MvP1>().setDadoMaior(true);
    }


}
