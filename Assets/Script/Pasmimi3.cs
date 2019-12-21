using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasmimi3 : Enemy
{
    protected virtual new void Awake()
    {
        base.Awake();
        transform.position = new Vector2(Random.Range(-1.6f, 1.6f), 1.2f);
    }

    void Ai()
    {
        Move(new Vector2(0, -1));
        Shoot();
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        Ai();
    }
}
