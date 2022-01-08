using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider volume;

    public void PlayGame()
    {
        PermanentUI.perm.LastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Transition"); //plays game
    }

    public void QuitGame()
    {
        Application.Quit(); //quits game
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene("Score Board"); //loads leaderboard
    }

    private void Update()
    {
        PermanentUI.perm.musicVolume = volume.value; //update volume with slider
    }
}
