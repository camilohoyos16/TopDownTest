using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputs : MonoBehaviour {

    public CharacterStatesManager m_StateManager;

    [Header("Input joysticks")]
    [SerializeField] private bool useJoysticks;
    [SerializeField] private Joystick rightJoystick;
    [SerializeField] private Joystick leftJoystick;

    private CharacterStates tempState;

    public float leftJoystickHorizontalValue {
        get
        {
            return Inputs.LeftJoystickMoveHorizontal(leftJoystick);
        }
    }
    public float leftJoystickVerticalValue {
        get
        {
            return Inputs.LeftJoystickMoveVertical(leftJoystick);
        }
    }
    public float rightJoystickHorizontalValue
    {
        get
        {
            return Inputs.RightJoystickMoveHorizontal(rightJoystick);
        }
    }
    public float rightJoystickVerticalValue {
        get
        {
            return Inputs.RightJoystickMoveVertical(rightJoystick);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempState = CharacterStates.idle;

        if (rightJoystickHorizontalValue != 0 || rightJoystickVerticalValue != 0)
        {
            tempState = CharacterStates.shooting;
        }

        if(leftJoystickHorizontalValue != 0 || leftJoystickVerticalValue != 0)
        {
            if(tempState == CharacterStates.shooting)
            {
                tempState = CharacterStates.runShooting;
            }
            else
            {
                tempState = CharacterStates.run;
            }
        }
        m_StateManager.ChangeChracterState(tempState);
    }
}
