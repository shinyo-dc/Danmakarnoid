using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config params
    [SerializeField] float startX = 16f;
    [SerializeField] float startY = 0f;
    [SerializeField] float velX = -15f;
    [SerializeField] float velY = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 currPos;
        currPos.x = startX;
        currPos.y = startY;
        transform.position = currPos;
        LaunchOnStart();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LaunchOnStart()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float speed = player.GetComponent<Animator>().GetFloat("Speed");
            player.GetComponent<ReimuHealth>().TakeDamage();
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
            if (player.transform.localScale.x == -1)
            {
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 20f * speed);
            }
            else if (player.transform.localScale.x == 1)
            {
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 20f * speed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
            float distX = this.transform.position.x - bullet.transform.position.x;
            float velX = this.GetComponent<Rigidbody2D>().velocity.x;
            if (velX > 0f)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(velX, 0f);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(distX*5f, 0f);
            }
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
        }
    }
}
