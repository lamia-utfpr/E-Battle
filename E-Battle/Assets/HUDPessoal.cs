using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPessoal : MonoBehaviour
{
    GameObject[] players;
    public Text identificador;
    public Text powerups;
    public Text dado;
    public Text tempo;
    public Text alternativa;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        identificador.text = "Turno do Jogador " + (PlayerPrefs.GetInt("jogadoratual") + 1);
        powerups.text = "Powerups Disponíveis: ";
        Debug.Log(PlayerPrefs.GetInt("jogadoratual"));
        checarpowerups();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void checarpowerups()
    {
        if (players[PlayerPrefs.GetInt("jogadoratual")].GetComponent<QuantiaPower>().dadoMaior)
        {
            dado.text = "Disponível.";
        }
        else
        {
            dado.text = "Indisponível.";
        }

        if (players[PlayerPrefs.GetInt("jogadoratual")].GetComponent<QuantiaPower>().maisTempo)
        {
            tempo.text = "Disponível.";
        }
        else
        {
            tempo.text = "Indisponível.";
        }

        if (players[PlayerPrefs.GetInt("jogadoratual")].GetComponent<QuantiaPower>().eliminaAlternativa)
        {
            alternativa.text = "Disponível.";
        }
        else
        {
            alternativa.text = "Indisponível.";
        }

    }

}
