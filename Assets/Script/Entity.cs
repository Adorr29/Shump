using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    public GameObject explosion;
    public float hp;
    public float speed;
    [HideInInspector]
    public float hpMax;

    protected virtual void Awake()
    {
        hpMax = hp;
        rb = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetPosition() => rb.position;

    protected void Move(Vector2 dir)
    {
        dir.Normalize();
        rb.velocity = dir * speed;

        /*dir.Normalize();
        if (dir.magnitude == 0 && rb.velocity.magnitude > 0)
            Move(new Vector2(-rb.velocity.x, -rb.velocity.y));
        else
            rb.AddForce(dir * speed);*/
    }

    IEnumerator Blink() // Why ???
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        //StartCoroutine(Blink());
        hp -= damage;
        if (hp <= 0)
            Die();
    }

    protected void Die()
    {
        if (explosion != null)
            Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
