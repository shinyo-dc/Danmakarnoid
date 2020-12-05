using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBoss : MonoBehaviour
{
    bool isPlayerDead;
    GameObject player; 
    GameObject ball;
    [SerializeField] Text StatusText;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        PlayerDead();
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
    private void AfterDead()
    {
        ball.SetActive(false);
        StatusText.text = "Hit Z to restart"; 
        if (Input.GetKey(KeyCode.Z))
        {
            GameObject music = GameObject.FindGameObjectWithTag("Music"); 
            if (music)
            {
                music.GetComponent<MusicClass>().StopMusic();
            }
            SceneManager.LoadScene(0);
        }
    }
}
