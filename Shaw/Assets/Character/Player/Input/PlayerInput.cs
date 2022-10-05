using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerControl playerControl;

    Player player;
    bool attacking;
    private void Awake()
    {
        player = GetComponent<Player>();
        playerControl = new PlayerControl();
        
        playerControl.Player.Interaction.started += ctx => player.CastInteractionRay();
        playerControl.Player.Attack.started += ctx => attacking = true;
        playerControl.Player.Attack.canceled += ctx => attacking = false;
        playerControl.Player.Inventory.started += ctx => player.changeInventoryState();
    }
    private void FixedUpdate()
    {
        player.Move(playerControl.Player.Movement.ReadValue<Vector2>());
        if (attacking)
        {
            player.attack();
        }
    }

    private void OnEnable()
    {
        playerControl.Player.Enable();
    }
    private void OnDisable()
    {
        playerControl.Player.Disable();
    }
}
