using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    // Start is called before the first frame update

    private static int quantiaCasas = 40;
    private static int[] powerUpsTabuleiro;

    public static void setPowerUpsTabuleiro(int[] inicializacao){
        powerUpsTabuleiro = inicializacao;
    }

    public static void set_quantiaCasas(int quantia){
        quantiaCasas = quantia;
    }

    public static int[] get_powerUpsTabuleiro(){
        
        return powerUpsTabuleiro;
    }

    public static int get_quantiaCasas(){
        return quantiaCasas;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
