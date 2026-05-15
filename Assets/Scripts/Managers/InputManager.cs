using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singletons<InputManager>
{
    private InputManager()
    {
        
    }
    public bool OnGetKeyDown_W()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            return true;
        }
        return false;
    }
    public bool OnGetKeyDown_A()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        return false;
    }
    public bool OnGetKeyDown_S()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            return true;
        }
        return false;
    }
    public bool OnGetKeyDown_D()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            return true;
        }
        return false;
    }
    public bool OnGetKeyDown_Space()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }
}
