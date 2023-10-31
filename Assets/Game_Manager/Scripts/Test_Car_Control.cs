using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Test_Car_Control : MonoBehaviour
{
    InputAction accelerate, brakePedal, turn;

    private Rigidbody Rigid_Body;
    private Car_Control_Actions Car_Input_Controls;

    [SerializeField]
    private float Max_Speed = 10f;

    [SerializeField]
    private float Acceleration_Speed = 1f;

    [SerializeField]
    private float Deceleration_Speed = 1f;

    [SerializeField]
    private float Deceleration_Speed_Over_Time = 0.25f;

    //[SerializeField]
    //private float Steer_Angle = 10f;

    [SerializeField]
    private float Steer_Speed = 0.02f;

    public float Current_Speed = 0f;

    public bool Is_Grounded;

    public GameObject Car;

    private void OnEnable()
    {
        turn = GameManager.InputManager.inputActions.Gameplay.Turn;
        turn.Enable();

        accelerate = GameManager.InputManager.inputActions.Gameplay.Accelerate;
        accelerate.Enable();

        brakePedal = GameManager.InputManager.inputActions.Gameplay.BrakePedal;
        brakePedal.Enable();
    }

    private void OnDisable()
    {
        turn.Disable();
        accelerate.Disable();
        brakePedal.Disable();
    }

    void Start()
    {
        GameManager.ResetGame();
        Car_Input_Controls = new Car_Control_Actions();
        Rigid_Body = GetComponent<Rigidbody>();
        Cursor.visible = false;        

        GameManager.InputManager.inputActions.Gameplay.Accelerate.Enable();
        GameManager.InputManager.inputActions.Gameplay.BrakePedal.Enable();
        GameManager.InputManager.inputActions.Gameplay.Turn.Enable();
    }



    void Update()
    {
        RotateAndLook();
    }

    void FixedUpdate()
    {
        Debug.Log("Turn: " + turn.ReadValue<Vector2>().x);
        Debug.Log("Accelerate: " + accelerate.ReadValue<float>());
        Debug.Log("Break Pedal: " + brakePedal.ReadValue<float>());

        Locomotion();
    }

    

    void Locomotion()
    {
            float acceleration = accelerate.ReadValue<float>();
            float breaking = brakePedal.ReadValue<float>();
            float turning = turn.ReadValue<Vector2>().x * Steer_Speed;

        if (acceleration > 0)
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, Max_Speed, Acceleration_Speed * Time.deltaTime);
        }

        else if (breaking > 0)
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, -Max_Speed, Deceleration_Speed * Time.deltaTime);
        }

        else
        {
            Current_Speed = Mathf.MoveTowards(Current_Speed, 0f, Deceleration_Speed_Over_Time * Time.deltaTime);
        }

        Vector3 Move_Force = transform.forward * Current_Speed;
        Rigid_Body.AddForce(Move_Force);

        //turning *= Current_Speed;
        turning = Mathf.Clamp(turning, -5f, +5f);
        transform.Rotate(0f, turning, 0f);

        if (turning > 0 || turning < 0 && Is_Grounded)
        {
            Rigid_Body.drag = 4.5f;
        }

        else
        {
            Rigid_Body.drag = 3f;
        }
    }

    public void Brake()
    {
        Current_Speed = 0.75f;
    }

    void RotateAndLook()
    {
        //Vector2 lookInput = look.ReadValue<Vector2>();

        //rotateYaw = lookInput.x * mouseSensitivity;
        //rotateYaw += cameraContainer.transform.localRotation.eulerAngles.y;

        //rotatePitch -= lookInput.y * mouseSensitivity;
        //rotatePitch = Mathf.Clamp(rotatePitch, lookUpClamp, lookDownClamp);

        //cameraContainer.transform.localRotation = Quaternion.Euler(rotatePitch, rotateYaw, 0f);
    }
}
