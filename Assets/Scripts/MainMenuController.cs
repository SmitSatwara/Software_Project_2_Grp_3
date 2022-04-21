using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void PlayGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }



    public void QuitGame()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

}
