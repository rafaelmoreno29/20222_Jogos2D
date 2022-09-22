using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseController : MonoBehaviour
{
    public static int faseAtual;
    void Start()
    {
        faseAtual = 0; //apos criar o menu mudaremos aqui para 1
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "mudarFase")
        {
            faseAtual++;
            GetComponent<NaveController>().mudarPosicaoSpawn(collision.transform.position);
            if(faseAtual == 2) //apos criar o menu mudaremos aqui para 3
                SceneManager.LoadScene(faseAtual, LoadSceneMode.Additive);
            else
                SceneManager.LoadScene(faseAtual,LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
