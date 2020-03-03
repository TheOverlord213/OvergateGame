using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class PlayerRailController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent PlayerAgent { get; private set; }
    public int playerSpeed;

    public Transform[] targetPoints;
    private Vector3 playerStartPosition;
    private int destPoint = 0;
    bool firstPointReached = false;

    private float playerWaitChecker = 0;

    private bool movementStarted = false;

    public GameObject cameraRig;
    public GameObject cameraRigCamera;
    public float cameraRigPos;
    public float cameraRigCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        PlayerAgent.updateRotation = false;
        PlayerAgent.updatePosition = true;
        PlayerAgent.speed = playerSpeed;
        playerStartPosition = PlayerAgent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ResetCameraPos();

        if (movementStarted)
            RailController();
        else
        {
            PlayerAgent.transform.position = playerStartPosition;
        }
              
    }

    void ResetCameraPos()
    {
        cameraRig.transform.localPosition = new Vector3(cameraRig.transform.localPosition.x, cameraRigPos, cameraRig.transform.localPosition.z);
        cameraRigCamera.transform.localPosition = new Vector3(cameraRigCamera.transform.localPosition.x, cameraRigCameraPos, cameraRigCamera.transform.localPosition.z);
    }

    void RailController()
    {
        // Returns if no points have been set up
        if (targetPoints.Length == 0)
            return;
        else
        {
            PlayerAgent.SetDestination(targetPoints[destPoint].position);
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

    public void MovementBegun()
    {
        movementStarted = true;
    }
}
