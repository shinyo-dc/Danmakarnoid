using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] CardCounts;
    [SerializeField] int count = 0;
    [SerializeField] string tagToCount = "Card";
    bool isPlayerDead;
    GameObject player; 
    [SerializeField] Text StatusText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        PlayerDead();
        CardCount();
    }

    private void PlayerDead()
    {
        if (player != null)
        {
            isPlayerDead = player.GetComponent<ReimuHealth>().die;
        }
        else
        {
            AfterDead();
        }
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
    private void AfterDead()
    {
        StatusText.text = "Hit Z to restart"; 
        if (Input.GetKey(KeyCode.Z))
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
            SceneManager.LoadScene(0);
        }
    }
}
