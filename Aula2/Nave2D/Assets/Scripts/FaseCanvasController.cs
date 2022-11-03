using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FaseCanvasController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textoPontuacao;
    [SerializeField]
    GameObject panelMenu;
    [SerializeField]
    Slider volume;
    [SerializeField]
    Toggle mudo;

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
        if (!panelMenu.activeSelf)
        {
            SalvarConfiguracoes();
        }
    }
    public void SalvarConfiguracoes()
    {
        PlayerPrefs.SetFloat("volume", volume.value);
        PlayerPrefs.SetInt("mudo", mudo.isOn ? 1 : 0);
    }
    public void BuscarConfiguracoes()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volume.value = PlayerPrefs.GetFloat("volume");
            mudo.isOn = PlayerPrefs.GetInt("mudo") == 1 ? true : false;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        panelMenu.SetActive(false);
        BuscarConfiguracoes();
    }
    void Update()
    {
        textoPontuacao.SetText("Pontuação: " + NaveController.pontuacao);
    }
}
