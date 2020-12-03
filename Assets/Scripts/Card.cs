using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private AudioSource tickSource;
    private void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            tickSource.Play();
            GetComponent<Animator>().SetTrigger("death");
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
