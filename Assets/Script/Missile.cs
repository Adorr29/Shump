using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    Entity target;

    void ChangeTarger()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag(owner == "Player" ? "Enemy" : "Player");

        foreach (GameObject gameObject in enemyList)
        {
            Entity entity = gameObject.GetComponent<Entity>();

            if (target == null || entity.hpMax > target.hpMax || entity.hpMax + 1 > target.hpMax && entity.GetPosition().y < target.GetPosition().y)
                target = entity;
        }
    }

    // Update is called once per frame
    protected virtual new void Update()
    {
        if (target == null)
        {
            ChangeTarger();
            if (target == null)
            {
                base.Update();
                return;
            }
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(target.GetPosition().y - GetPosition().y, target.GetPosition().x - GetPosition().x) * Mathf.Rad2Deg - 90));  //.SetLookRotation(new Vector3(0, 0, 1));// = Quaternion.LookRotation(new Vector3(0, 1, 0), new Vector3(Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), 0));
        direction.x = Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad);
        direction.y = Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad);
        if (transform.GetComponent<SpriteRenderer>().flipY)
            direction.y = -direction.y;
        base.Update();
    }
}
