using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelayTime = 0.1f;
    public float speed = 0.5f;

    public virtual void Start()
    {
        StartCoroutine(DestroyDelay());
    }
    public virtual void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed);
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Hit obstacle
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //Hit enemy
            other.GetComponent<Enemy>().Hurt(0);
            Destroy(gameObject);
        }
    }
    public virtual IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(destroyDelayTime);
        Destroy(gameObject);
    }
}
