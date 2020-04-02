using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MvP1 : MonoBehaviour
{
    public int casaAtual;
    public GameObject[] casas;
    public int num;
    float novoX;
    float novoY;
    public float Speed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        casaAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        num = GameObject.Find("Botao").GetComponent<OnClick>().numero;
    }

    public void Mover()
    {
        num = GameObject.Find("Botao").GetComponent<OnClick>().numero;
        casaAtual += num;
        if ((casaAtual) >= 19)
        {
            casaAtual = 19;
            novoX = ((casas[casaAtual].transform.position.x) - 14);
            novoY = ((casas[casaAtual].transform.position.y) - 6);
            transform.position = new Vector3(novoX, novoY, 0);
            SceneManager.LoadScene("Cena De vitoria", LoadSceneMode.Single);
        }
        novoX = casas[casaAtual].transform.position.x;
        novoY = casas[casaAtual].transform.position.y;
        transform.position = new Vector3(novoX, novoY, 0);
    }


}
