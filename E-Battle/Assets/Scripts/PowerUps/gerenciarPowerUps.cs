using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class gerenciarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update


    private GameObject pw1;
    private GameObject pw2;
    private GameObject pw3;
    private GameObject pw4;

    private GameObject dadoMaior;
    private GameObject maisTempo;

    private GameObject elimAlt;

    private GameObject prenderJogador;

    void Start()
    {
        pw1 = GameObject.Find("Pw1");
        pw2 = GameObject.Find("Pw2");
        pw3 = GameObject.Find("Pw3");
        pw4 = GameObject.Find("Pw4");

        dadoMaior = GameObject.Find("pw_Dado maior");
        maisTempo = GameObject.Find("pw_Aumentar tempo");
        elimAlt = GameObject.Find("pw_Eliminar alternativas");
        prenderJogador = GameObject.Find("pw_Prender jogador");

        zerarPws();
    }

    public void verificarPowerUpsDisponiveis(GameObject player)
    {

        Dictionary<string, int> powerups = player.GetComponent<Player>().getListaPowerUps();
        int i = 0;

        if (powerups != null)
        {
            foreach (KeyValuePair<string, int> entry in powerups)
            {
                this.transform.Find("Pw" + (i + 1)).gameObject.SetActive(true);
                this.transform.Find("Pw" + (i + 1)).GetComponent<Button>().interactable = true;
                this.transform.Find("Pw" + (i + 1) + "/Text").GetComponent<Text>().text = entry.Key + " x" + entry.Value;

                if (String.Equals(entry.Key, "Eliminar alternativas"))
                {
                    string[] alternativasAtuais = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuais();
                    int qtd_corretas = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().get_qtsCorretas();

                    if (alternativasAtuais.Length <= 2 || alternativasAtuais.Length <= (qtd_corretas + 1))
                    {
                        this.transform.Find("Pw" + (i + 1)).GetComponent<Button>().interactable = false;
                    }
                }
                if (dadoMaior.name.Equals("pw_" + entry.Key))
                {
                    dadoMaior.gameObject.SetActive(true);
                    dadoMaior.transform.position =
                    this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (maisTempo.name.Equals("pw_" + entry.Key))
                {
                    maisTempo.gameObject.SetActive(true);
                    maisTempo.transform.position =
                                        this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (elimAlt.name.Equals("pw_" + entry.Key))
                {
                    elimAlt.gameObject.SetActive(true);
                    elimAlt.transform.position =
                                        this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (prenderJogador.name.Equals("pw_" + entry.Key))
                {
                    prenderJogador.gameObject.SetActive(true);
                    prenderJogador.transform.position =
                                        this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }

                i++;
            }
        }
    }
    public void zerarPws()
    {
        zerarPw1();
        zerarPw2();
        zerarPw3();
        zerarPw4();
        dadoMaior.gameObject.SetActive(false);
        maisTempo.gameObject.SetActive(false);
        elimAlt.gameObject.SetActive(false);
        prenderJogador.gameObject.SetActive(false);
    }

    public void zerarPw1()
    {
        pw1.gameObject.SetActive(false);
    }


    public void zerarPw2()
    {
        pw2.gameObject.SetActive(false);
    }

    public void zerarPw3()
    {
        pw3.gameObject.SetActive(false);
    }


    public void zerarPw4()
    {
        pw4.gameObject.SetActive(false);
    }
}
