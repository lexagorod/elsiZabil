using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  // Added since we're using a navmesh.

public class AI : MonoBehaviour
{
    // Variables to handle what we need to send through to our state.
    NavMeshAgent agent; // To store the NPC NavMeshAgent component.
    Animator anim; // To store the Animator component.
    public Transform player;  // To store the transform of the player. This will let the guard know where the player is, so it can face the player and know whether it should be shooting or chasing (depending on the distance).
    State currentState;
    private LineRenderer lr;
    public static Vector3[] path = new Vector3[0];

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>(); // Grab agents NavMeshAgent.
        anim = this.GetComponent<Animator>(); // Grab agents Animator component.
        currentState = new Idle(this.gameObject, agent, anim, player); // Create our first state.
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        path = agent.path.corners;
        currentState = currentState.Process(); // Calls Process method to ensure correct state is set.
        if (path != null && path.Length > 1)
      {
    lr.positionCount = path.Length;
    for (int i = 0; i < path.Length; i++)
      {
        lr.SetPosition(i, path[i]);
      }
      }
    }
}
