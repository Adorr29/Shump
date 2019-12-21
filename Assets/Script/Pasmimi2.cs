using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasmimi2 : Enemy
{
    int dirX;

    protected virtual new void Awake()
    {
        base.Awake();
        transform.position = new Vector2(Random.Range(0, 2) == 0 ? -2 : 2, Random.Range(0.8f, 0.2f));
    }

    void Ai()
    {
        if (GetPosition().x < target.GetPosition().x - 0.1)
            dirX = 1;
        else if (GetPosition().x > target.GetPosition().x + 0.1)
            dirX = -1;
        else
            Shoot();
        Move(new Vector2(dirX, 0));
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        Ai();
    }
}
