using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed = 1;

    void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager.Instance.AddScore(100);
            Destroy(this.gameObject);
        }
    }
}
