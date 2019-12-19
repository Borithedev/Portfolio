using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; //reference to what i want the camera to follow
    public float smoothing; //variable of how fast the camera moves towards target
    public Vector2 maxposition; // New Variable with x and y position (vector2) for maximum position of the camera, made public as variable would need to be constantly edited for different rooms
    public Vector2 minposition; //New Variable with x and y position (vector2) for minimum position of the camera, made public as variable would need to be constantly edited for different rooms


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() //late update comes last so camera doesnt go before player
    {
        if(transform.position != target.position) //if transorm posiition is not the target position then we are going to move towards it
        {
            Vector3 targetposition = new Vector3(target.position.x, target.position.y, transform.position.z); //keep its own z position
            targetposition.x = Mathf.Clamp(targetposition.x, minposition.x, maxposition.x);      //Modifiy targetposition in the x position; Mathf.Clamp takes 3 variables: value i want to clamp - being x position of target
                                                                                                 // the minimum value at which it clamps -  being the minimum position in x that was set in the editior
                                                                                                 // the maximum value at which it clamps -  being the maximum position in x that was set in the editior
            targetposition.y = Mathf.Clamp(targetposition.y, minposition.y, maxposition.y);  //Modifiy targetposition in the y position; Mathf.Clamp takes 3 variables: value i want to clamp - being y position of target
                                                                                            // the minimum value at which it clamps -  being the minimum position in y that was set in the editior
                                                                                            // the maximum value at which it clamps -  being the maximum position in y that was set in the editior

            transform.position = Vector3.Lerp(transform.position, targetposition, smoothing); // lerp find the distance between it and target and move a pecentage of that distance each frame
                                                                                            // it  moves from current position(transform.position) to target position(targetposition) by the amount it wants to cover(smoothing)
        
        }
        
    }
}
