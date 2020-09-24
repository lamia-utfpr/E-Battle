using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour
{

    //Vetor dos Sprites presentes no dado
    private Sprite[] lados;

    // Referencia ao renderizador de sprites para podermos alterar a sprite
    private SpriteRenderer rend;

    public GameObject janelaDeMovimento;
    public Text texto;

    // Use this for initialization
    private void Start()
    {

        // Setando o renderizador de sprites
        rend = GetComponent<SpriteRenderer>();

        // Faz com que os sprites dos lados do dado sejam carregados a partir da pasta
        lados = Resources.LoadAll<Sprite>("d6/");
    }

    // O dado é rolado ao clicar sobre o mesmo
    private void OnMouseDown()
    {
        StartCoroutine("RolarDado");
    }

    // Função que faz a rolagem do dado
    private IEnumerator RolarDado()
    {
        // Variavel que ira ser utilizada para a rolagem do dado
        int randomDiceSide = 0;

        // Variavel para armazenarmos o valor final do dado
        int ladoFinal = 0;

        // Este loop irá alterar os sprites dos dados de acordo com suas posições
        // o dado terá 20 interações de mudança de lado, este valor pode ser alterado
        for (int i = 0; i <= 20; i++)
        {
            // Escolhemos um dos 6 lados do dado para ser o presente desta interação
            randomDiceSide = Random.Range(0, 5);

            // O sprite do dado é alterado na tela
            rend.sprite = lados[randomDiceSide];

            // Tempo de pausa entre cada interação e mudança na face do dado
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSecondsRealtime(1);
        // Aqui faremos com que o valor final seja armazenado na variavel ladoFinal
        // e será armazenada tbm no valor do dado das preferencias do jogador para uso de movimentação futura.
        ladoFinal = randomDiceSide + 1;
        PlayerPrefs.SetInt("Valor do Dado", ladoFinal);

       
        janelaDeMovimento.SetActive(true);
        texto.text = "Você tirou o valor: " + PlayerPrefs.GetInt("Valor do Dado");
    }
}

