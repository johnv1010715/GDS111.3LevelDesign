using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    Transform player;

    [SerializeField]
    Vector3 offset;

	void Start ()
    {

       

	}
	
	void Update ()
    {

        transform.position = player.position + offset;
        transform.LookAt(player);

	}
}
