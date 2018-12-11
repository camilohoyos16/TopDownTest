using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStates
{
	idle,
    run,
	shooting,
    runShooting
}

public class CharacterStatesManager : MonoBehaviour {

	private static CharacterStates characterState;
    public static CharacterStates CharacterStateCurrent
    {
        get
        {
            return characterState;
        }
    }

    

    [SerializeField] private CharacterShootingState m_ShootingState;
    [SerializeField] private CharacterMovement m_MovementState;


    public void ChangeChracterState(CharacterStates newState){
		characterState = newState;
		switch (newState)
		{
			case CharacterStates.idle:
               m_ShootingState.enabled = false;
                m_MovementState.enabled = false;
                break;
            case CharacterStates.run:
                m_MovementState.enabled = true;
                break;
			case CharacterStates.shooting:
                m_ShootingState.enabled = true;

            break;
            case CharacterStates.runShooting:
                m_ShootingState.enabled = true;
                m_MovementState.enabled = true;
                break;
			default:
			break;
		}
	}
}
