using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class tabela : MonoBehaviour
{
    // Start is called before the first frame update

    void Start(){

        //inicializando a tabela
        Image imagem = GetComponent<Image>();
        imagem.color = new Color(0, 0, 0, 0); 
        
        //inicializando nome do tema

        Image nome_tema = this.transform.Find("nome_tema").GetComponent<Image>();
        nome_tema.color = new Color(0, 0, 0, 0);

        Text nome_temaTexto = this.transform.Find("nome_tema/nome_tema").GetComponent<Text>();
        nome_temaTexto.color = new Color(0, 0, 0, 0);
        

        Image acao_tema = this.transform.Find("nome_tema/Imagem").GetComponent<Image>();
        acao_tema.color = new Color(255, 255, 255, 0);

        Text acao_temaTexto = this.transform.Find("nome_tema/acao_tema").GetComponent<Text>();
        acao_temaTexto.color = new Color(0, 0, 0, 0);

        inicializarAlt1();
        inicializarAlt2();
        inicializarAlt3();
        inicializarAlt4();
        inicializarAlt5();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void inicializarAlt1(){
        Image fundo_alternativa1 = this.transform.Find("alt_1").GetComponent<Image>();
        fundo_alternativa1.color = new Color(255, 255, 255, 0);

        Text texto_alternativa1 = this.transform.Find("alt_1/Text").GetComponent<Text>();
        texto_alternativa1.text = "";

        
        Toggle toogle1 = this.transform.Find("alt_1/Toggle").GetComponent<Toggle>();
        toogle1.isOn = false;
        Image toggleImage = this.transform.Find("alt_1/Toggle/Background").GetComponent<Image>();
        toggleImage.color = new Color(255, 255, 255, 0);
        Text toggleText = this.transform.Find("alt_1/Toggle/Label").GetComponent<Text>();
        toggleText.text = "";

    }

    private void inicializarAlt2(){
        Image fundo_alternativa1 = this.transform.Find("alt_2").GetComponent<Image>();
        fundo_alternativa1.color = new Color(255, 255, 255, 0);

        Text texto_alternativa1 = this.transform.Find("alt_2/Text").GetComponent<Text>();
        texto_alternativa1.text = "";

        
        Toggle toogle1 = this.transform.Find("alt_2/Toggle").GetComponent<Toggle>();
        toogle1.isOn = false;
        Image toggleImage = this.transform.Find("alt_2/Toggle/Background").GetComponent<Image>();
        toggleImage.color = new Color(255, 255, 255, 0);
        Text toggleText = this.transform.Find("alt_2/Toggle/Label").GetComponent<Text>();
        toggleText.text = "";
    }

    private void inicializarAlt3(){
        Image fundo_alternativa1 = this.transform.Find("alt_3").GetComponent<Image>();
        fundo_alternativa1.color = new Color(255, 255, 255, 0);

        Text texto_alternativa1 = this.transform.Find("alt_3/Text").GetComponent<Text>();
        texto_alternativa1.text = "";

        
        Toggle toogle1 = this.transform.Find("alt_3/Toggle").GetComponent<Toggle>();
        toogle1.isOn = false;
        Image toggleImage = this.transform.Find("alt_3/Toggle/Background").GetComponent<Image>();
        toggleImage.color = new Color(255, 255, 255, 0);
        Text toggleText = this.transform.Find("alt_3/Toggle/Label").GetComponent<Text>();
        toggleText.text = "";
    }

    private void inicializarAlt4(){
        Image fundo_alternativa1 = this.transform.Find("alt_4").GetComponent<Image>();
        fundo_alternativa1.color = new Color(255, 255, 255, 0);

        Text texto_alternativa1 = this.transform.Find("alt_4/Text").GetComponent<Text>();
        texto_alternativa1.text = "";

        
        Toggle toogle1 = this.transform.Find("alt_4/Toggle").GetComponent<Toggle>();
        toogle1.isOn = false;
        Image toggleImage = this.transform.Find("alt_4/Toggle/Background").GetComponent<Image>();
        toggleImage.color = new Color(255, 255, 255, 0);
        Text toggleText = this.transform.Find("alt_4/Toggle/Label").GetComponent<Text>();
        toggleText.text = "";
    }

    private void inicializarAlt5(){
        Image fundo_alternativa1 = this.transform.Find("alt_5").GetComponent<Image>();
        fundo_alternativa1.color = new Color(255, 255, 255, 0);

        Text texto_alternativa1 = this.transform.Find("alt_5/Text").GetComponent<Text>();
        texto_alternativa1.text = "";

        
        Toggle toogle1 = this.transform.Find("alt_5/Toggle").GetComponent<Toggle>();
        toogle1.isOn = false;
        Image toggleImage = this.transform.Find("alt_5/Toggle/Background").GetComponent<Image>();
        toggleImage.color = new Color(255, 255, 255, 0);
        Text toggleText = this.transform.Find("alt_5/Toggle/Label").GetComponent<Text>();
        toggleText.text = "";
    }

}
