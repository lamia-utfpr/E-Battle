using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class gerenciarPowerUps : MonoBehaviour
{
    // Start is called before the first frame update


    private Button pw1;
    private Button pw2;
    private Button pw3;
    private Button pw4;

    void Start()
    {
        zerarPws();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void verificarPowerUpsDisponiveis(GameObject player)
    {

        Dictionary<string, int> powerups = player.GetComponent<Player>().getListaPowerUps();
        int i = 0;

        if (powerups != null)
        {
            foreach (KeyValuePair<string, int> entry in powerups)
            {
                this.transform.Find("Pw" + (i + 1)).GetComponent<Image>().color = new Color(255, 255, 255, 1);
                this.transform.Find("Pw" + (i + 1) + "/Text").GetComponent<Text>().text = entry.Key + " x" + entry.Value;
                this.transform.Find("Pw" + (i + 1)).GetComponent<Button>().interactable = true;

                if (String.Equals(entry.Key, "Eliminar alternativas"))
                {
                    string[] alternativasAtuais = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuais();
                    int qtd_corretas = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().get_qtsCorretas();

                    if (alternativasAtuais.Length <= 2 || alternativasAtuais.Length <= (qtd_corretas + 1))
                    {
                        this.transform.Find("Pw" + (i + 1)).GetComponent<Button>().interactable = false;
                    }
                }
                GameObject.Find("pw_" + entry.Key).transform.position = this.transform.Find("Pw" + (i + 1)).position + new Vector3((this.transform.Find("Pw" + (i + 1)).GetComponent<RectTransform>().rect.width/4 * -1 + 20), 0, 0);

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
}
