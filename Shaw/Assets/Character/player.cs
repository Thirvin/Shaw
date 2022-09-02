using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AI;

public class Player : Character
{
    public int talent = 0, ex_career = 0, ex_habit = 0;

<<<<<<< Updated upstream
    void Update()
=======
    NavMeshAgent agent;

    [SerializeField] private LayerMask groundMask;
    Camera mainCamera;

    public LayerMask npcLayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();

        if (Input.GetKeyDown(KeyCode.F)) CastInteractionRay();
    }


    void CastInteractionRay()
>>>>>>> Stashed changes
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f, npcLayer);
        if (hit)
        {
<<<<<<< Updated upstream
            this.GetComponent<NPCManager>().Build();
=======
            hitInfo.transform.GetComponent<NPC>().Talk(this);
>>>>>>> Stashed changes
        }
    }


    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
<<<<<<< Updated upstream
            this.GetComponent<NPCManager>().Leave();
        }


        //for NPC time test
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            GetComponent<NPCManager>().WorkTime();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            GetComponent<NPCManager>().RestTime();
=======
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
>>>>>>> Stashed changes
        }
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    private void FixedUpdate()
    {
        Vector3 inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 movement = inputMovement.normalized * 0.2f;

        agent.Move(movement);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }
}
