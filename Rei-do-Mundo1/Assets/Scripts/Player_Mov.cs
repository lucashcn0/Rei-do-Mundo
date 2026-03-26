using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [Header("Componentes do Player")]
    public Rigidbody2D rb;
    private Vector2 moveInput;
    
    [Header("Especificações")]
    public float MoveSpeed;
    bool moving;
    public float friction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * MoveSpeed;

        if(moving == false) 
        {
            moveInput *= friction;
        }
    }

    public void Move(InputAction.CallbackContext context)   
    {
        moving = true;
        moveInput = new Vector2(context.ReadValue<Vector2>().x,context.ReadValue<Vector2>().y);
        
        if(context.canceled)
        {
            moving = false;
        
        }

    }

}