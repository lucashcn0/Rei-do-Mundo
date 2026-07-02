using System.Collections;
using UnityEngine;

public class Tp_Boss : MonoBehaviour
{
    [Header("Teleport Points")]
    [SerializeField] private Transform[] tpPoints;

    [Header("Boss Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D bossCollider;
    [SerializeField] private Animator _animator;

    [Header("Teleport Settings")]
    [SerializeField] private float hiddenTime = 1f;

    public bool isTeleporting;

    public IEnumerator TeleportRoutine()
    {   
        isTeleporting = true;
        _animator.SetBool("IsTeleporting" ,true);

        // Espera entrar no estado
        yield return null;

        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("TP"))
        {
            yield return null;
        }

        // Espera a animação terminar
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }


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
        _animator.SetBool("IsTeleportingBack", true);
        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Tp_Saindo"))
        {
            yield return null;
        }

        // Espera a animação terminar
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
        _animator.SetBool("IsTeleportingBack", false);

        isTeleporting = false;
        _animator.SetBool("IsTeleporting" ,false);

    }
}