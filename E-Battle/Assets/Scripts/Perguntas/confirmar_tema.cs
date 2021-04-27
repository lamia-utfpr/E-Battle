using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class confirmar_tema : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void confirmarTema(){
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().confirmar_tema();
    }


    public void temaPartida(){
        GameObject.Find("tabela").GetComponent<tabelaDosTemas>().confirmar_temaPartida();
        GameObject.Find("Players").GetComponent<MvP1>().set_quantiaPlayers(GameObject.Find("quantia_jogadores_slider").GetComponent<slider_quantiaplayer>().getValorSlider());
        GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().setTempoMaximo(GameObject.Find("config_jogo/quantia_tempo_slider").GetComponent<Slider>().value+1);
        GameObject.Find("controlar_spawn_powerups").GetComponent<controlarSpawnPowerUps>().preencherCasas();
        GameObject.Find("config_jogo").transform.position = new Vector3(3000, 3000, 0);
        GameObject.Find("Camera_Tabuleiro").transform.localScale = new Vector3(3.5f, 3.5f, 1);

    }
}
