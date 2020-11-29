using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorTiempo : MonoBehaviour
{
    public Text tiempo;
    public Text mensajeFinJuego;
    public float tiempoJuego;

    void Start()
    {
        tiempoJuego = 10f;
    }

    void Update()
    {
        tiempoJuego -= Time.deltaTime;
        int timeInteger = (int)tiempoJuego;

        tiempo.text = timeInteger.ToString();
  
        if (timeInteger == 0)
        {
            mensajeFinJuego.text = "Se ha agotado el tiempo";
        }

    }


}
