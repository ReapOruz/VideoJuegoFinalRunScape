using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchosActive : MonoBehaviour
{
    public GameObject objectPlayer;
    public Animator anim;
    private bool contactoPlayer;
    private Animator animatorPlayer;
    private float tiempoActivacion;
    private Collider2D colliderPincho;
    private BoxCollider2D bcPincho;
    private Collider2D colliderPersonaje;
    private Rigidbody2D rigidPlayer;
    public Text mensajeFinJuego;
    public GameObject demon;
    private Rigidbody2D rigidDemon;
    public GameObject sonidoSangre;

    void Start()
    {
        animatorPlayer = objectPlayer.GetComponent<Animator>();
        contactoPlayer = false;
        tiempoActivacion = 0f;
        colliderPincho = GetComponent<BoxCollider2D>();
        bcPincho = GetComponent<BoxCollider2D>();
        colliderPersonaje = objectPlayer.GetComponent<CapsuleCollider2D>();
        rigidPlayer = objectPlayer.GetComponent<Rigidbody2D>();
        rigidDemon = demon.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        activarPinchos(contactoPlayer);

        if (tiempoActivacion >= 1.5f)
        {
            bcPincho.size = new Vector2(0.6280966f, 0.9f);
        }

        if (contactoPlayer) {
            tiempoActivacion += Time.deltaTime;
        }


        if (tiempoActivacion >= 0.9f && colliderPincho.IsTouching(colliderPersonaje))
        {
            animatorPlayer.SetBool("isDead", true);
            rigidPlayer.bodyType = RigidbodyType2D.Static;
            Instantiate(sonidoSangre);
            mensajeFinJuego.text = "Has muerto";
            rigidDemon.bodyType = RigidbodyType2D.Static;
        }

        if (!colliderPincho.IsTouching(colliderPersonaje))
        {
            tiempoActivacion = 0f;
        }

    }

    bool OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (anim.GetBool("activarPinchos") == false)
            {
                contactoPlayer = true;
          
            }

            else if (anim.GetBool("activarPinchos"))
            {
                Debug.Log("Jugador ha muerto");
                animatorPlayer.SetBool("isDead", true);
                rigidPlayer.bodyType = RigidbodyType2D.Static;
                Instantiate(sonidoSangre);
                mensajeFinJuego.text = "Has muerto";
                rigidDemon.bodyType = RigidbodyType2D.Static;
            }

        }
        return contactoPlayer;
    }

    void activarPinchos(bool activado)
    {
        if (activado)
        {
            anim.SetBool("activarPinchos", true);
        }

    }

}
