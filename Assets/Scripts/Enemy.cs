using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float minDistance = 1f;
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] int hp = 100;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AudioClip dieSFX;
    [SerializeField] int damage = 10;
    [SerializeField] int attackRange = 2;
    [SerializeField] Animator anim;
    [SerializeField] int scorePoints;
    


    float elapsed;

    private bool isDead;

    Vector3 startPosition;
    Vector3 targetPosition;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
        targetPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if distance is bigger than min distance
        transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

        if (hp <= 0 && !isDead)
        {
            Die();
        }

        // Attack player

        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            Debug.Log("In range");
            //Run attack coroutine
            StartCoroutine(Pounce());
        }

    }
    IEnumerator Pounce()
    {
        anim.SetTrigger("Pounce");
        yield return new WaitForSeconds(2f);
    }


    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    public void Die()
    {
        GameManager.Instance.IncreaseScore(scorePoints);
        GetComponent<AudioSource>().PlayOneShot(dieSFX);
        isDead = true;
        rb.gravityScale = 10;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }



}
