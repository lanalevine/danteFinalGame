using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = .05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
         Debug.Log("this is a test 1");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(canMove){
        if(movementInput != Vector2.zero){
            bool success = TryMove(movementInput);

            if(!success && movementInput.x >0){
                success = TryMove(new Vector2(movementInput.x,0));
            }
            if(!success && movementInput.y >0){
                  success = TryMove(new Vector2(0,movementInput.y));
            }
            animator.SetBool("isMoving", success);

        }
        else{
            animator.SetBool("isMoving", false);
        }

        //SET DIRECTION OF MOVING SPRITE
        if(movementInput.x < 0){
            spriteRenderer.flipX = true;
        }
        else if(movementInput.x > 0){
            spriteRenderer.flipX = false;
        }

    }
    }

    private bool TryMove(Vector2 direction){
         int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else{
                return false;
            }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordAttack");
        SwordAttack();
    }

    public void SwordAttack(){
        LockMovement();

        Debug.Log("this is a test 5");

        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        }
        else{
            swordAttack.AttackRight();
        }

    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
