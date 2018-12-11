using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {


    private static KeyCode right = KeyCode.D;
    private static KeyCode right2 = KeyCode.RightArrow;
    private static KeyCode left = KeyCode.A;
    private static KeyCode left2 = KeyCode.LeftArrow;
    private static KeyCode jump = KeyCode.W;
    private static KeyCode jump2 = KeyCode.UpArrow;
    private static KeyCode jump3 = KeyCode.Space;

    //Joystick plugins inputs
    #region Joysticks
    public static float RightJoystickMoveVertical(Joystick rightJoystick)
    {
        return rightJoystick.Vertical;
    }

    public static float RightJoystickMoveHorizontal(Joystick rightJoystick)
    {
        return rightJoystick.Horizontal;
    }

    public static float LeftJoystickMoveVertical(Joystick leftJoystick)
    {
        return leftJoystick.Vertical;
    }

    public static float LeftJoystickMoveHorizontal(Joystick leftJoystick)
    {
        return leftJoystick.Horizontal;
    }
    #endregion

    //Keyboard inputs
    #region Keyboard
    public static bool MoveLeft
    {
        get { return CheckMoveLeft(); }
    }

    public static bool MoveRight
    {
        get { return CheckMoveRight(); }
    }

    public static bool Jump
    {
        get { return CheckJump(); }
    }
    
    private static bool CheckMoveRight(){
        if (Input.GetKey(right) || Input.GetKey(right2))
            return true;
        return false;
    }

    private static bool CheckMoveLeft(){
        if (Input.GetKey(left) || Input.GetKey(left2))
            return true;
        return false;
    }

    private static bool CheckJump()
    {
        if (Input.GetKeyDown(jump) || Input.GetKeyDown(jump2) || Input.GetKeyDown(jump3))
            return true;
        return false;
    }
    #endregion
}
