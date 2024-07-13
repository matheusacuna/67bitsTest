using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputs : MonoBehaviour
{
    private InputMap input;

    public static MyInputs instance;

    private void Awake()
    {
        instance = this;

        input = new InputMap();
        input.Player.Enable();
    }
    private void OnEnable() => input.Player.Enable();

    public static InputMap GetInput()
    {
        return instance.input;
    }
}
