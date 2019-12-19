using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 mincamerachange; //Variable for replaces the minimum position of the camera in the x and y
    public Vector2 maxcamerachange; //Variable for replaces the maximum position of the camera in the x and y
    public float smoothing; //The speed that the camera would move between rooms
    public Vector3 Playerchange; //variable for how much the player would move in teh x and y
    private CameraMovement camera; //Reference to the camera movement script
    public bool needtext; //since not every room might need a title this function allows me to differentiate the rooms
    public string placename; //names of the individual rooms can be held in the variable and can be easily established in the editor
    public GameObject text;
    public Text PlaceText; //reference to the game object that has preset settings of text position, font and size
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>(); //Makes the link to the camera movement script and identifies it as the veriable 'camera' 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) //checks to see if the player is in the trigger zone
        {
            camera.smoothing = smoothing;
            camera.minposition = mincamerachange; // pulls variable for the camera's minimum position from the script camera movement and make it equal to camerachange
            camera.maxposition = maxcamerachange; // pulls variable for the camera's maximum position from the script camera movement and make it equal to camerachange
            other.transform.position += Playerchange; // tell the system to move the player postion from the point it is at in the collider box to the point specified on the editor
            if(needtext)
            {
                StartCoroutine(placenameCo()); // call the text coroutine if text has been decided to be needed
            }
        }
    }

    private IEnumerator placenameCo() //method that runs in parallel to other processes and allows for a specified wait time
    {
        text.SetActive(true); //makes the game object active
        PlaceText.text = placename; //changes the text of the game object to the individual names that would be held in the string
        yield return new WaitForSeconds(4f); //waits a 4 seconds before continuing with the process
        text.SetActive(false); //turns off the game object
    }
}
