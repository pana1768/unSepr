using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRender;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, player.Instance.IsRunning());
        AdjustPlayerFacingDirections();
        if (Input.GetKeyDown(KeyCode.Space)) // Или любую другую кнопку
        {
            PlayAttackAnimation();
        }
    }

    private void AdjustPlayerFacingDirections()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPos = player.Instance.GetPlayerPosition();

        if(mousePos.x < playerPos.x)
        {
            spriteRender.flipX = true;
        }
        else
        {
            spriteRender.flipX = false;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack"); // Замените "Attack" на имя вашего триггера
    }
}
