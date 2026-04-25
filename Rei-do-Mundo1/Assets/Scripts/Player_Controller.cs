using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private float nextFire;
    private Vector2 fireDirection;

    // Conectar no Player Input → Fire (Vector2)
    public void OnFire(InputAction.CallbackContext context)
    {
        fireDirection = context.ReadValue<Vector2>();
    }

    void Update()
    {
        TryShoot();
    }

    void TryShoot()
    {
        // Não atira se não houver direção
        if (fireDirection == Vector2.zero) return;

        // Controle de fire rate
        if (Time.time < nextFire) return;

        nextFire = Time.time + fireRate;

        Shoot(fireDirection.normalized);
    }

    void Shoot(Vector2 dir)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        BulletMovement bm = bullet.GetComponent<BulletMovement>();
        bm.SetDirection(dir);
    }
}