using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Configuration Parameter
    private float moveSpeed;
    private bool moveRight;
    [SerializeField] float screenWidthUnit = 16f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 16f;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.1f;
        moveRight = true;    
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX) moveRight = false;    
        else if (transform.position.x < minX) moveRight = true;
        if (moveRight) 
        {
            transform.position = new Vector2 (transform.position.x + moveSpeed + Time.deltaTime, transform.position.y);
        }
        else 
        {
            transform.position = new Vector2 (transform.position.x - moveSpeed + Time.deltaTime, transform.position.y);
        }
    }
}
