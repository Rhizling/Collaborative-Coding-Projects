using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public int checkpointnumber = 0;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    // sets animation state of all the checkpoints
    private void Update()
    {
        if ((PermanentUI.perm.checkpoint - checkpointnumber) > 0)
        {
        anim.SetInteger("state", 1);
            if ((PermanentUI.perm.checkpoint - checkpointnumber) == 1)
            {
                //if this is the most recent checkpoint, teleport here
            PermanentUI.perm.cppos = new Vector2(transform.position.x, transform.position.y);
            }

        } 

    }
}
