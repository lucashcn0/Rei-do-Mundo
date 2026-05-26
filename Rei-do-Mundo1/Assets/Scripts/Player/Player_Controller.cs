using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Shooter shooting;

    void Awake()
    {
        shooting = GetComponent<Shooter>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (shooting != null)
        {
            shooting.SetFireDirection(context.ReadValue<Vector2>());
        }
    }
}