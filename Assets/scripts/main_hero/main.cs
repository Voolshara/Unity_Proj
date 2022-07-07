using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class main : MonoBehaviour
{    
    public float rotationSpeed = 30f;
    public float deadZoneDegrees = 15f;


    public float Speed = 5f;
    [SerializeField] public float JumpForce = 300f;
    [SerializeField] public float DownForce = 300f;
 
    private Transform cameraT;
    private Vector3 cameraDirection;
    private Vector3 playerDirection;
    private Quaternion targetRotation;


    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
 
    private void Awake()
    {
        cameraT = Camera.main.transform;
    }
 
    private void FixedUpdate()
    {   
        // - Слежение за камерой

        cameraDirection = new Vector3(cameraT.forward.x, 0f, cameraT.forward.z);
        playerDirection = new Vector3(transform.forward.x, 0f, transform.forward.z);

        if(Vector3.Angle(cameraDirection, playerDirection) > deadZoneDegrees)
        {
            targetRotation = Quaternion.LookRotation(cameraDirection, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime * Mathf.Pow(1.1f, 
                                                                                                            (Vector3.Angle(cameraDirection, playerDirection) / 10)));
        }

        // - Слежение за камерой

        // - Движение

        MovementLogic();
        JumpLogic();
        ChechJump();
        Debug.Log(_isGrounded);
    }

    private void MovementLogic()
    {     
        if (_isGrounded ||  !_isGrounded)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");

                float moveVertical = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

                // что бы скорость была стабильной в любом случае
                // и учитывая что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
                transform.Translate(movement * Speed * Time.fixedDeltaTime);
            }
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                // Обратите внимание что я делаю на основе Vector3.up а не на основе transform.up
                // если наш персонаж это шар -- его up может быть в том числе и вниз и влево и вправо. 
                // Но нам нужен скачек только вверх! Потому и Vector3.up
                _rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
            }
        }
    }

    private void ChechJump(){

        if (!_isGrounded){

            _rb.AddForce(-transform.up * DownForce, ForceMode.Impulse);

        }

    }


    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}