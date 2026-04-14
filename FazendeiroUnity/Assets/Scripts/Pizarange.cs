using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizarange : MonoBehaviour
{
    public float speed = 20f;
    int posisao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = -20f;
        transform.Translate(Vector3.forward * speed * -Time.deltaTime);
    }

}