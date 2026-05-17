using System.Collections;
using UnityEngine;

public class TPMovement : MonoBehaviour
{
    [Header("Teleport Points")]
    [SerializeField] private Transform[] tpPoints;

    [Header("Boss Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D bossCollider;

    [Header("Teleport Settings")]
    [SerializeField] private float hiddenTime = 1f;

    public bool isTeleporting;

    public IEnumerator TeleportRoutine()
    {
        isTeleporting = true;

        // SUMIR
        spriteRenderer.enabled = false;
        bossCollider.enabled = false;

        // ESCOLHE UM PONTO ALEATÓRIO
        Transform randomPoint = tpPoints[Random.Range(0, tpPoints.Length)];

        // MOVE O BOSS
        transform.position = randomPoint.position;

        // ESPERA ESCONDIDO
        yield return new WaitForSeconds(hiddenTime);

        // APARECE
        spriteRenderer.enabled = true;
        bossCollider.enabled = true;

        isTeleporting = false;
    }
}