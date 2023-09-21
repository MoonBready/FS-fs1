using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveSpeed = 8;

    public Projectile laserBase;

    public GameObject retryScreen;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;


        

        OnPlayerDeath();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(laserBase, transform.position + new Vector3(0,1), Quaternion.identity);
    }

    private void OnPlayerDeath()
    {
        if (GameManager.Instance.Lives <= 0)
        {
            spriteRenderer.enabled = false;
            this.enabled = false;
            retryScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
