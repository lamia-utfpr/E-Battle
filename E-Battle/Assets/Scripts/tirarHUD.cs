using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tirarHud(){
        GameObject.Find("mostrarInfosJogador").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(-1500, 1500, 0);
        GameObject.Find("mostrarInfosJogador").GetComponent<apresentarInfoPlayerAtual>().zerarHUD();
    }

}
