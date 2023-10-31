using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car_Behaviour_2 : MonoBehaviour
{
    private Rigidbody Rigid_Body;
    private Car_Control_Actions Car_Input_Controls;

    [SerializeField]
    private float Max_Speed = 30f;

    [SerializeField] 
    private float Acceleration_Speed = 2.5f;

    [SerializeField] 
    private float Deceleration_Speed = 4.5f;

    [SerializeField]
    private float Deceleration_Speed_Over_Time = 0.25f;

    [SerializeField]
    private float Steer_Angle = 10f;

    [SerializeField]
    private float Steer_Speed = 0.025f;

    public float Current_Speed = 0f;

    public bool Is_Grounded;

    public GameObject Car;

    private void Awake()
    {
        Car_Input_Controls = new Car_Control_Actions();
        Rigid_Body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Car_Input_Controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        Car_Input_Controls.Gameplay.Disable();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 Move_Input = Car_Input_Controls.Gameplay.Accelerate.ReadValue<Vector2>();
        float Accelerate_Input = Move_Input.y;

        if (Accelerate_Input > 0)
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, Max_Speed, Acceleration_Speed * Time.deltaTime);
        }

        else if (Accelerate_Input < 0)
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, -Max_Speed, Deceleration_Speed * Time.deltaTime);
        }

        else
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, 0f, Deceleration_Speed_Over_Time * Time.deltaTime);
        }

        Vector3 Move_Force = transform.forward * Current_Speed;
        Rigid_Body.AddForce(Move_Force);

        float Steer_Input = Move_Input.x * Steer_Speed;
        float Turn_Amount = Steer_Input * Steer_Angle;

        if (Turn_Amount > 0 || Turn_Amount < 0 && Is_Grounded)
        {
            Rigid_Body.drag = 4.5f;
        }

        else
        {
            Rigid_Body.drag = 3f;
        }

        Quaternion Turn_Rotation = Quaternion.Euler(0f, Turn_Amount, 0f);
        Rigid_Body.MoveRotation(Rigid_Body.rotation * Turn_Rotation);

        Rigid_Body.AddForce(Move_Force);

    }

    public void Brake()
    {
        Debug.Log("Brake Pressed");
        Current_Speed = 0.75f;
    }
}