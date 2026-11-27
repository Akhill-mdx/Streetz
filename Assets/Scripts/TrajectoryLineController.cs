using UnityEngine;

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
    private bool isTrajectoryLineVisible; // Visibility of the trajectory line object
    public bool isTrajectoryLineLocked; // Lock state of the trajectory line object


    void Start()
    {
        trajectoryLinePosition = new Vector3(0, 0, 0);
        trajectoryLineDirection = new Vector3(0, 0, 1);
        ballPosition = new Vector3(0, 0, 0);
        isTrajectoryLineVisible = false;
        isTrajectoryLineLocked = true;
    }

    void Update()
    {
        SetTrajectoryLineVisibility(isTrajectoryLineVisible); // Calls SetTrajectoryLineVisibility method to set the visibility of the trajectory line object

        if (Input.GetKeyDown(KeyCode.Mouse1)) // if the right mouse button has been pressed
        {
           
            isTrajectoryLineLocked = !isTrajectoryLineLocked; // Toggle the lock state of the trajectory line object
            if (isTrajectoryLineLocked) // if the trajectory line is locked
            {
                Debug.Log("Trajectory Line Locked");
            }
            else // if the trajectory line is unlocked
            {
                Debug.Log("Trajectory Line Unlocked");
            }

            // the first timee the right mouse button is pressed
            if (!isTrajectoryLineVisible) // if the trajectory line is not visible
            {
                isTrajectoryLineVisible = true; 
            }


        }

    }

    private void SetTrajectoryLineVisibility(bool isVisible)
    {
        trajectoryLineObject.GetComponent<Renderer>().enabled = isVisible;
        trajectoryLineEndObject.GetComponent<Renderer>().enabled = isVisible;
    }
}
