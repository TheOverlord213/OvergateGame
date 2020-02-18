using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class PlayerRailController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent PlayerAgent { get; private set; }

    private int playerSpeed = 3;
    private readonly int rotationSpeed = 5;

    public Transform[] targetPoints;
    private int destPoint = 0;
    bool firstPointReached = false;

    private float playerWaitChecker = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        PlayerAgent.updateRotation = false;
        PlayerAgent.updatePosition = true;
        PlayerAgent.speed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // allows the player to control their movement movement
        //PlayerMovement();
        RailController();
    }

    void PlayerMovement()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        position.x += moveHor * playerSpeed * Time.deltaTime;
        position.z += moveVer * playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    void RailController()
    {
        // Returns if no points have been set up
        if (targetPoints.Length == 0)
            return;
        else
        {
            PlayerAgent.SetDestination(targetPoints[destPoint].position);

            //Vector3 lookPos = targetPoints[destPoint].transform.position - PlayerAgent.transform.position;
            //lookPos.y = 0;
            //Quaternion targetRotation = Quaternion.LookRotation(lookPos);
            //PlayerAgent.transform.rotation = Quaternion.Slerp(PlayerAgent.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (!PlayerAgent.pathPending && PlayerAgent.remainingDistance < 0.5f)
        {
            if (firstPointReached)
            {
                playerWaitChecker += Time.deltaTime;
                int seconds = Mathf.RoundToInt(playerWaitChecker % 60.0f);
                if (seconds == 5)
                {
                    destPoint = (destPoint + 1) % targetPoints.Length;
                    playerWaitChecker = 0;
                }
            }
            else
            {
                // will only trigger once to alow the player to reach the first point without a pause
                firstPointReached = true;
                destPoint = (destPoint + 1) % targetPoints.Length;
            }


        }
            
    }
}
