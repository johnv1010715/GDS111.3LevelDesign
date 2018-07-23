using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float speed = 4f;

    // The motion input for the player
    Vector3 input = Vector3.zero;

    Rigidbody rb;

    GameObject player;

    [SerializeField]
    Transform weapon;

    [SerializeField]
    GameObject primaryWeapon;


    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += (Vector3)input * speed * Time.deltaTime;

        PlayerAim();
        Shoot();
    }

    void PlayerAim()
    {

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hits;

        if(Physics.Raycast(mouseRay, out hits))
        {

            Vector3 positionFromPlayer = hits.point - transform.position;

            positionFromPlayer.y = 0f;

            Quaternion playerDirection = Quaternion.LookRotation(positionFromPlayer);

            rb.MoveRotation(playerDirection);

        }

    }

    void Shoot()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(primaryWeapon, weapon.transform.position, weapon.rotation);

        }

    }
}
