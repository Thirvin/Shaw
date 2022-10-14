using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int B_MAG,B_DEF,B_INT,B_STR,B_DEX,B_LUK,B_ATK;
    public int hp = 0;
    public int index = -1;
    // Start is called before the first frame update
    void update()
    {
        move();
    }
    void move()
    {

    }
    public virtual void attack()
    {
        return;
    }
    public void hurt(int damage)
    {
        double def = (B_DEF/(B_DEF+100));
        hp -= (int)(damage*def);

    }
}
