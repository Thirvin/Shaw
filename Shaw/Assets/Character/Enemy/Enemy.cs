using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int B_MAG,B_DEF,B_INT,B_STR,B_DEX,B_LUK,B_ATK;
    public int hp = 0;
    public int index = -1;

    public Material mat;

    private void Start()
    {
        mat.color = Color.white;
    }
    void Update()
    {
        move();
    }
    void move()
    {

    }
    public virtual void Attack()
    {
        return;
    }
    public void Hurt(int damage)
    {
        double def = (B_DEF/(B_DEF+100));
        hp -= (int)(damage*def);
        StartCoroutine(HurtAnim());
    }

    public IEnumerator HurtAnim()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        mat.color = Color.white;
        Debug.Log("ASDSAD");
    }
}
