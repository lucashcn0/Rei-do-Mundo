using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerShooting shooting;

    void Awake()
    {
        shooting = GetComponent<PlayerShooting>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (shooting != null)
        {
            shooting.SetFireDirection(context.ReadValue<Vector2>());
        }
    }
}