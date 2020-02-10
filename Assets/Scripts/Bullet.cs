using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 30f;
    public GameObject sparkPrefab;

    Collider2D collider;
    SpriteRenderer spriteRend;
    CameraShake shaker;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        shaker = Camera.main.GetComponent<CameraShake>();
    }

    public void Shoot(Vector2 dir)
    {
        transform.right = dir.normalized;
        rb.velocity = dir.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(sparkPrefab, transform.position, Quaternion.identity);
        collider.enabled = false;
        spriteRend.enabled = false;
        shaker.ShakeIt((transform.position - shaker.transform.position).magnitude);
        Destroy(rb);
        Destroy(gameObject, 2);
    }
}
