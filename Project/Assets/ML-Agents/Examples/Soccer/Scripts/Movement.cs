using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public double maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= maxVelocity)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(speed * Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Vector3.left);
        }
    }
}
