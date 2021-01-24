using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class selecionar_tema : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nome_tema;
    public Button pesquisarTemas;
    public GameObject pesquisar;

    void Start()
    {
        nome_tema.text ="Nenhum";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarPainelPesquisa(){
        pesquisar.transform.position = new Vector3(400, 120, 0);
    }
}
