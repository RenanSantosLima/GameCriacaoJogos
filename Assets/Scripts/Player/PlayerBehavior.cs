using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private IsGroundedChecker isGroundedChecker;

    //velocidade da movimentação e jump
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.inputManager.OnJump += HandleJump;
    }

    // Update is called once per frame
    private void Update()
    {
        float moveDirection = GameManager.Instance.inputManager.Movement;
        //transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);
        Vector2 directionToMove = new Vector2(moveDirection * moveSpeed, rigidBody.velocity.y);
        rigidBody.velocity = directionToMove;

        if (moveDirection < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            
        } else if (moveDirection > 0) {
            transform.localScale = Vector3.one;
        }
    }

    //pulo
    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        //rigidBody.velocity = Vector2.up * jumpForce;
    }
}
