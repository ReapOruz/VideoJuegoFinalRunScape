using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public GameObject player;
    private Animator animatorPlayer;

    void Start()
    {
        animatorPlayer = player.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animatorPlayer.SetBool("deadLava",true);
        }

    }

}
