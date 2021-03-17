using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicaoInicialCameraTabuleiro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Camera_Tabuleiro").transform.localScale = new Vector3(1.6f, 1.6f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
