using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            GetComponent<Animator>().SetTrigger("death");
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
