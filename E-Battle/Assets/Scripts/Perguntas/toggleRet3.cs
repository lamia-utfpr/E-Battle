﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
public class toggleRet3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public bool getStatus()
    {
        return this.GetComponent<Toggle>().isOn;
    }


    public void statusToggle3()
    {
        if (this.GetComponent<Toggle>().isOn == true)
        {
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().statusToggle3(1);
        }
        else if (this.GetComponent<Toggle>().isOn == false)
        {
            GameObject.Find("tabela").GetComponent<tabelaDosTemas>().statusToggle3(0);
        }
    }
}
