using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public GameObject Player;
    void Start()
    {
        restartButton.gameObject.SetActive(false);
    }
    void Update()
    {
        if (player.isdead == true)
        {
            Player.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
	}
}
