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
    
    public Reap reap;

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
         reap = GameObject.Find("ReapHitbox").GetComponent<Reap>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {

         if (Input.GetKeyDown("return"))
         {
             Reaper();
         }


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

    public void Reaper(){
        animator.SetTrigger("reapAttack");
        LockMovement();

        if(reap==null){
            Debug.Log("null");
        }
        else{

        if(spriteRenderer.flipX == true){
            reap.ReapLeft();
            Debug.Log("This is def workign");

        }
        else{
            reap.ReapRight();
            Debug.Log("This is def workign");

        }
        }
    }

    

    public void SwordAttack(){
        LockMovement();

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

    public void EndReap() {
        Debug.Log("testie1asdf");
        UnlockMovement();
        reap.StopReap();
        Debug.Log("testie");
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
