using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Stats")]
    [SerializeField] private float fireRate = 0.2f;

    private float nextFire;
    private Vector2 fireDirection;

    public void SetFireDirection(Vector2 dir)
    {
        fireDirection = dir;
    }

    void Update()
    {
        TryShoot();
    }

    void TryShoot()
    {
        if (fireDirection == Vector2.zero) return; // se direção = null, retorna.

        if (Time.time < nextFire) return; //controle de cooldown

        nextFire = Time.time + fireRate; //"agenda" o proximo tiro

        Shoot(fireDirection.normalized); //agora sim está chamando o disparo
    }

    void Shoot(Vector2 dir)
    {
        //da 40 até a 47 é so por segurança em caso de esquecer algo (experiencia propria)
        
        if (bulletPrefab == null)
        {
            Debug.LogError("bulletPrefab virou NULL em runtime!"); //tem que pegar da pasta assets, NÃO DA HIERARQUIA!!
        }

        if (firePoint == null)
        {
            Debug.LogError("firePoint virou NULL em runtime!");
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        BulletMovement bm = bullet.GetComponent<BulletMovement>(); //Pega o script da bala
        if (bm != null)
        {
            bm.SetDirection(dir); //define a direção
        }
        else
        {
            Debug.LogError("Prefab da bala sem BulletMovement!");
        }
    }
}