using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    private PontosPlayer pontosScript;
    [SerializeField] private GameObject pontos;
    // Start is called before the first frame update
    void Start()
    {
        pontos = GameObject.Find("Canvas");
        pontosScript = pontos.GetComponent<PontosPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("pizza"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            pontosScript.Ganharpontos(1);
        }
        
    }

}
