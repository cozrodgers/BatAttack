using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator m_animator;
    Attack m_attack;
    float horInput;
    SpriteRenderer _renderer;
    [SerializeField] float movementSpeed;
    private bool isRunning;
    public bool IsRunning { get { return isRunning; } }

    // Start is called before the first frame update
    void Start()
    {
        m_attack = GetComponent<Attack>();
        m_animator = GetComponent<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player sprite is missing a sprite renderer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");

        if (GameManager.Instance.IsPlaying)
        {
            HandleMovement();
            if (horInput < 0)
            {
                // flip
                transform.localScale = new Vector3(-1, 1, 1);

            }
            else if (horInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
    }

    void HandleMovement()
    {
        //get keys
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementSpeed, 0f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed, 0f) * Time.deltaTime;
        }
        //add vector to position of the player

        if (Mathf.Abs(horInput) > 0)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        m_animator.SetBool("isRunning", isRunning);
    }


}
