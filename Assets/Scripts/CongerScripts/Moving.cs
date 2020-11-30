using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public Text ContadorPuntos;
    public Animator anim;
    private float movimientoHorizontal;
    private bool jump;
    private Rigidbody2D rb;
    public float fuerzaSalto;
    private bool enSuelo;
    public float velocidadMovimiento;
    int contador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 3f;
        fuerzaSalto = 5.5f;
        enSuelo = false;
        contador = 0;

    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
        anim.SetFloat("idleState", Mathf.Abs(movimientoHorizontal));
        movimiento(movimientoHorizontal);

        if (enSuelo && jump)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetBool("jumpState", true);
            enSuelo = false;
            jump = false;
        }

        if (enSuelo)
        {
            anim.SetBool("jumpState", false);
        }

        ContadorPuntos.text = contador.ToString();

    }

    //Colision de personaje y suelo
    bool OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "suelo")
        {
            enSuelo = true;
        }

        if (other.gameObject.tag == "Huevo")
        {
            contador += 1;
            Debug.Log("Puntaje: " + contador);
        }

        if (other.gameObject.tag == "Pinchos")
        {
            enSuelo = true;
        }

        if (other.gameObject.tag == "Plataforma")
        {
            enSuelo = true;
        }

        return enSuelo;
    }




    //Movimiento del personaje en sentido horizontal
    void movimiento(float sentidoMovimiento)
    {

        if (sentidoMovimiento > 0)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(velocidadMovimiento, rb.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (sentidoMovimiento < 0)
        {

            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = new Vector2(-velocidadMovimiento, rb.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (sentidoMovimiento == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

    }
}
