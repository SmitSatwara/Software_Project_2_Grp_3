using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public GameObject Panel;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            Panel.SetActive(true);

        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
