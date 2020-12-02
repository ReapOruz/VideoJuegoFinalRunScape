using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoving : MonoBehaviour
{
    public GameObject demon;
    private Rigidbody2D rigidBodyEnemy;
    public Text ContadorPuntos;
    public Animator anim;
    private Animator demonAnimator;
    private float movimientoHorizontal;
    private bool jump;
    private Rigidbody2D rb;
    public float fuerzaSalto;
    private bool enSuelo;
    public float velocidadMovimiento;
    public Text mensajeFinJuego;
    int puntos;
    private int puntosGanar = 10;
    public GameObject sonidoSalto;
    public GameObject sonidoPunto;
    public GameObject sonidoExplosion;
    private Rigidbody2D rigidPlayer;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 3f;
        fuerzaSalto = 5.2f;
        enSuelo = false;
        puntos = 0;
        rigidBodyEnemy = demon.GetComponent<Rigidbody2D>();
        demonAnimator = demon.GetComponent<Animator>();
        rigidPlayer = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
        anim.SetFloat("idleState", Mathf.Abs(movimientoHorizontal));
        movimiento(movimientoHorizontal);

        if (gameObject.transform.rotation.z != 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (enSuelo && jump)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetBool("jumpState", true);
            enSuelo = false;
            jump = false;
            Instantiate(sonidoSalto);
        }

        if (enSuelo)
        {
            anim.SetBool("jumpState", false);
        }

        if (puntos == puntosGanar)
        {
            mensajeFinJuego.text = "Nivel Superado";
            rigidBodyEnemy.bodyType = RigidbodyType2D.Static;
            rigidPlayer.bodyType = RigidbodyType2D.Static;
            demonAnimator.SetBool("isDeadDemon", true);
            puntos = 0;
            Instantiate(sonidoExplosion);
        }

        ContadorPuntos.text = puntos.ToString();

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
            puntos += 1;
            Debug.Log("Puntaje: " + puntos);
            Instantiate(sonidoPunto);

        }

        if (other.gameObject.tag == "Pinchos")
        {
            enSuelo = true;
        }

        if (other.gameObject.tag == "Plataforma")
        {
            enSuelo = true;
        }

        if (other.gameObject.tag == "vacio")
        {
            //Destroy(gameObject);
            mensajeFinJuego.text = "Has muerto";
            rigidBodyEnemy.bodyType = RigidbodyType2D.Static;
        }

        if (other.gameObject.tag == "Lava")
        {
            mensajeFinJuego.text = "Has muerto";
            rigidBodyEnemy.bodyType = RigidbodyType2D.Static;
            rb.bodyType = RigidbodyType2D.Static;
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
