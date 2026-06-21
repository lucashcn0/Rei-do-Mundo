using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BossController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;

    [Header("Timers")]
    [SerializeField] private float aimRefreshRate = 0.2f;
    [SerializeField] private float teleportCooldown = 15f;

    private Shooter shooter;
    private TPMovement tpMovement;

    private Health health;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        tpMovement = GetComponent<TPMovement>();
    }

    private void Start()
    {
        // Verificações de segurança
        if (player == null)
        {
            Debug.LogError("Player não foi colocado no Inspector!");
            return;
        }

        if (shooter == null)
        {
            Debug.LogError("PlayerShooting não encontrado!");
            return;
        }

        if (tpMovement == null)
        {
            Debug.LogError("TPMovement não encontrado!");
            return;
        }

        // Inicia as rotinas
        StartCoroutine(AimRoutine());
        StartCoroutine(TeleportRoutine());
    }

    // =========================
    // MIRA NO PLAYER
    // =========================
    private IEnumerator AimRoutine()
    {
        while (true)
        {
            if (!tpMovement.isTeleporting)
            {
                AimAtPlayer();
            }
            else
            {
                // Para de atirar durante teleport
                shooter.SetFireDirection(Vector2.zero);
            }

            yield return new WaitForSeconds(aimRefreshRate);
        }
    }

    private void AimAtPlayer()
    {
        Vector2 direction =
            (player.position - transform.position).normalized;

        shooter.SetFireDirection(direction);
    }

    // =========================
    // TELEPORTA
    // =========================
    private IEnumerator TeleportRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportCooldown);

            yield return StartCoroutine(tpMovement.TeleportRoutine());
        }
    }

    public void RukasuDeath()
    {
        //ANIMAÇÃO DE MORTE
        Destroy(gameObject);
        Debug.Log("Morte no controller");
    }
}