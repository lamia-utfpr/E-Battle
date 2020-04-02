using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void telaInicial() {
        SceneManager.LoadScene("Tabuleiro "); //Ao clicar no botão, ele sai da tela inicial(tela 0) e vai para tela do jogo(tela 1)
    }
}
