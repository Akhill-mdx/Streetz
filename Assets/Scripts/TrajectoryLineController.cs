using UnityEngine;

public class TrajectoryLineController : MonoBehaviour
{
    public GameObject trajectoryLineObject;



    private Vector3 testPosition = new Vector3(0, 0, 0);
    private int testLevel = 3;
    private float testSpeed = 1.2f;
    private bool testIsHidden = true;







    private Vector3 trajectoryLinePosition;
    private Vector3 trajectoryLineDirection;
    private Vector3 ballPosition;
    private bool isTrajectoryLineVisible;
    public bool isTrajectoryLineLocked;


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
        SetTrajectoryLineVisibility(isTrajectoryLineVisible);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            isTrajectoryLineLocked = !isTrajectoryLineLocked;
            if (isTrajectoryLineLocked)
            {
                Debug.Log("Trajectory Line Locked");
            }
            else
            {
                Debug.Log("Trajectory Line Unlocked");
            }


            if (!isTrajectoryLineVisible)
            {
                isTrajectoryLineVisible = true;
            }


        }

    }

    private void SetTrajectoryLineVisibility(bool isVisible)
    {
        trajectoryLineObject.GetComponent<Renderer>().enabled = isVisible;
    }
}
