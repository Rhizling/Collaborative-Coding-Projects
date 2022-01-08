using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float speed;
    private bool facingleft = true;


    // Update is called once per frame
    private void Update()
    {

        if (leftCap != rightCap)
        {
            if (transform.position.x <= leftCap)
            {
                facingleft = false;
                transform.localScale = new Vector3(-1, 1);
            } else if(transform.position.x >= rightCap)
            {
                facingleft = true;
                transform.localScale = new Vector3(1, 1);
            }

            if (facingleft == true)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
            }
        }
    }
}
