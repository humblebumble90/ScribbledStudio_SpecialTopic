using System;
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
        //transform.LookAt(direction + transform.position);
        if (vertical >= 0)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(new Vector3(horizontal, 0.0f, 0.0f)), Time.deltaTime * rotationSpeed);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }


    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag.Equals("ball") && Input.GetKey(KeyCode.Space))
        {
            var dif = this.transform.position - other.transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(dif * 1000f);
            Debug.Log("ball is thrown");
        }
    }

    private float Mathf(float v)
    {
        throw new NotImplementedException();
    }
}
