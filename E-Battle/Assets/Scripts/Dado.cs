using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour
{

    //Vetor dos Sprites presentes no dado
    private Sprite[] lados;

    // Referencia ao renderizador de sprites para podermos alterar a sprite
    private SpriteRenderer rend;
    private int tamanho;
    private bool interativo;
    
    // Use this for initialization
    private void Start()
    {

        // Setando o renderizador de sprites
        rend = GetComponent<SpriteRenderer>();

        // Faz com que os sprites dos lados do dado sejam carregados a partir da pasta
        
    }

    // O dado é rolado ao clicar sobre o mesmo
    private void OnMouseDown()
    {
        if (interativo == true)
        {
            interativo = false;
            StartCoroutine("RolarDado");
        }
    }

    public void initDado(){

        if (GameObject.Find("Players").GetComponent<MvP1>().getDadoMaior()){
            lados = Resources.LoadAll<Sprite>("d10/");
            tamanho = 10;
        }
        else{
            lados = Resources.LoadAll<Sprite>("d6/");
            tamanho = 6;
        }

        interativo = true;
        rend.sprite = lados[0];

    }

    // Função que faz a rolagem do dado
    private IEnumerator RolarDado()
    {
       
        int randomDiceSide = 0; //Rolagem do dado
        int ladoFinal = 0; //Armazena valor final do dado
        int interações = 4;
        float TimeAction = 0.7f; // Tempo de rolagem

        // Este loop irá alterar os sprites dos dados de acordo com suas posições
        // o dado terá 20 interações de mudança de lado, este valor pode ser alterado
        for (int i = 0; i <= interações; i++)
        {   //colocar pause em alguma linha antes de chegar no return
            // Escolhemos um dos 6 lados do dado para ser o presente desta interação


            randomDiceSide = Random.Range(0, tamanho);

            // O sprite do dado é alterado na tela
            rend.sprite = lados[randomDiceSide];

            // Tempo de pausa entre cada interação e mudança na face do dado
            yield return new WaitForSeconds(TimeAction);

           // yield return new WaitForSecondsRealtime(6);
        }

        //yield return new WaitForSecondsRealtime(1); ??????????
        // Aqui faremos com que o valor final seja armazenado na variavel ladoFinal
        // e será armazenada tbm no valor do dado das preferencias do jogador para uso de movimentação futura.
        
        ladoFinal = randomDiceSide += 1;
        Debug.Log("Você tirou o número " + ladoFinal);
        GameObject.Find("rolarDado").GetComponent<mostrarDado>().retirarDado();

        //só trocar aqui pela função mover(ladoFinal) pra voltar ao que era antes
        GameObject.Find("Players").GetComponent<MvP1>().moverNovo(ladoFinal);
    }
}

