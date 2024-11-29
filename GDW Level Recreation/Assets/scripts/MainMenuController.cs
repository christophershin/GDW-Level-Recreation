using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");

#if UNITY_EDITOR
        //Only executes in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false; // This stops the editor in unity from playing. Application.Quit ONLY works when the game is built
#else
        // Works for Builds of the Game
        Application.Quit(); //Only works when the Game is built
#endif
    }
}

