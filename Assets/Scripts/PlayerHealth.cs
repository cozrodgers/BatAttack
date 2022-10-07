using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxhp = 100;
    [SerializeField] int hp;
    AudioSource audioSource;
    [SerializeField] HealthBar healthbar;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] Animator anim;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        healthbar.SetMaxHealth(maxhp);
        healthbar.SetHealth(maxhp);
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        healthbar.SetHealth(hp);
    }

    void Update()
    {
        if (hp <= 0 && GameManager.Instance.IsPlaying)
        {
            anim.SetBool("isDead", true);
            audioSource.PlayOneShot(deathSFX, 0.5f);
            GameManager.Instance.TriggerDeath();
        }
    }

}
