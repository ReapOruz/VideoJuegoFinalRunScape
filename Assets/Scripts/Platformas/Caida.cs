using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D colliderObject;
    private Rigidbody2D rigidPlataforma;

    void Start()
    {
        rigidPlataforma = GetComponent<Rigidbody2D>();
        colliderObject = GetComponent<BoxCollider2D>();
    }

    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("derrumbed",true);
            rigidPlataforma.bodyType = RigidbodyType2D.Dynamic;
            //colliderObject.isTrigger = true;
        }

        if (other.gameObject.tag == "Lava")
        {
            anim.SetBool("enSuelo", true);
            rigidPlataforma.bodyType = RigidbodyType2D.Static;
        }

        if (other.gameObject.tag == "vacio" || other.gameObject.tag == "Pinchos" || other.gameObject.tag == "Huevo")
        {

            Destroy(gameObject);
        }

    }


}
