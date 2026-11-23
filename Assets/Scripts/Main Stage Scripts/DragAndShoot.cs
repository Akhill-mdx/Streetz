using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        Debug.Log("Mouse Dwn at: " + mousePressDownPos);
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Debug.Log("Mouse Up: " + mouseReleasePos);

        //Shoot(mousePressDownPos - mouseReleasePos);
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    private float forceMultiplier = 3;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        Debug.Log("Force: " + Force);
        rb.AddForce(new Vector3(Force.z, Force.x, Force.y) * forceMultiplier);

    }
}
