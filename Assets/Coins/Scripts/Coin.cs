using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    string itemName;

    float rotateY = 0f;
    [SerializeField]
    float spinspeed = 0.3f;
    [SerializeField]
    bool isSpinable = true;
    [SerializeField]
    int pointValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {


        if (collider.tag == "Car")
        {
            Interact();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinable == true)
        {
            if (rotateY < 360f)
            {
                Spin();
            }
            else
            {
                rotateY = 0f;
                Spin();
            }
        }
    }

    public void Spin()
    {
        transform.localRotation = Quaternion.Euler(0f, rotateY, 0f);
        rotateY += spinspeed;
    }

    public void Interact()
    {
        Debug.Log("Picked up " + transform.name);
        GameManager.IncrementScore(pointValue);
        Destroy(gameObject);
    }
}
