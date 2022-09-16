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
    public int talent = 0, ex_career = 0, ex_habit = 0,level = 0;



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
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f, npcLayer);
        if (hit)
        {
            hitInfo.transform.GetComponent<NPC>().Talk(this);
            Get_Diologue(hitInfo.transform.GetComponent<NPC>());
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
        Vector3 movement = inputMovement.normalized * 0.2f;

        agent.Move(movement);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }
    void Get_Diologue(NPC npc)
    {
        string file_name = "Assets/Resources/";
        file_name += npc.name + "/" + SceneManager.GetActiveScene().name + "/";
        file_name += level % 5 == 0 ? level / 5 -1 : level / 5 + "/";
        file_name += npc.Favorbility % 10 == 0 ? npc.Favorbility / 10 -1 : npc.Favorbility / 10 + "/";
        DirectoryInfo di = new DirectoryInfo(file_name);
        FileInfo[] files = di.GetFiles("*.prefab");
        int fileCount = files.Length; //取得個數
        System.Random crandom = new System.Random();
        file_name += crandom.Next(fileCount-1) + ".prefab";
        /*
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(file_name);
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("MyObject");
        Instantiate(prefab);
        */
        Debug.Log(file_name);
        Instantiate(Resources.Load(file_name));        
    }
}
