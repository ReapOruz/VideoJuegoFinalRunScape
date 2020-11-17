using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class huevoScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

        }

    }
}
