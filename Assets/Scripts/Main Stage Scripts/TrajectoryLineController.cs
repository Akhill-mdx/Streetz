using UnityEngine;
using UnityEngine.InputSystem;

public class TrajectoryLineController : MonoBehaviour
{
    public GameObject trajectoryLineObject; // Line of the trajectory line object
    public GameObject trajectoryLineEndObject; // End of the trajectory line object



   // private Vector3 testPosition = new Vector3(0, 0, 0);
   // private int testLevel = 3;
   // private float testSpeed = 1.2f;
   // private bool testIsHidden = true;


    private Vector3 trajectoryLinePosition; // Position of the trajectory line object
    private Vector3 trajectoryLineDirection; // Direction of the trajectory line object
    private Vector3 ballPosition; // Position of the ball object
    private Vector3 mouseStartPosition; // Position of the mouse when the left mouse button is pressed
    private Vector3 trajectoryLineStartScale; // Scale of the trajectory line object when the left mouse button is pressed
    private bool isTrajectoryLineVisible; // Visibility of the trajectory line object
    public bool isTrajectoryLineMovementLocked; // Lock state of the trajectory line object
    private bool isTrajectoryLineLengthLocked; // Lock state of the length of the trajectory line object



    void Start()
    {
        trajectoryLinePosition = new Vector3(0, 0, 0);
        trajectoryLineDirection = new Vector3(0, 0, 1);
        ballPosition = new Vector3(0, 0, 0);
        isTrajectoryLineVisible = false;
        isTrajectoryLineMovementLocked = true;
        isTrajectoryLineLengthLocked = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1)) // if the right mouse button has been pressed
        {

            isTrajectoryLineMovementLocked = !isTrajectoryLineMovementLocked; // Toggle the lock state of the trajectory line object
            if (isTrajectoryLineMovementLocked) // if the trajectory line is locked
            {
                Debug.Log("Trajectory Line Locked");
            }
            else // if the trajectory line is unlocked
            {
                Debug.Log("Trajectory Line Unlocked");
            }

            // the first time the right mouse button is pressed
            if (!isTrajectoryLineVisible) // if the trajectory line is not visible
            {
                isTrajectoryLineVisible = true;
                
            }


        }

        SetTrajectoryLineVisibility(isTrajectoryLineVisible); // Calls SetTrajectoryLineVisibility method to set the visibility of the trajectory line object

        if (Input.GetKeyDown(KeyCode.Mouse0)) // If the left mouse button has been pressed
        {
            Debug.Log("Mouse Position: " + Input.mousePosition);

            if (isTrajectoryLineMovementLocked && isTrajectoryLineVisible)
            {
                mouseStartPosition = Input.mousePosition;
                trajectoryLineStartScale = trajectoryLineObject.gameObject.transform.localScale;

                isTrajectoryLineLengthLocked = !isTrajectoryLineLengthLocked; // Toggle the lock state of the length of the trajectory line object
                if (isTrajectoryLineLengthLocked)
                {
                    Debug.Log("Trajectory Line Length Locked");
                }
                else
                {
                    Debug.Log("Trajectory Line Length Unlocked");// Click left click
                                                                 // Move mouse back and forth to adjust length of the trajectory line
                                                                 // Click left click again to lock the length of the trajectory line
                }
            }

        }

        if (!isTrajectoryLineLengthLocked)
        {
            Vector3 mousePositionDifference = Input.mousePosition - mouseStartPosition; // Calculate the difference between the current mouse position and the start position
            float newScale = trajectoryLineStartScale.z + mousePositionDifference.y / 40;

            if (newScale < 15f && newScale > 1f)
            {
                trajectoryLineObject.gameObject.transform.localScale = new Vector3(trajectoryLineStartScale.x, trajectoryLineStartScale.y, newScale); // Adjust the length of the trajectory line based on mouse movement
            }

                 
            //Input.mousePosition.y is current mouse position
            //mouseStartPosition.y is start position
            //if start position is 5 and current position is 5, the scale should not change because the difference is 0
            //if start position is 5 and current position is 10, the scale should increase by 5 because the difference is 5
            //if start position is 5 and current position is 10, the scale should increase by 5 because the difference is 5
            //if start position is 5 and current position is 0, the scale should decrease by 5 because the difference is -5
        }


    }
    private void SetTrajectoryLineVisibility(bool isVisible)
    {
        trajectoryLineObject.GetComponent<Renderer>().enabled = isVisible;
        trajectoryLineEndObject.GetComponent<Renderer>().enabled = isVisible;
    }
}
