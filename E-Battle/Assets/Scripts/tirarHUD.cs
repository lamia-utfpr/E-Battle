using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarHUD : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject mostraInfo;

    [SerializeField]
    private GameObject cameraTab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tirarHud(){
        mostraInfo.transform.position = cameraTab.transform.position + new Vector3(-1500, 1500, 0);
        mostraInfo.GetComponent<apresentarInfoPlayerAtual>().zerarHUD();
    }

}
