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
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 currPos;
        currPos.x = startX;
        currPos.y = startY;
        transform.position = currPos;
        player = GameObject.FindGameObjectWithTag("Player");
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
        float distX = this.transform.position.x - player.transform.position.x;
        float distY = this.transform.position.y - player.transform.position.y;
        if (other.gameObject.tag.Equals("Player"))
        {
            float velX = this.GetComponent<Rigidbody2D>().velocity.x;
            float velY = this.GetComponent<Rigidbody2D>().velocity.y;
            player.GetComponent<ReimuHealth>().TakeDamage();
            if (player.transform.localScale.x == -1)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(15f, 20f);
            }
            else if (player.transform.localScale.x == 1)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-15f, 20f);
            }
        }
    }
}
