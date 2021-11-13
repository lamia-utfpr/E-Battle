using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class mostrarDado : MonoBehaviour
{

    [SerializeField]
    private GameObject cameraTab;

    [SerializeField]
    private GameObject telaDado;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mover(int op) {
        if (op == 2) {
            //this.transform.position = new Vector3(2000, 2000, 0);
            this.transform.position = cameraTab.transform.position + new Vector3(2000, 2000, 0);
        }
        if (op == 1) {
            this.transform.position = cameraTab.transform.position + new Vector3(0, 0, 1);

        }
        telaDado.GetComponent<Dado>().initDado();
    }

    public void retirarDado(){
        this.transform.position = new Vector3(2000, 2000, 0);
    }
}
