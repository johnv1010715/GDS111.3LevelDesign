using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStateSystem : MonoBehaviour
{

    public enum State
    {
        Roaming,
        Chasing,
        Dead
    }

    State currentState = State.Roaming;

    NavMeshAgent navAgent;

    GameObject player;

    [SerializeField]
    float searchRadius = 5.5f;

    [SerializeField]
    float searchAngle = 45;

    [SerializeField]
    float targetOffset;

    [SerializeField]
    List<Transform> waypoints;

    int currentWaypoint = 0;

    [SerializeField]
    int health = 100;

    bool isDead = false;

	void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();

    }

    void Update ()
    {

        switch (currentState)
        {

            case State.Roaming:
                Roaming();
                break;
            case State.Chasing:
                Chasing();
                break;
            case State.Dead:
                Dead();
                break;

        }

        if ((transform.position - player.transform.position).magnitude <= searchRadius && IsChasingPlayer())
            currentState = State.Chasing;
        else
            currentState = State.Roaming;
        

	}

    void Roaming()
    {

        if (waypoints.Count == 0)

            return;

        navAgent.SetDestination(waypoints[currentWaypoint].position);

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < targetOffset)
        {

            currentWaypoint++;
            if(currentWaypoint >= waypoints.Count)
            {

                currentWaypoint = 0;

            }

        }

    }

    void Chasing()
    {

        navAgent.SetDestination(player.transform.position);

    }

    void Dead()
    {
        if (isDead == true)
        { 
            Destroy(gameObject, 2);
        }
    }

    void death()
    {

        if(health <= 0)
        {
            isDead = true;
        }

    }

    bool IsChasingPlayer()
    {

        Vector3 heading = transform.forward;
        Vector3 playerVector = (player.transform.position - transform.position).normalized;
        float dotProduct = Vector3.Dot(heading, playerVector);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (angle <= searchAngle)
            return true;
        else
            return false;

    }
}
