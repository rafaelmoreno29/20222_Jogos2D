using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseCanvasController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textoPontuacao;
    [SerializeField]
    GameObject panelMenu;

    public bool GetActivePanelMenu()
    {
        return panelMenu.activeSelf;
    }

    public void AbrirCenaMenu()
    {
        Destroy(GameObject.Find("Nave"));
        Destroy(GameObject.Find("Canvas"));
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ChamarPanelMenu()
    {
        panelMenu.SetActive(!panelMenu.activeSelf);
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        panelMenu.SetActive(false);
    }
    void Update()
    {
        textoPontuacao.SetText("Pontuação: " + NaveController.pontuacao);
    }
}
