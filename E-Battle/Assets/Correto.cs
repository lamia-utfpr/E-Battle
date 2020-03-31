using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Correto : MonoBehaviour
{
    public Button botao;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = botao.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene(0);

    }
}
