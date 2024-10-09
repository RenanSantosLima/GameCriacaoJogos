using System;
using UnityEngine.InputSystem;

public class InputManager
{
    private PlayerControls playerControls;

    //movimentação
    public float Movement => playerControls.Gameplay.Movement.ReadValue<float>();

    //pulo
    public event Action OnJump;

    public InputManager()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();

        //ação do pulo
        playerControls.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }
}
