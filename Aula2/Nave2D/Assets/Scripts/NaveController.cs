using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public static int pontuacao;
    private Animator animator;
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
    [SerializeField]
    AudioClip explosaoClip;

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
        animator = GetComponent<Animator>();
        posicaoSpawn = transform.position;
        pontuacao = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "meteoro")
        {
            animator.Play("NaveExplodindo");
            animator.SetBool("explodindo", true);
            audioSource.PlayOneShot(explosaoClip, 1f);
            rigidbody.velocity = Vector3.zero;
            Destroy(collision.gameObject);
        }
    }

    public void Reiniciar()
    {
        transform.position = posicaoSpawn;
        animator.SetBool("explodindo", false);
    }

    void Update()
    {
        float velocidade = Mathf.Abs(Input.GetAxis("Horizontal")) +
                                Mathf.Abs(Input.GetAxis("Vertical"));
        animator.SetFloat("velocidade", velocidade);

        if (Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, -180, 0);
        if (Input.GetAxis("Horizontal") > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Fire1") && !animator.GetBool("explodindo"))
        {
            CriarTiro();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            AbrirPanelMenu();
        }

    }

    public void AbrirPanelMenu()
    {
        canvas.GetComponent<FaseCanvasController>().ChamarPanelMenu();
        if (canvas.GetComponent<FaseCanvasController>().GetActivePanelMenu())
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
        if (!animator.GetBool("explodindo"))
            rigidbody.velocity = new Vector3(
                Input.GetAxis("Horizontal") * velocidadeNave,
                Input.GetAxis("Vertical") * velocidadeNave,
                0);
    }
}
