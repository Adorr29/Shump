using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    [HideInInspector]
    public Entity target;
    public int spawnRate;

    protected virtual new void Awake()
    {
        hp += Random.Range(-hp / 10f, hp / 10f);
        speed += Random.Range(-speed / 10f, speed / 10f);
        base.Awake();
    }

    void ChangeTarger()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");

        target = playerList[Random.Range(0, playerList.Length)].GetComponent<Entity>();
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        if (target == null)
            ChangeTarger();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Entity>().TakeDamage(hp);
            Die();
        }
    }
}
