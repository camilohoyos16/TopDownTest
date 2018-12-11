using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour {

    [SerializeField] private float rotationSpeed;

    private CharacterInputs m_Inputs;

    //Rotation variables
    private Vector3 rotationVector;
    private Vector3 aimVector;

    private void Awake()
    {
        m_Inputs = GetComponent<CharacterInputs>();
    }

    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        if (CharacterStatesManager.CharacterStateCurrent == CharacterStates.shooting || CharacterStatesManager.CharacterStateCurrent == CharacterStates.runShooting)
        {
            rotationVector.x = (m_Inputs.rightJoystickHorizontalValue * rotationSpeed * Time.deltaTime);
            rotationVector.z = (m_Inputs.rightJoystickVerticalValue * rotationSpeed * Time.deltaTime);
        }
        else
        {
            rotationVector.x = (m_Inputs.leftJoystickHorizontalValue * rotationSpeed * Time.deltaTime);
            rotationVector.z = (m_Inputs.leftJoystickVerticalValue * rotationSpeed * Time.deltaTime);
        }

        if (Mathf.Abs(rotationVector.x) >= 0.2)
        {
            aimVector.x = rotationVector.x;
        }
        if (Mathf.Abs(rotationVector.z) >= 0.2)
        {
            aimVector.z = rotationVector.z;
        }
        transform.rotation = Quaternion.LookRotation(aimVector.normalized);
    }
}
