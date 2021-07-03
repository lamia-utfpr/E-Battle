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


    public void verificarEusarPowerUp(){
        nome = this.transform.Find("Text").GetComponent<Text>().text;

        if (String.Equals(nome, "Aumentar tempo")){
            powerUp_tempoMaior.aumentarTempo();

        }else if (String.Equals(nome, "Dado maior")){
            powerUp_dadoMaior.aumentarDado();
        }else if (String.Equals(nome, "Eliminar alternativas")){
            string[] alternativasAtuais = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuais();
            int qtd_corretas = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().get_qtsCorretas();

            
            //verificando se há mais de 2 alternativas e se a quantia de alternativas é maior que a quantia de corretas + 1
            //por exemplo, se tiver 3 alternativas e 2 marcadas como corretas, a unica errada não será removida, pois irá tirar a parte de "punição" pelo jogador ter errado

            if (alternativasAtuais.Length > 2 && alternativasAtuais.Length > (qtd_corretas+1) ){
                powerUp_eliminarAlternativas.eliminarAlternativas();
            }
            
        }else if (String.Equals(nome, "Empurrar um player")){
            //seta a ação pra empurrar o player escolhido
            GameObject.Find("tabela_players").GetComponent<setarTabelaPlayers>().setarAcao(1);
            GameObject.Find("tabela_players").GetComponent<setarTabelaPlayers>().transform.position = GameObject.Find("painel_Pergunta").transform.position + new Vector3(0, 300, 0);
        }

        this.GetComponent<Button>().interactable = false;
        
        removerPowerUp();
    }


    private void removerPowerUp(){
        
        GameObject playerAtual = GameObject.Find("Players").GetComponent<MvP1>().getJogAtual();
        
        List<string> powerupsNovos = new List<string>(); 

        List<string> powerupsVelhos = new List<string>();
        powerupsVelhos = playerAtual.GetComponent<Player>().getListaPowerUps();
        
        int indiceParou = 0;

        for (int i = 0; i < powerupsVelhos.Count; i++){
            if (powerupsVelhos[i] == nome){
                indiceParou = i;
                break;
            }
            else
            {
                powerupsNovos.Add(powerupsVelhos[i]);
            }
        }

        for (int i = indiceParou+1; i < powerupsVelhos.Count; i++)
            powerupsNovos.Add(powerupsVelhos[i]);


        playerAtual.GetComponent<Player>().atualizarListaPowerUps(powerupsNovos);


    }

}
