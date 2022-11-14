using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public Player player;

    public string playerName = "FatGuy";

    public List<Effect> effects = new List<Effect>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(TickEffects());
    }
    public void SpawnDefaultWeapon()
    {
        Instantiate(player.defaultWeapon, player.transform);
    }
    public void AddEffect(Effect effect)
    {
        StopAllCoroutines();
        effects.Add(effect);
        StartCoroutine(TickEffects());
    }
    public IEnumerator TickEffects()
    {
        //Can't use a foreach because foreach can't be changed during its statement
        if (effects == null) yield break;
        for (int i = effects.Count - 1; i >= 0; i--)
        {
            Debug.Log("Tick effect" + effects[i]);
            if (effects[i].active())
            {
                effects.Remove(effects[i]);
                Debug.Log(PlayerManager.Instance.player.ATK.F_value);
            }
        }


        //Need function to refresh all player mod

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TickEffects());
    }

}
