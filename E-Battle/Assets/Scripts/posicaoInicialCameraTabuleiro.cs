using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicaoInicialCameraTabuleiro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Camera_Tabuleiro").transform.localScale = new Vector3(1.6f, 1.6f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (MvP1.getJogAtualStatic().GetComponent<Player>().canMove)
            alterarTamanhoCamera(1);
        else
        {
            alterarTamanhoCamera(2);
        }
    }

    private void alterarTamanhoCamera(int op)
    {
        if (op == 1)
        {
            if (this.GetComponent<Camera>().orthographicSize > 300f)
                this.GetComponent<Camera>().orthographicSize -= 0.5f;
        }

        if (op == 2)
        {
            if (this.GetComponent<Camera>().orthographicSize < 500f)
                this.GetComponent<Camera>().orthographicSize += 0.5f;
        }
    }

}
