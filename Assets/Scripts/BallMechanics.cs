using System.Runtime.CompilerServices;
using UnityEngine;

public class BallMechanics ; MonoBehaviour
{
  public Camera playerCamera;
  private float rotationX = 0;

  private bool canLook = true;
  
   if(canLook)
   {

    float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
    float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
    rotationX -= mouseY;
    rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

   }

}
