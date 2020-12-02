using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorTiempo : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Rigidbody2D rigidBodyEnemy;
    private Rigidbody2D rigidBodyPlayer;
    public Text tiempo;
    public Text mensajeFinJuego;
    public float tiempoJuego;

    void Start()
    {
        rigidBodyPlayer = player.GetComponent<Rigidbody2D>();
        rigidBodyEnemy = enemy.GetComponent<Rigidbody2D>();
        tiempoJuego = 61f;
    }

    void Update()
    {
        int timeInteger = (int)tiempoJuego;

        if (!rigidBodyPlayer.bodyType.Equals(RigidbodyType2D.Static))
        {
            tiempo.text = timeInteger.ToString() + " s";
            tiempoJuego -= Time.deltaTime;

        }
        else if (tiempoJuego > 0)
        {
            tiempo.text = timeInteger.ToString() + " s";
        }

        if (timeInteger == 0 && mensajeFinJuego.text != "Nivel Superado")
        {
            mensajeFinJuego.text = "Se ha agotado el tiempo";
            rigidBodyEnemy.bodyType = RigidbodyType2D.Static;
            rigidBodyPlayer.bodyType = RigidbodyType2D.Static;
            tiempo.text = "0 s";
        }

 



    }

}
