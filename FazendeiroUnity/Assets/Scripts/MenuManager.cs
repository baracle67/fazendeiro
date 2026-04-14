using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelOpcao;
    [SerializeField] private GameObject painelSaida;

    void Start()
    {
        painelOpcao.SetActive(false);
        painelSaida.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    // Update is called once per frame
    public void AbrirOpcoes()
    {
        painelMenu.SetActive(false);
        painelOpcao.SetActive(true);
    }

    public void VoltarMenu()
    {
        painelMenu.SetActive(true);
        painelOpcao.SetActive(false);
        painelSaida.SetActive(false);
    }

    public void ConfirmarSaida()
    {
        painelSaida.SetActive(true);
        painelMenu.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("sair");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
