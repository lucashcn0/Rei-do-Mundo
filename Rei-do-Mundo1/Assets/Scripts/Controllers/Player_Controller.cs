using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
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

    public void PlayerDeath()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }
}