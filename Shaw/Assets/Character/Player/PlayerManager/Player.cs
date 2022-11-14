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
    [Header("Stats")]
    public int talent = 0, ex_career = 0, ex_habit = 0,level = 1;
    public CharacerStatus MAG = new CharacerStatus(0);
    public CharacerStatus DEF = new CharacerStatus(0);
    public CharacerStatus ATK = new CharacerStatus(0);
    public int INT = 0;
    public int STR = 0;
    public CharacerStatus DEX = new CharacerStatus(0);
    public CharacerStatus LUK = new CharacerStatus(0);
    public Weapon weapon;
    public GameObject defaultWeapon;
    NavMeshAgent agent;

    [Header("Settings")]
    [SerializeField] private LayerMask groundMask;
    Camera mainCamera;

    public LayerMask npcLayer;


    public delegate void Attack();
    public Attack attack;

    public delegate void ChangeInventoryState();
    public ChangeInventoryState changeInventoryState;
    private void OnEnable()
    {
        PlayerManager.Instance.player = this;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        PlayerManager.Instance.SpawnDefaultWeapon();
    }

    private void Update()
    {
        Aim();
    }

    //Might need a controller version
    //example, turn vector into angle as direction
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
    public void CastInteractionRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f, npcLayer);
        if (hit)
        {
            hitInfo.transform.GetComponent<NPC>().Talk(this);
        }
    }

    public void Move(Vector2 input)
    {
        Vector3 inputMovement = new Vector3(input.x, 0, input.y);
        Vector3 movement = inputMovement.normalized * Speed;

        agent.Move(movement);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }

}
