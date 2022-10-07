using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator m_animator;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] bool coolingDown;
    [SerializeField] float cooldownTime;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    public LayerMask enemyLayers;

    private int damage = 100;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Update()
    {
        if(!GameManager.Instance.IsPlaying) {
            this.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!coolingDown)
            {
                _Attack();
            }
        }
    }

    public void _Attack()
    {
        m_animator.SetTrigger("attack");
        //detect enemies in the range of the attack
        coolingDown = true;
        StartCoroutine(AttackCooldown());
    }


    public IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        coolingDown = false;
    }

    public void OnAttackEvent()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemy")
            {

                enemy.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        audioSource.PlayOneShot(attackSFX);
    }


}
