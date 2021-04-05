using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
        Vector3 backwardDir = new Vector3(horizontal, 0.0f, 0.0f);
        //transform.LookAt(direction + transform.position);
        if (vertical >= 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(backwardDir), Time.deltaTime * rotationSpeed);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }


    }
}
