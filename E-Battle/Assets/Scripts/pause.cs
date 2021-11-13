using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class pause : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject menuEsc;

    [SerializeField]
    private GameObject cameraTab;

    bool menu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!menu){
                menuEsc.transform.position = cameraTab.transform.position + new Vector3(0, 0, 1);
                menu = true;
            }else{
                menuEsc.transform.position = new Vector3(3000, 0, 0);
                menu = false;
            }
                
        }
    }

    public void voltarMenu(){
        SceneManager.LoadScene("Tela Inicial", LoadSceneMode.Single);
    }

    public void sairJogo(){
        Application.Quit();
    }

    public void continuar(){
        menu = false;
        menuEsc.transform.position = new Vector3(3000, 0, 0);
    }
}
