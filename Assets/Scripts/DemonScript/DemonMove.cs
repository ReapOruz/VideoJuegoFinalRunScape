using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DemonMove : MonoBehaviour
{
    public Animator animPlayer;
    public Animator anim;
    private Rigidbody2D rb;
    public float velocidadMovimiento;
    public float radioVision;
    GameObject player;
    private Rigidbody2D rigidPlayer;
    public Text textoFinal;

    void Start()
    {
        radioVision = 4f;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 1.5f;
        anim.SetBool("attack", false);
        rb.velocity = new Vector2(velocidadMovimiento, rb.velocity.y);
        transform.localScale = new Vector3(1f, 1f, 1f);
        rigidPlayer = player.GetComponent<Rigidbody2D>();


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

        if (textoFinal.text == "Has Muerto")
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
            rigidPlayer.bodyType = RigidbodyType2D.Static;
            rb.bodyType = RigidbodyType2D.Static;
            textoFinal.text = "Has Muerto";
            anim.SetBool("attack", false);
        }

    }

}
