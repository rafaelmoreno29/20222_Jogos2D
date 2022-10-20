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

    GameObject canvas;

    [SerializeField]
    AudioClip tiroAudioClip;
    AudioSource audioSource;

    public static void AtualizarPontuacao()
    {
        pontuacao++;
    }

    public void mudarPosicaoSpawn(Vector3 novaPosicaoSpawn)
    {
        posicaoSpawn = novaPosicaoSpawn;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        canvas = GameObject.Find("Canvas");
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        posicaoSpawn = transform.position;
        pontuacao = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "meteoro")
        {
            transform.position = posicaoSpawn;
            rigidbody.velocity = Vector3.zero;
            Destroy(collision.gameObject);
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
        if(Input.GetButtonDown("Cancel"))
        {
            AbrirPanelMenu();
        }
    }

    public void AbrirPanelMenu()
    {
        canvas.GetComponent<FaseCanvasController>().ChamarPanelMenu();
        if(canvas.GetComponent<FaseCanvasController>().GetActivePanelMenu())
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void CriarTiro()
    {
        if (canvas.GetComponent<FaseCanvasController>().GetActivePanelMenu() == false)
        {
            Instantiate(TiroPrefab, TiroSpawn.transform.position, transform.rotation);
            audioSource.PlayOneShot(tiroAudioClip, 1f);
        }
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(
            Input.GetAxis("Horizontal") * velocidadeNave,
            Input.GetAxis("Vertical") * velocidadeNave,
            0);
    }
}
