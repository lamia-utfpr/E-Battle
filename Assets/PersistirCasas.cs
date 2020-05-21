using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistirCasas : MonoBehaviour
{

    private static GameObject[] casas;

    public void Awake()
    {
        if(casas == null)
        {
            casas = GameObject.FindGameObjectsWithTag("Casas");
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyObject(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
