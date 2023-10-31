using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text speedText;
    public Rigidbody carRigidbody;

    public Image Speedometer_Image;
    public Sprite Speedometer_Green;
    public Sprite Speedometer_Yellow;
    public Sprite Speedometer_Red;

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude * 1f; 
        speedText.text = speed.ToString("F1");

        if (speed > 0 && speed <= 40)
        {
            Speedometer_Image.sprite = Speedometer_Green;
        }

        else if (speed > 40 && speed <= 70)
        {
            Speedometer_Image.sprite = Speedometer_Yellow;
        }

        else if (speed > 70)
        {
            Speedometer_Image.sprite = Speedometer_Red;
        }

        else
        {
            Speedometer_Image.sprite = Speedometer_Green;
        }

    }
}
