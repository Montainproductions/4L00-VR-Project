using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicScript1 : MonoBehaviour
{

    private Rigidbody rb;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("d") == true){
            Move(new Vector2(1,0));
        }
        if (Input.GetKey("a") == true)
        {
            Move(new Vector2(-1, 0));
        }
        if (Input.GetKey("w") == true)
        {
            Move(new Vector2(0, 1));
        }
        if (Input.GetKey("s") == true)
        {
            Move(new Vector2(0, -1));
        }
        if (Input.GetKeyDown("space") == true)
        {
            Jump();
        }

        //Cam movement
        float sphereX = transform.position.x;
        float sphereY = transform.position.y;
        float sphereZ = transform.position.z;
        cam.transform.position = new Vector3(sphereX, sphereY, sphereZ-5);
    }

    private void Move(Vector2 direction)
    {
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * 1f, ForceMode.Force);
    }
    private void Jump()
    {
        rb.AddForce(new Vector3(0, 1, 0) * 1f, ForceMode.Impulse);
    }
}
