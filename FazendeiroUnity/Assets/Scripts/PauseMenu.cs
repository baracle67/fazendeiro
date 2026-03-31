using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject iconePause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        painelPause.SetActive(false);
    }

    // Update is called once per frame
    public void Pausar()
    {
        painelPause.SetActive(true);
        iconePause.SetActive(false);
    }

    public void Despause()
    {
        painelPause.SetActive(false);
        iconePause.SetActive(true);
    }

    public void Sair()
    {
        Debug.Log("sair");
        Application.Quit();
    }
}
