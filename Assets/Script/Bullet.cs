using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity
{
    public bool piercing;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public string owner;

    // Update is called once per frame
    protected virtual void Update()
    {
        Move(direction);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != owner && (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy" || (collider.gameObject.tag == "Bullet" && piercing && collider.GetComponent<Bullet>().owner != owner)))
        {
            float colliderHp = collider.gameObject.GetComponent<Entity>().hp;

            collider.gameObject.GetComponent<Entity>().TakeDamage(hp);
            if (piercing)
                TakeDamage(colliderHp);
            else
                Die();
        }
    }
}