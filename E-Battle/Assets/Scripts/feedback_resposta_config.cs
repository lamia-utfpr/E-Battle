using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback_resposta_config : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("painel_Pergunta").transform.position = GameObject.Find("Camera_Tabuleiro").transform.position + new Vector3(0, 2000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
