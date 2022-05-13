using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    private float movementX;
    private float movementY;
    [SerializeField]
    private float moveForce = 10f;
    private Animator anim;
    public Rigidbody2D rb;
    private void Awake() {
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);
    }


    private void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();
        rb.velocity = new Vector2(movementX, movementY);
    }
    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        if(movementX >= movementY || movementY == 0)
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        if(movementY > movementX || movementX == 0)
            transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer() {
        if(movementX != 0)
        {
            if(movementX < 0)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
            }
            else if (movementX > 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);
            }
        }
        if(movementX == 0 && movementY == 0)
            {
                Debug.Log("stop animation");
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);

            }
            
        
    }
}

