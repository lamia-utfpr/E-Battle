using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistir : MonoBehaviour
{

    private static GameObject[] players;


    public void Awake()
    {
        if(players == null)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
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
