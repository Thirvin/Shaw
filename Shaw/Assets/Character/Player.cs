using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Player : Character
{
    public int talent = 0, ex_career = 0, ex_habit = 0,level = 1;
    public int MAG,DEF,INT,STR,DEX,LUK,ATK;
    public bool has_weapon = true;
    public string Weapon_Id = "Script_10001";
    NavMeshAgent agent;

    [SerializeField] private LayerMask groundMask;
    Camera mainCamera;

    public LayerMask npcLayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        gameObject.GetComponent<InventoryManager>().switch_weapon("10001");
    }

    private void Update()
    {
        Aim();

        if (Input.GetKeyDown(KeyCode.F)) CastInteractionRay();

        if(Input.GetKeyDown(KeyCode.L) && has_weapon) Attack();
    }

    private void Attack()
    {

        Item shoot = GetComponent(Type.GetType(Weapon_Id)) as Item;
        shoot.Shoot();

    }

    void CastInteractionRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f, npcLayer);
        if (hit)
        {
            hitInfo.transform.GetComponent<NPC>().Talk(this);
        }
    }


    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
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
        Vector3 movement = inputMovement.normalized * Speed;

        agent.Move(movement);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }

}
