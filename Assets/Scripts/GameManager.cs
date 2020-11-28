using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] CardCounts;
    [SerializeField] int count = 0;
    [SerializeField] string tagToCount = "Card";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        CardCount();
    }
    private void CardCount()
    {
        CardCounts = GameObject.FindGameObjectsWithTag(tagToCount);
        count = CardCounts.Length;
        if (count == 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
