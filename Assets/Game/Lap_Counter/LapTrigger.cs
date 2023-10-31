using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    [SerializeField]
    public bool LapMid = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Car" && LapMid == false)
        {         
                Lap();           
        }
        else if (collider.tag == "Car" && LapMid == true)
        {
            LapHalf();
        }
    }

    public void Lap()
    {
        GameManager.LapCounter();
    }
    public void LapHalf()
    {
        GameManager.LapMidway();
    }

}
