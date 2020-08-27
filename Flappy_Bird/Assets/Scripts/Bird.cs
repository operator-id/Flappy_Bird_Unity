using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float force = 100f;
    private Animator animator;
    private Rigidbody2D rigidBody;
    public int Score { get; set; }

    bool isDead = false;
    void Start()
    {
        Score = 0;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, force));
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Boundary")
        {
            isDead = true;
            FindObjectOfType<GameManager>().Die();
        }
    }
}
