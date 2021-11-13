using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inserirPergunta : MonoBehaviour
{
    // Start is called before the first frame update

    private bool altVazia = false;

    [SerializeField]
    private AudioSource som;

    [SerializeField]
    private AudioClip sombotao;

    [SerializeField]
    private GameObject alt1;

    [SerializeField]
    private GameObject alt2;

    [SerializeField]
    private GameObject alt3;

    [SerializeField]
    private GameObject alt4;

    [SerializeField]
    private GameObject slider;

    public void set_altVazia(bool altvazia){
        altVazia = altvazia;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inserirPergunt(){
        alt1.GetComponent<verificarAltVazia>().verificar();
        alt2.GetComponent<verificarAltVazia>().verificar();
        alt3.GetComponent<verificarAltVazia>().verificar();
        alt4.GetComponent<verificarAltVazia>().verificar();

        if (!altVazia)
        slider.GetComponent<slider_value>().inserirPergunta();

        som.clip = sombotao;
        som.Play();

    }

}
