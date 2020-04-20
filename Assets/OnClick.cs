using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class OnClick : MonoBehaviour
{
    public Button botao;
    public Text nGerado;
    public int numero;
    public MvP1 move1;
    public MvP2 move2;
    public MvP3 move3;
    public MvP4 move4;
    public GameObject[] players;
    public int jog;
    public InputField tema;
    public string temas;

    // Start is called before the first frame update
    void Start()
    {
        
        //jog = 0;
        //Button btn = botao.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);   
        /*move1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<MvP1>();
        move2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<MvP2>();
        move3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<MvP3>();
        move4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<MvP4>();*/
    }
    public void telaInicial()
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)
    }


    /*public void inserirTema(){
        Text tema = GameObject.Find("Entrada - tema").GetComponent<Text> ();

        //input field não está pegando o texto inserido
        
        if (tema == null)
            Debug.Log("A");
        else
            Debug.Log("B");
    }*/

    public void TelaDePerguntas() {
        SceneManager.LoadSceneAsync("Perguntas", LoadSceneMode.Single);
    }


    public void CriarPerguntas()
    {
        SceneManager.LoadScene("Criação de perguntas", LoadSceneMode.Single);
    }

    public void CriarTema()
    {
        temas = tema.text;
        //determina o local de criação das perguntas, registrando o txt com o nome do tema
        string path = Application.dataPath +"/"+ temas + ".txt";

        //Se o arquivo tema não existir, vai criar um arquivo com o tema
        if (!File.Exists(path))
        {
            File.WriteAllText(path,"Perguntas com o tema "+temas);
        }
    }

    public void Sair(){
        Application.Quit();
    }

    public void AcertoDePergunta()
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }

    public void ErroDePergunta()
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }
    
    public void TaskOnClick() {
        //SceneManager.LoadScene(3, LoadSceneMode.Additive);      //O indice 2 é sobre a cena que faz as perguntas.
        /*numero = Random.Range(1, 5);
        switch (jog)
        {
            case 0:
                move1.Mover();
                break;
            case 1:
                move2.Mover();
                break;
            case 2:
                move3.Mover();
                break;
            case 3:
                move4.Mover();
                break;
        }
        if(jog == 3)
        {
            jog = -1;
        }
        jog++;*/
    }

    // Update is called once per frame
    void Update()
    {
  
    }


}
