using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void voltar(){
        
        GameObject.Find("powerups").transform.position = new Vector3(-1000, 550, 0);

    }
}
