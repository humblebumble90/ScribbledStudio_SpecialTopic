using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdScript : MonoBehaviour
{
    private int Num;
    public Rigidbody rb;
    public bool grounded;
    public float jumpForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Num = Random.Range(1, 100);
        if (grounded == true)
        {
            if (Num == 45)
            {
                this.transform.position += new Vector3(0, 1.5f, 0);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "stage")
        {
            grounded = true;
        }
    }
}
