using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosActive : MonoBehaviour
{
    public GameObject objectPlayer;
    public Animator anim;
    private bool contactoPlayer;
    private Animator animatorPlayer;

    void Start()
    {
        animatorPlayer = objectPlayer.GetComponent<Animator>();
        contactoPlayer = false;
        
    }

    void Update()
    {
        activarPinchos(contactoPlayer);

    }

    bool OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.tag == "Player")
        {
            if (anim.GetBool("activarPinchos")==false)
            {
                contactoPlayer = true;
            }
            else
            {
                if (objectPlayer.gameObject.tag == "Player" && anim.GetBool("activarPinchos"))
                {
                    Debug.Log("Jugador ha muerto");
                    animatorPlayer.SetBool("isDead", true);
                }

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
