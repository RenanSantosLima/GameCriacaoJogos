using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private IsGroundedChecker groundedChecker;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        groundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Update()
    {
        bool isMoving = GameManager.Instance.inputManager.Movement != 0;
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", !groundedChecker.IsGrounded());
    }
}
