using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizarange : MonoBehaviour
{
    public float speed = 20f;
    float timerIda = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(timerIda);
        timerIda -= Time.deltaTime;

        if (timerIda >= 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (timerIda<=0)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}