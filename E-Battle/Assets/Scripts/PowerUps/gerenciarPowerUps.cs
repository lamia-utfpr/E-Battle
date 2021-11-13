using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class gerenciarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] pw;

<<<<<<< Updated upstream
    private Button pw1;
    private Button pw2;
    private Button pw3;
    private Button pw4;
=======
    [SerializeField]
    private GameObject dadoMaior;

    [SerializeField]
    private GameObject maisTempo;

    [SerializeField]
    private GameObject elimAlt;

    [SerializeField]
    private GameObject prenderJogador;
>>>>>>> Stashed changes

    [SerializeField]
    private GameObject painelpergunta;

    void Start()
    {
<<<<<<< Updated upstream
        zerarPws();
    }

    // Update is called once per frame
    void Update()
    {
=======
>>>>>>> Stashed changes

    }


    public void verificarPowerUpsDisponiveis(GameObject player)
    {

        Dictionary<string, int> powerups = player.GetComponent<Player>().getListaPowerUps();
        int i = 0;

        if (powerups != null)
        {
            foreach (KeyValuePair<string, int> entry in powerups)
            {
<<<<<<< Updated upstream
                this.transform.Find("Pw" + (i + 1)).GetComponent<Image>().color = new Color(255, 255, 255, 1);
                this.transform.Find("Pw" + (i + 1) + "/Text").GetComponent<Text>().text = entry.Key + " x" + entry.Value;
                this.transform.Find("Pw" + (i + 1)).GetComponent<Button>().interactable = true;
=======
                pw[i].gameObject.SetActive(true);
                pw[i].GetComponent<Button>().interactable = true;
                pw[i].GetComponentInChildren<Text>().text = entry.Key + " x" + entry.Value;
                //this.transform.Find("Pw" + (i + 1) + "/Text").GetComponent<Text>().text = entry.Key + " x" + entry.Value;
>>>>>>> Stashed changes

                if (String.Equals(entry.Key, "Eliminar alternativas"))
                {
                    string[] alternativasAtuais = painelpergunta.GetComponent<apresentarPergunta>().getAlternativasAtuais();
                    int qtd_corretas = painelpergunta.GetComponent<apresentarPergunta>().get_qtsCorretas();

                    if (alternativasAtuais.Length <= 2 || alternativasAtuais.Length <= (qtd_corretas + 1))
                    {
                        pw[i].GetComponent<Button>().interactable = false;
                    }
                }
<<<<<<< Updated upstream
                GameObject.Find("pw_" + entry.Key).transform.position = this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width/4 * -1 + 20), 0, 0);
=======
                if (dadoMaior.name.Equals("pw_" + entry.Key))
                {
                    dadoMaior.gameObject.SetActive(true);
                    dadoMaior.transform.position =
                    pw[i].transform.position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (maisTempo.name.Equals("pw_" + entry.Key))
                {
                    maisTempo.gameObject.SetActive(true);
                    maisTempo.transform.position =
                                        pw[i].transform.position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (elimAlt.name.Equals("pw_" + entry.Key))
                {
                    elimAlt.gameObject.SetActive(true);
                    elimAlt.transform.position =
                                        pw[i].transform.position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
                else if (prenderJogador.name.Equals("pw_" + entry.Key))
                {
                    prenderJogador.gameObject.SetActive(true);
                    prenderJogador.transform.position =
                                        pw[i].transform.position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width / 4 * -1 + 20), 0, 0);
                }
>>>>>>> Stashed changes

                i++;
            }
        }
    }
    public void zerarPws()
    {
<<<<<<< Updated upstream
        zerarPw1();
        zerarPw2();
        zerarPw3();
        zerarPw4();
    }

    public void zerarPw1()
    {
        pw1 = this.transform.Find("Pw1").GetComponent<Button>();
        this.transform.Find("Pw1/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw1").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw2()
    {
        pw2 = this.transform.Find("Pw2").GetComponent<Button>();
        this.transform.Find("Pw2/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw2").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void zerarPw3()
    {
        pw3 = this.transform.Find("Pw3").GetComponent<Button>();
        this.transform.Find("Pw3/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw3").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }


    public void zerarPw4()
    {
        pw4 = this.transform.Find("Pw4").GetComponent<Button>();
        this.transform.Find("Pw4/Text").GetComponent<Text>().text = "";
        this.transform.Find("Pw4").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
=======
        pw[1].gameObject.SetActive(false);
        pw[2].gameObject.SetActive(false);
        pw[3].gameObject.SetActive(false);
        pw[4].gameObject.SetActive(false);
        dadoMaior.gameObject.SetActive(false);
        maisTempo.gameObject.SetActive(false);
        elimAlt.gameObject.SetActive(false);
        prenderJogador.gameObject.SetActive(false);
    }

>>>>>>> Stashed changes
}
