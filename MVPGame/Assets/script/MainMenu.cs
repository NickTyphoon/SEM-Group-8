using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// this is responsible for the basic starting the game and quitting the game
/// the options button is handled using the built in unity "On Click()" functionality
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// this changes the scene when the play button is pressed, this is attached
    /// to the image in unity
    /// </summary>

    public void PlayGame()
    {
		SceneManager.LoadSceneAsync("GameScene");
	}

    /// <summary>
    /// this quits the game when the button is pressed, this is attached though unity
    /// </summary>

	public void QuitGame()
    {
        Application.Quit();
	}
}














