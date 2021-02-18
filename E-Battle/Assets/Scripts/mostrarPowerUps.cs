using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrarPowerUps : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrar(){
       GameObject.Find("powerups").transform.position = this.transform.position + new Vector3(200, 200, 0);
       GameObject.Find("powerups").GetComponent<gerenciarPowerUps>().verificarPowerUpsDisponiveis(GameObject.Find("Players").GetComponent<MvP1>().getJogAtual());
    }
}
