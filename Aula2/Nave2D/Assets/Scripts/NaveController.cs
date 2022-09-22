using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public static int pontuacao;

    private Rigidbody2D rigidbody;
    private Vector3 posicaoSpawn;
    [SerializeField]
    GameObject TiroPrefab;
    [SerializeField]
    GameObject TiroSpawn;

    [SerializeField]
    float velocidadeNave;

    public void mudarPosicaoSpawn(Vector3 novaPosicaoSpawn)
    {
        posicaoSpawn = novaPosicaoSpawn;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        rigidbody = GetComponent<Rigidbody2D>();
        posicaoSpawn = transform.position;
        pontuacao = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "meteoro")
        {
            transform.position = posicaoSpawn;
            rigidbody.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            CriarTiro();
        }
    }
    public void CriarTiro()
    {
        Instantiate(TiroPrefab, TiroSpawn.transform.position,transform.rotation);
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal") * velocidadeNave,
            Input.GetAxis("Vertical") * velocidadeNave,
            0);
    }
}
