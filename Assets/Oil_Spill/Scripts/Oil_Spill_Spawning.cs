using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil_Spill_Spawning : MonoBehaviour
{
    public GameObject Oil_Spill_Prefab;
    public int Spill_Spawn_Amount = 12;

    void Start()
    {
        Oil_Spill_Spawn();
    }

    public void Oil_Spill_Spawn()
    {
        Transform Parent_Transform = transform;

        GameObject[] All_Spawn_Points = GameObject.FindGameObjectsWithTag("Oil_Spill_Spawn_Point");

        if (All_Spawn_Points.Length == 0)
        {
            Debug.LogError("No spawn points found.");
            return;
        }

        Spill_Spawn_Amount = Mathf.Min(Spill_Spawn_Amount, All_Spawn_Points.Length);

        for (int i = 0; i < Spill_Spawn_Amount; i++)
        {
            int Random_Point = Random.Range(0, All_Spawn_Points.Length);
            Vector3 Spawn_Position = All_Spawn_Points[Random_Point].transform.position;

            GameObject New_Oil_Spill = Instantiate(Oil_Spill_Prefab, Spawn_Position, Quaternion.identity);
            New_Oil_Spill.transform.parent = Parent_Transform;
        }
    }
}