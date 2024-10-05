using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputAction;
    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputActions();
        playerInputAction.Enable();
    }
    public Vector2 GetMovmentVector()
    {
        Vector2 inputvector = playerInputAction.Player.Move.ReadValue<Vector2>();

        return inputvector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }



}
