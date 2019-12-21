using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bullet;
    public int cooldown;
    public float arc;
    int cooldownValue = 0;

    public void Shoot()
    {
        if (cooldownValue >= cooldown)
        {
            Bullet clone = Instantiate(bullet, transform.position, transform.rotation);
            float angle = Random.Range(-arc / 2f, arc / 2f);

            angle -= transform.rotation.eulerAngles.z * (transform.parent.GetComponent<SpriteRenderer>().flipY ? -1 : 1);
            angle *= Mathf.Deg2Rad;
            clone.direction.x = Mathf.Sin(angle);
            clone.direction.y = Mathf.Cos(angle) * (transform.parent.GetComponent<SpriteRenderer>().flipY ? -1 : 1);
            clone.owner = transform.parent.tag;
            clone.transform.localScale = new Vector3(clone.transform.localScale.x, clone.transform.localScale.y * (transform.parent.GetComponent<SpriteRenderer>().flipY ? -1 : 1), clone.transform.localScale.z);
            cooldownValue = 0;
        }
    }

    // Update is called once per frame
    public void Update()
    {   
        cooldownValue++;
    }
}
