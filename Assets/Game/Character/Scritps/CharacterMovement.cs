using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Movement varibles
    [SerializeField] private float movementSpeed;
    private Vector3 movementVector;
    public Vector3 MovementVector
    {
        get
        {
            return movementVector;
        }
    }

    //Components variables
    private Rigidbody m_RigidBody;

    private CharacterInputs m_Inputs;

    void Awake()
    {
        m_Inputs = GetComponent<CharacterInputs>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Character movement method
    /// </summary>
    /// <param name="direction">1= Rigth / 2=Left</param>
    private void Movement()
    {
        movementVector.x = (m_Inputs.leftJoystickHorizontalValue * movementSpeed * Time.deltaTime);
        movementVector.z = (m_Inputs.leftJoystickVerticalValue * movementSpeed * Time.deltaTime);
        m_RigidBody.velocity = movementVector;
    }

    private void OnDisable()
    {
        movementVector = Vector3.zero;
        m_RigidBody.velocity = movementVector;
    }


}
