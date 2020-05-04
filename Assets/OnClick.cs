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
    public InputField pergunta;
    public InputField respostaCerta;
    public InputField alternativaErrada;
    public string path;

    // Start is called before the first frame update
    void Start()
    {
        
        if (SceneManager.GetActiveScene().name == "Apresentar perguntas"){
            mostrarPergunta();
        }

        //jog = 0;
        //Button btn = botao.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);   
        /*move1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<MvP1>();
        move2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<MvP2>();
        move3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<MvP3>();
        move4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<MvP4>();*/
    }

    //Este bloco de códigos contém todos os códigos responsáveis por mudança de cenas.

    
    public void telaInicial()   // transição entre a tela inicial e a tela do tabuleiro do jogo
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)
    }


    public void TelaDePerguntas()  // transição entre a tela do tabuleiro e a tela de apresentação de perguntas
    {
        SceneManager.LoadSceneAsync("Perguntas", LoadSceneMode.Single);
    }


    public void CriarPerguntas()  //  transição entre a tela inicial e a tela onde será criado o tema do txt.
    {
        SceneManager.LoadScene("Criação de perguntas", LoadSceneMode.Single);
    }


    public void AcertoDePergunta()  //  transição após o jogador acertar a pergunta, voltando para o tabuleiro
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }


    public void ErroDePergunta()  //  transição após o jogador errar a pergunta, voltando para o tabuleiro
    {
        SceneManager.LoadScene("Tabuleiro", LoadSceneMode.Single);
    }
    // Fim do bloco de transição de perguntas



    // Bloco de código que lidam com a customização dos txt


    public void CriarTema()  // Este bloco é responsavel pela criação do txt com o tema criado pelo professor
    {

        temas = tema.text;
        //determina o local de criação das perguntas, registrando o txt com o nome do tema
        path = Application.dataPath + "/temas/" + temas + ".txt";
        PlayerPrefs.SetString("path", path);

        //Se o arquivo tema não existir, vai criar um arquivo com o tema
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Perguntas com o tema " + temas + "\n");
        }
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }


    public void adicionarPergunta()  //  Este bloco eziste na tela "Criação da pergunta e Resposta" e ele adiciona a pergunta e a resposta correta ao txt
    {
        path = PlayerPrefs.GetString("path");
        File.AppendAllText(path, pergunta.text + "; " + respostaCerta.text + ";\n");
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }

    public void adicionarAlternativa()  //  Este bloco adiciona a pergunta e resposta correta ao txt e após isso vai para a tela de adicionar uma alternativa extra
    {
        path = PlayerPrefs.GetString("path");
        File.AppendAllText(path, pergunta.text + "; " + respostaCerta.text + "; ");
        SceneManager.LoadSceneAsync("Criação de Alternativa", LoadSceneMode.Single);
    }

    public void adicionarAlternativaErrada()  // Este bloco existe na tela Criação de alternativa e adiciona uma alternativa incorreta ao txt
    {
        path = PlayerPrefs.GetString("path");
        File.AppendAllText(path, alternativaErrada.text + "; \n");
        SceneManager.LoadScene("Criação da Pergunta e Resposta", LoadSceneMode.Single);
    }

    public void adicionarAlternativaExtra()  // Este bloco existe na tela Criação de alternativa e adiciona uma alternativa incorreta ao txt e volta para a mesma tela
    {
        path = PlayerPrefs.GetString("path");
        File.AppendAllText(path, alternativaErrada.text + "; ");
        SceneManager.LoadScene("Criação de Alternativa", LoadSceneMode.Single);
    }


    public void mostrarPergunta(){  //  Este bloco apresenta a pergunta do txt na interface
        
        path = PlayerPrefs.GetString("path");
        
        FileInfo fi = new FileInfo (path);

        StreamReader reader = fi.OpenText();

        string s;
        GameObject.Find("PerguntaTela").GetComponent<Text>().text = null;

         while ( (s = reader.ReadLine()) != null){
            string aux = GameObject.Find("PerguntaTela").GetComponent<Text>().text + s;
            
            aux.Replace(";", "\n"); //Função de replace pra substituir ; por quebra de linha não está funcionando
            
            GameObject.Find("PerguntaTela").GetComponent<Text>().text = aux;
        }
           
        
    }

    /*public void inserirTema(){
        Text tema = GameObject.Find("Entrada - tema").GetComponent<Text> ();

        //input field não está pegando o texto inserido
        
        if (tema == null)
            Debug.Log("A");
        else
            Debug.Log("B");
    }*/


    public void Sair(){
        Application.Quit();
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
        if (SceneManager.GetActiveScene().name == "Apresentar perguntas")
        {
            mostrarPergunta();
        }
    }


}
