using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class CharacterController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent CharacterAgent { get; private set; }
    public int characterSpeed;

    public Transform[] targetPoints;
    //private Vector3 characterStartPosition;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        CharacterAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        CharacterAgent.updateRotation = false;
        CharacterAgent.updatePosition = true;
        CharacterAgent.speed = characterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
    }

    public void CharacterMovement()
    {
        // Returns if no points have been set up
        if (targetPoints.Length == 0)
            return;
        else
        {
            CharacterAgent.SetDestination(targetPoints[destPoint].position);
        }

        if (!CharacterAgent.pathPending && CharacterAgent.remainingDistance < 0.5f)
        {
            destPoint = (destPoint + 1) % targetPoints.Length;
        }
    }
}
