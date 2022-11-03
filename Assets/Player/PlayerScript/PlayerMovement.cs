using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; 
    public Transform movePoint; //Target point to wich we move the player

    public LayerMask obstacles;//Reference to the collision layer


    // Start is called before the first frame update
    void Start()
    {

        movePoint.parent = null; //unparenting the target point so it not moving when the player move towards it

    }

    // Update is called once per frame
    void Update()
    {
        //Move the player to target point 
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        //Prevent the Player and movePoint to registrer movement input if the player is not yet at the movePoint
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)//Check for X axis input
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), .2f, obstacles)) //Checks for collision on X axis
                {

                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)//Check for Y axis input
            {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), .2f, obstacles)) //Checks for collision on Y axis
                {
                    
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);

                }
            }
        }

    }
}
