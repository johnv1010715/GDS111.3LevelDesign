using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;

    float speed = 25f;

	void Start ()
    {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

	}

    void Update ()
    {



    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.2f);
    }

    void destroyWhenIdle()
    {

        Destroy(gameObject, 10f);

    }
}
