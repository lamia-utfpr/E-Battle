using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private List<string> powerups; 

    private int casaAtual = 0;

    public void set_casaAtual(int novaCasa){
        casaAtual = novaCasa;
    }

    public int get_casaAtual(){
        return casaAtual;
    }


    public void setX(int novoX){
        Vector3 temp = new Vector3(novoX,0,0);
        this.transform.position += temp;
    }

    public void setY(int novoY){
        Vector3 temp = new Vector3(0,novoY,0);
        this.transform.position += temp;
    }

    void Start()
    {
        powerups = new List<string>();
    }

    public List<string> getListaPowerUps(){
        return powerups;
    }

    public void atualizarListaPowerUps(List<string> listaNova){
        powerups = listaNova;
    }

    public void addPowerUp(string nome){
        powerups.Add(nome);
    }

    public void verificarObtencaoDePowerUp(int casa){        
        
        int[] mapeamentoPowerUps = Tabuleiro.get_powerUpsTabuleiro();

        Debug.Log(casa);
        Debug.Log(mapeamentoPowerUps.Length);


        if(mapeamentoPowerUps[casa] == 1){
            
            addPowerUp(gerarPowerUp());

            int[] novoVetor = mapeamentoPowerUps;
            novoVetor[casa] = 0;

            Tabuleiro.setPowerUpsTabuleiro(novoVetor);
            Debug.Log("O player " + this.name + " pegou um power up! O power up é " +  powerups[powerups.Count-1]);


        }

        /*
        if (GameObject.Find("casa " + casa)){
            if (GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().getTemPowerUp() ){

                addPowerUp(GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().get_nomePowerUp());
                GameObject.Find("casa " + casa).GetComponent<GerenciarCasas>().tirarPowerUp();
                
                Debug.Log(this.name + " pegou um power up! Ele caiu na casa " + casa);


            }
        }
        */
        


    }

    private string gerarPowerUp(){
        string[] aux = GameObject.Find("controlar_spawn_powerups").GetComponent<controlarSpawnPowerUps>().powerUpsPossiveis();

        int indice = Random.Range(0, aux.Length);

        return aux[indice];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
