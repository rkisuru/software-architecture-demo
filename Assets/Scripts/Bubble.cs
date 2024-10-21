using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] Transform initialPosition;
    private new Collider2D collider;
    private Rigidbody2D rigidBody;

    public static event Action OnBubblePop;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = initialPosition.position;
        gameObject.SetActive(false);       
    }

    private void OnMouseDown()
    {
        transform.position = initialPosition.position;
        gameObject.SetActive(false);

        Score.Instance.AddScore();

        OnBubblePop?.Invoke();
    }
}
