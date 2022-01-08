using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] public TextMeshPro goodorbad;
    // Start is called before the first frame update
    void Start()
    {
        //stops music
        PermanentUI.perm.menumusic.Stop();
        PermanentUI.perm.music1.Stop();
        PermanentUI.perm.music2.Stop();
        PermanentUI.perm.music3.Stop();
        PermanentUI.perm.music4.Stop();
        PermanentUI.perm.LastScene = 5;
        PermanentUI.perm.die.Stop();
        if (PermanentUI.perm.diduwin == true)
        {
            //different displays depending on points obtained
            if (PermanentUI.perm.points >= 2600)
            {
            goodorbad.text = "Amazing! As a result of your hard work, you've recieved all 4 awards, and you've even gotten first place in your event at at NLC!";
             PermanentUI.perm.endmusic2.Play();
                PermanentUI.perm.diduwin = false;
            }
            else
            {
            PermanentUI.perm.endmusic1.Play();
            goodorbad.text = "Good Job! You've gotten all 4 awards!";
                PermanentUI.perm.diduwin = false;
            }
        }
        else
        {
            PermanentUI.perm.endmusic1.Play();
            goodorbad.text = "Although you didn't get all 4 awards, your dedication to the BAA's goals of service, education, and progress is incredible! Keep working hard!";
        }

    }
}
