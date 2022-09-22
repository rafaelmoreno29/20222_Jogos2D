using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float forca;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(forca * -1, 0), ForceMode2D.Impulse);
        InvokeRepeating("Destruir", 5, 5);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
