using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public TrajectoryLineController trajectoryLineController;
    public GameObject ballObject;

    private float rotationSpeed = 500.0f;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        if (!trajectoryLineController.isTrajectoryLineLocked)
        {
            if(Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
            {
                float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * -1;
                float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                ballObject.transform.Rotate(Vector3.right, verticalInput);
                ballObject.transform.Rotate(Vector3.up, horizontalInput, Space.World);
            }
        }
    }

}
