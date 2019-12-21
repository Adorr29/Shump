using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    // Update is called once per frame
    protected virtual new void Update()
    {
        base.Update();
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (Input.GetKey(KeyCode.Space))
            Shoot();
    }
}
