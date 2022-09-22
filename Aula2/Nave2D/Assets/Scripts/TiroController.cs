using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    float forca;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forca, ForceMode2D.Impulse);
        InvokeRepeating("Destruir", 5, 5);
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "meteoro")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            NaveController.pontuacao++;
            Debug.Log(NaveController.pontuacao);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
