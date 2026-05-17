using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private TPMovement tpMovement;

    [SerializeField] private float teleportCooldown = 15f;

    private void Start()
    {
        tpMovement = GetComponent<TPMovement>();

        StartCoroutine(BossRoutine());

    }

    private IEnumerator BossRoutine()
    {
        while (true)
        {
            // Espera 15 segundos
            yield return new WaitForSeconds(teleportCooldown);

            // Faz o teleport
            yield return StartCoroutine(tpMovement.TeleportRoutine());
        }
    }
}