using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class toggleRet2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void statusToggle2(){
        if (this.GetComponent<Toggle>().isOn == true){
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().statusToggle2(1);
        }else if (this.GetComponent<Toggle>().isOn == false){
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().statusToggle2(0);
        }
    }
}
