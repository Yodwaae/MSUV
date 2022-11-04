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
        //Move the player to target point (Added offset since movePoint is not at player origins (0,.25,0))
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position - new Vector3(0, .25f, 0), moveSpeed * Time.deltaTime);

        //All value are halved for the Y axis because of the isometric grid 
        //Prevent the Player and movePoint to registrer movement input if the player is not yet at the movePoint
        if (Vector3.Distance(transform.position, movePoint.position - new Vector3(0, .25f, 0)) <= .02f)//Added offset since movePoint is not at player origins (.5,.5,0)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)//Check for X axis input
            {
                //Checks for collision on X axis
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal")) * .5f, -Mathf.Sign(Input.GetAxisRaw("Horizontal")) * .25f, 0), .2f, obstacles))
                {

                        movePoint.position += new Vector3(Mathf.Sign(Input.GetAxisRaw("Horizontal"))*.5f, -Mathf.Sign(Input.GetAxisRaw("Horizontal"))*.25f, 0);

                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)//Check for Y axis input
            {
                //Checks for collision on Y axis
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Mathf.Sign(Input.GetAxisRaw("Vertical"))*.5f, Mathf.Sign(Input.GetAxisRaw("Vertical"))*.25f, 0), .2f, obstacles))
                {
                    
                    movePoint.position += new Vector3(Mathf.Sign(Input.GetAxisRaw("Vertical")) * .5f, Mathf.Sign(Input.GetAxisRaw("Vertical")) * .25f, 0);

                }
            }
        }

    }
}
