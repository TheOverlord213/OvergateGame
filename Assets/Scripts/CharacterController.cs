using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class CharacterController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent characterAgent { get; private set; }
    public int characterSpeed;

    public Transform[] targetPoints;
    //private Vector3 characterStartPosition;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        characterAgent.updateRotation = false;
        characterAgent.updatePosition = true;
        characterAgent.speed = characterSpeed;
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
            characterAgent.SetDestination(targetPoints[destPoint].position);

            Vector3 lookPos = targetPoints[destPoint].position - characterAgent.transform.position;
            lookPos.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(lookPos);
            characterAgent.transform.rotation = Quaternion.Slerp(characterAgent.transform.rotation, targetRotation, 5 * Time.deltaTime);
        
        }

        if (!characterAgent.pathPending && characterAgent.remainingDistance < 0.5f)
        {
            destPoint = (destPoint + 1) % targetPoints.Length;
        }
    }
}
