using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMove : MonoBehaviour
{
    public Animator animPlayer;
    public int tiempoJuego;
    public Animator anim;
    private Rigidbody2D rb;
    public float velocidadMovimiento;
    public float radioVision;
    GameObject player;

    void Start()
    {
        radioVision = 4f;
        player = GameObject.FindGameObjectWithTag("Player");
        tiempoJuego = 60;
        rb = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 1.5f;
        anim.SetBool("attack", false);
        rb.velocity = new Vector2(velocidadMovimiento, rb.velocity.y);
        transform.localScale = new Vector3(1f, 1f, 1f);
        
    }

    void Update()
    {
        atacar();
    }

    void atacar()
    {
        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia <= radioVision)
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Jugador ha muerto");
            animPlayer.SetBool("deadDemonFire", true);
        }

    }





}
