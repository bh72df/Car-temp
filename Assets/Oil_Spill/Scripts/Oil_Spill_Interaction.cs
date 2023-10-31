using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil_Spill_Interaction : MonoBehaviour
{
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.tag == "Car")
        {
            Test_Car_Control Car_Behaviour_Script = Collider.GetComponent<Test_Car_Control>();

            if (Car_Behaviour_Script != null)
            {
                Car_Behaviour_Script.Current_Speed = 0.5f;
            }
        }
    }
}
