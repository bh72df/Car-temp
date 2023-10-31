using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawning : MonoBehaviour
{
    public GameObject Coin_Prefab;
    public int Coin_Spawn_Amount = 20;

    void Start()
    {
        Coin_Spill_Spawn();
    }

    public void Coin_Spill_Spawn()
    {
        Transform Parent_Transform = transform;

        GameObject[] All_Spawn_Points = GameObject.FindGameObjectsWithTag("Coin_Spawn_Point");

        if (All_Spawn_Points.Length == 0)
        {
            Debug.LogError("No spawn points found.");
            return;
        }

        Coin_Spawn_Amount = Mathf.Min(Coin_Spawn_Amount, All_Spawn_Points.Length);

        for (int i = 0; i < Coin_Spawn_Amount; i++)
        {
            int Random_Point = Random.Range(0, All_Spawn_Points.Length);
            Vector3 Spawn_Position = All_Spawn_Points[Random_Point].transform.position;

            Spawn_Position.y += 1f;

            GameObject New_Coin = Instantiate(Coin_Prefab, Spawn_Position, Quaternion.identity);
            New_Coin.transform.parent = Parent_Transform;
        }
    }
}
