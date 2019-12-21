using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    ParticleSystem ps;
    public float rotation;

    //public float GetHalfArc() => ps.shape.arc / 2f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        //ps.main.startColor = ParticleSystem.MinMaxGradient
        //ps.Emit(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 1, 5, new Color32(255, 0, 0, 255));
        //ps.shape.arc = 60f;
        //ps.transform.rotation.z = rotation - ps.shape.arc / 2f;
        Destroy(gameObject, ps.main.duration);
    }
}
