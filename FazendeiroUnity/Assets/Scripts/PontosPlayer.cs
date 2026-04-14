using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PontosPlayer : MonoBehaviour
{
    int pontos = 0;
    public TextMeshProUGUI pontosText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PontosTexto();
        
    }

    void Ganharpontos(int addpontos)
    {
        pontos = pontos + addpontos;
    }
    void PontosTexto()
    {
        pontosText.text = "Pontos: " + pontos;
    }
}
