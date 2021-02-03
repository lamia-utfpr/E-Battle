using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelar_escolhaTema : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cancelarEscolha(){
        GameObject.Find("tema_selecionado/selecionar_tema").GetComponent<selecionar_tema>().tirarPainelPesquisa();
    }
}
