using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        PermanentUI.perm.hardBool = false; //resets hard mode
    }

}
