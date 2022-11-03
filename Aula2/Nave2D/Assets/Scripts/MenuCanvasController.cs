using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField]
    GameObject panelPrincipal;
    [SerializeField]
    GameObject panelSobre;
    [SerializeField]
    Text textPontuacao;
    // Start is called before the first frame update
    void Start()
    {
        panelPrincipal.SetActive(true);
        panelSobre.SetActive(false);
        if (PlayerPrefs.HasKey("maiorPontuacao"))
        {
            textPontuacao.text = "Maior Pontuação: " + PlayerPrefs.GetInt("maiorPontuacao");
        }
    }
    public void ButtonIniciarClick()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonSobreClick()
    {
        panelPrincipal.SetActive(false);
        panelSobre.SetActive(true);
    }
    public void ButtonVoltarClick()
    {
        panelPrincipal.SetActive(true);
        panelSobre.SetActive(false);
    }
    public void ButtonSairClick()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
