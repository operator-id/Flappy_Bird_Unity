using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableObject : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    GameManager manager;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(manager.ScrollValue, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (manager.IsGameOver)
        {
            rigidBody.velocity = Vector2.zero;
        }
    }
}
