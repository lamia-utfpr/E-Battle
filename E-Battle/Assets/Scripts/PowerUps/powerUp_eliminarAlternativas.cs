using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class powerUp_eliminarAlternativas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void eliminarAlternativas(){
        int qtd_corretas = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().get_qtsCorretas();
        string[] alternativasAtuais = GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAlternativasAtuais();

        int qtdRemover = (int) alternativasAtuais.Length/2;
        int[] quaisRemover = new int[4];
        quaisRemover[0] = -1;
        quaisRemover[1] = -1;
        quaisRemover[2] = -1;
        quaisRemover[3] = -1;
        
        
        
        int indice = 0;


        while(qtdRemover > 0){

            int qualRemover = Random.Range(1, alternativasAtuais.Length);

            if (qualRemover != GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAltCorreta1() &&
                qualRemover != GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAltCorreta2() &&
                qualRemover != GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAltCorreta3() &&
                qualRemover != GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().getAltCorreta4()) {
                
                int aux = 0;


                //verifica se a que será removida já não está incluida no vetor responsável por remover as alternativas incorretas
                for(int i = 0; i < 4; i++){
                    if (qualRemover == quaisRemover[i]){
                        aux = 1;
                        break;
                    }
                }
                //caso já não esteja no vetor, a alternativa gerada randomicamente é inserida no vetor
                if (aux == 0){
                    quaisRemover[indice] = qualRemover;
                    indice++;
                    qtdRemover--;
                }
                
            }

        }

        GameObject.Find("painel_Pergunta").GetComponent<apresentarPergunta>().remover_textoAlternativas(quaisRemover);

    }

}
