using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemploColisao : MonoBehaviour
{
    [SerializeField]
    private int Pontuacao;
    private Vector3 PosicaoInicial;

    // Start is called before the first frame update
    void Start()
    {
        Pontuacao = 0;
        PosicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "moeda")
        {
            Pontuacao++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "checkpoint")
        {
            PosicaoInicial = collision.gameObject.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ENTROU NA COLISÃO - " + collision.gameObject.tag);

        if(collision.gameObject.tag == "inimigo")
        {
            if(Pontuacao > 0)
            {
                Pontuacao--;
                transform.position = PosicaoInicial;
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("GAME OVER!!!");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ESTÁ COLIDINDO");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("SAIU DA COLISÃO");
    }
}
