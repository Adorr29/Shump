using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Enemy[] enemyList;
    List<int> enemyRate = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyList.Length; i++)
            enemyRate.AddRange(Enumerable.Repeat(i, enemyList[i].spawnRate));
        InvokeRepeating("SpawnEnenmy", 1, 1);
    }

    void SpawnEnenmy()
    {
        Instantiate(enemyList[enemyRate[Random.Range(0, enemyRate.Count)]], new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // ?
    }
}
