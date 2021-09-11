using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class usarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update

    string nome;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void verificarEusarPowerUp()
    {
        nome = this.transform.Find("Text").GetComponent<Text>().text;

        string nomeCerto = nome.Substring(0, nome.IndexOf('x') - 1);

        if (String.Equals(nomeCerto, "Aumentar tempo"))
        {
            powerUp_tempoMaior.aumentarTempo();

        }
        else if (String.Equals(nomeCerto, "Dado maior"))
        {
            powerUp_dadoMaior.aumentarDado();
        }
        else if (String.Equals(nomeCerto, "Eliminar alternativas"))
        {
            string[] alternativasAtuais = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuais();
            int qtd_corretas = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().get_qtsCorretas();


            //verificando se há mais de 2 alternativas e se a quantia de alternativas é maior que a quantia de corretas + 1
            //por exemplo, se tiver 3 alternativas e 2 marcadas como corretas, a unica errada não será removida, pois irá tirar a parte de "punição" pelo jogador ter errado

            if (alternativasAtuais.Length > 2 && alternativasAtuais.Length > (qtd_corretas + 1))
            {
                powerUp_eliminarAlternativas.eliminarAlternativas();
            }

        }
        else if (String.Equals(nomeCerto, "Empurrar um player"))
        {
            //seta a ação pra empurrar o player escolhido
            powerUp_empurrarOutroPlayer.empurrar();

        }
        else if (String.Equals(nomeCerto, "Prender jogador"))
        {
            //seta a ação para prender o jogador escolhido
            powerUp_prenderPlayer.prender();
        }

        this.GetComponent<Button>().interactable = false;

        removerPowerUp();
    }


    private void removerPowerUp()
    {
        GameObject playerAtual = GameObject.Find("Players").GetComponent<MvP1>().getJogAtual();
        Dictionary<string, int> powerupsNovos = playerAtual.GetComponent<Player>().getListaPowerUps();

        string chave = nome.Substring(0, nome.IndexOf('x') - 1);

        if (powerupsNovos[chave] - 1 == 0)
            powerupsNovos.Remove(chave);
        else
            powerupsNovos[chave]--;

        playerAtual.GetComponent<Player>().atualizarListaPowerUps(powerupsNovos);
    }

}
