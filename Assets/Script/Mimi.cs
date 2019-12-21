using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimi : Enemy
{
    float dirX = 0;
    int dirTime = 0;

    protected virtual new void Awake()
    {
        base.Awake();
        transform.position = new Vector2(Random.Range(-1.6f, 1.6f), 1.2f);
    }

    void Ai()
    {
        if (dirTime <= 0)
        {
            if (GetPosition().x < target.GetPosition().x)
                dirX = 1;
            else
                dirX = -1;
            if (Random.Range(0, 10) == 0)
                dirX *= -1;
            dirTime = Random.Range(10, 30);
        }
        Move(new Vector2(dirX, -2));
        dirTime--;
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        Ai();
    }
}
