using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoSonido : MonoBehaviour
{
    private float tiempo = 1f;
    void Start()
    {
        Destroy(gameObject, tiempo);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
