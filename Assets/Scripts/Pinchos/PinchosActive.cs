using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        animatorPlayer = objectPlayer.GetComponent<Animator>();
        contactoPlayer = false;
        tiempoActivacion = 0f;
        colliderPincho = GetComponent<BoxCollider2D>();
        bcPincho = GetComponent<BoxCollider2D>();
        colliderPersonaje = objectPlayer.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        activarPinchos(contactoPlayer);

        if (tiempoActivacion > 1f)
        {
            bcPincho.size = new Vector2(0.6280966f, 0.9f);
        }

        if (contactoPlayer) {
            tiempoActivacion += Time.deltaTime;
        }


        if (tiempoActivacion > 1f && colliderPincho.IsTouching(colliderPersonaje))
        {
            animatorPlayer.SetBool("isDead", true);
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
