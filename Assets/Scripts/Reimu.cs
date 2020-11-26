using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{
    // Configuration Parameter
    [SerializeField] float screenWidthUnit = 16f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentMousePos = Input.mousePosition.x / Screen.width * screenWidthUnit;
        Vector2 reimuPos = new Vector2(transform.position.x, transform.position.y);
        reimuPos.x = Mathf.Clamp(currentMousePos, minX, maxX);
        transform.position = reimuPos;
    }
}
