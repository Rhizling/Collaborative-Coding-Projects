using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") //if the falling object is player
        {
            PermanentUI.perm.lives = PermanentUI.perm.lives - 1; //lose life
            if (PermanentUI.perm.hardBool)
            {
                PermanentUI.perm.points = PermanentUI.perm.points - 200; //lose points depending on difficulty
            }
            else
            {
                PermanentUI.perm.points = PermanentUI.perm.points - 20;

            }
            PermanentUI.perm.die.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload scene
            PermanentUI.perm.Reset(); //reset coin and point count
        }
    }
}
