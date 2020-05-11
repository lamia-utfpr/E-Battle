using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MvP1 : MonoBehaviour
{
    public int[] casaAtual;
    public GameObject[] casas;
    public int num;
    float novoX;
    float novoY;
    public float Speed = 40f;
    public GameObject[] players;
    public int jogadorAtual;

    // Start is called before the first frame update
    void Start()
    {
        jogadorAtual = 0;
        PlayerPrefs.SetInt("Valor do Dado", 5);
        casas = GameObject.FindGameObjectsWithTag("Casas");
        players = GameObject.FindGameObjectsWithTag("Player");
        casaAtual = new int[players.Length];      
    }
    //Aqui, criamos um vetor de casas que ira nos guiar pelo tabuleiro
    //Um vetor de players para sabermos qual jogador tera sua vez
    //E um vetor de casas atuais, que possui o mesmo tamanho do vetor de players
    //que serve para descobrirmos a posição individual de cada jogador no tabuleiro




    // Update is called once per frame
    void Update()
    {
        num = PlayerPrefs.GetInt("Valor do Dado");
    }


    //Comentar com o thiago sobre este possivel CRIME de vetores
    //sempre que nos referirmos a casas[casaAtual[jogadorAtual]] estamos nos referindo a posição atual do jogador da vez
    //dentro do tabuleiro, e usando este valor.

    public void Mover()
    {
        num = PlayerPrefs.GetInt("Valor do Dado");
        casaAtual[jogadorAtual] += num;
        if ((casaAtual[jogadorAtual]) >= 19)
        {
            casaAtual[jogadorAtual] = 19;
            novoX = ((casas[casaAtual[jogadorAtual]].transform.position.x) - 14);
            novoY = ((casas[casaAtual[jogadorAtual]].transform.position.y) - 6);
            players[jogadorAtual].transform.position = new Vector3(novoX, novoY, 0);
            SceneManager.LoadScene("Cena De vitoria", LoadSceneMode.Single);
        }
        novoX = casas[casaAtual[jogadorAtual]].transform.position.x;
        novoY = casas[casaAtual[jogadorAtual]].transform.position.y;
        players[jogadorAtual].transform.position = new Vector3(novoX, novoY, 0);
        jogadorAtual++;
        if(jogadorAtual == 4)
        {
            jogadorAtual = 0;
        }
    }

}
