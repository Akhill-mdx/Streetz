using UnityEngine;

public class TrajectoryLineController : MonoBehaviour
{
    private Vector3 testPosition = new Vector3(0, 0, 0);
    private int testLevel = 3;
    private float testSpeed = 1.2f;
    private bool testIsHidden = true;



    private Vector3 TrajectoryLinePosition;
    private Vector3 TrajectoryLineDirection;
    private Vector3 BallPosition;
    private bool IsTrajectoryLineVisible;
    private bool IsTrajectoryLineLocked;


    void Start()
    {
        TrajectoryLinePosition = new Vector3(0, 0, 0);
        TrajectoryLineDirection = new Vector3(0, 0, 1);
        BallPosition = new Vector3(0, 0, 0);
        IsTrajectoryLineVisible = false;
        IsTrajectoryLineLocked = false;
    }

    void Update()
    {
        SetTrajectoryLineVisibility(IsTrajectoryLineVisible);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Right mouse button clicked");
            IsTrajectoryLineLocked = !IsTrajectoryLineLocked;



            if (!IsTrajectoryLineVisible)
            {
                IsTrajectoryLineVisible = true;
            }


        }

    }

    private void SetTrajectoryLineVisibility(bool isVisible)
    {
        GetComponent<Renderer>().enabled = isVisible;
    }
}
