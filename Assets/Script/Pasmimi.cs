using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasmimi : Enemy
{
    int dirX;
    int timeDown;

    protected virtual new void Awake()
    {
        base.Awake();
        transform.position = new Vector2(Random.Range(-1.6f, 1.6f), 1.2f);
        dirX = Random.Range(0, 2) == 0 ? -1 : 1; // rand [0,2) -> 0 or 1
        timeDown = Random.Range(40, 50);
    }

    void Ai()
    {
        if (timeDown > 0)
        {
            Move(new Vector2(0, -1));
            timeDown--;
        }
        else
        {
            Move(new Vector2(dirX, 0));
            if (dirX > 0 && GetPosition().x > 1.6 || dirX < 0 && GetPosition().x < -1.6)
            {
                timeDown = Random.Range(10, 20);
                dirX *= -1;
            }
        }
        if (Random.Range(0, 100) == 0)
            Shoot();
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        Ai();
    }
}
