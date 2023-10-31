using UnityEngine;

public class Car_Behavior : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float maxSpeed = 10f;
    public float accelerationSpeed = 1f;
    public float decelerationSpeed = 1f;
    public float decelerationSpeedOverTime = 0.25f;
    public float steerAngle = 10f;
    public float steerSpeed = 0.02f;

    private float currentSpeed = 0f;
    private bool isGrounded;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float accelerateInput = Input.GetAxis("GasPedal");
        float brakeInput = Input.GetAxis("BrakePedal");
        float steerInput = Input.GetAxis("Steering");

        if (accelerateInput > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, accelerationSpeed * Time.deltaTime);
        }
        else if (brakeInput > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, -maxSpeed, decelerationSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, decelerationSpeedOverTime * Time.deltaTime);
        }

        Vector3 moveForce = transform.forward * currentSpeed;
        rigidBody.AddForce(moveForce);

        float turnAmount = steerInput * steerAngle;

        if (turnAmount != 0 && isGrounded)
        {
            rigidBody.drag = 4.5f;
        }
        else
        {
            rigidBody.drag = 3f;
        }

        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
    }
}