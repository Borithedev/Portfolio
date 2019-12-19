using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; //creating a new variable called speed would be used to give the computer a magnitude for 
                        //rate of change in distance over time for when the character is walking, this is made public as it would be more convenient editing
    public float runspeed; //creating a new variable called runspeed that would be the given magnitude for rate of change in distance over time when the character is sprinting, made public so i can constantly change easily
    private Rigidbody2D myRigidbody; // establishing the component Rigidbody2D in the character as a variable 
    private Vector3 change; //Vector3 refers to magnitude in 3 axis (x,y,z) we will make it a variable named change so it can be refered to later in the code
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; //all  axis is set to a default value of 0 and this information is stored in the variable 0
        change.x = Input.GetAxisRaw("Horizontal"); //the x axis of vector 3 is changed when the user enters a x axis key (a,d,left,right) this is made into a veriable so it can be called in a if statement
        change.y = Input.GetAxisRaw("Vertical"); //the y axis of vector 3 is changed when the user enters a y axis key (w,s,up,down) this is made into a veriable so it can be called in a if statement
        UpdateAnimatinAndMove();
    }
    void UpdateAnimatinAndMove()
    {
        if (change != Vector3.zero) //when all 3 axis of change is not 0 (the default postiton)
        {
            MoveCharacter(); //variable move position is called
            animator.SetFloat("MoveX", change.x); //float 'MoveX' that has been put in place in the editor for the amount the character moves on the x axis is determined by the variable change.X (players input)
            animator.SetFloat("MoveY", change.y); //float 'MoveY' that has been put in place in the editor for the amount the character moves on the y axis is determined by the variable change.y (players input)
            animator.SetBool("Moving", true); // 'moving' is a bool that is used as a condition for triggering the walking animation, this bool is true as the character is moving since axis of the character are 0
        }
        else
        {
            animator.SetBool("Moving", false); //since the character is not moving conditions can not be met to trigger the walking animation
        }
        UpdateRunning();
    }
    void UpdateRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift)) //if the user is holding down the left shift key this statement begins
        {
            if (change != Vector3.zero) // the statement of the user pressing left shift key is combined with a condition of the charater not being its default position
            {
                myRigidbody.MovePosition(transform.position += change * runspeed * Time.deltaTime); //then the user press left shift the system will follow a new rule on how the character moves
                                                                                                                                      //similar to the previous rule but since the speed must be different we use a new float 
                animator.SetFloat("MoveX", change.x); //float 'MoveX' that has been put in place in the editor for the amount the character moves on the x axis is determined by the variable change.X (players input)
                animator.SetFloat("MoveY", change.y); //float 'MoveY' that has been put in place in the editor for the amount the character moves on the y axis is determined by the variable change.y (players input)
                animator.SetBool("Running", true); //'runnng' is a bool that is used as a condition for triggering the running animation, this bool is true as the character is moving since axis of the character are 0
                                                                                                                                                                                        //and the user is pressing left shift

            }

        }
        else
        {
            animator.SetBool("Running", false);  //the condition the character running is not meet since the user is not holding left shift and the character is in the defult postion this the bool is fal 
                                                                                                                                             //therfore the character animation will go to idle or go to the walking animation
        }


    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
        //when moving the position of the riged mody the system would take in acount the equation where the transform of the postion is increased by the change in axis magnitude taking in acount speed and time (distance)
    }
}
