using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    private float minimalSpeed = 0.1f;
    private bool isrunning = false;
    [SerializeField] private float moveSpeed = 10f;
    private Rigidbody2D rb;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    

    private void FixedUpdate()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovmentVector();
        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (moveSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minimalSpeed || Mathf.Abs(inputVector.y) > minimalSpeed)
        {
            isrunning = true;
        }
        else
        {
            isrunning=false;
        }
        
  

    }

    public bool IsRunning()
    {
        return isrunning;
    }
}
