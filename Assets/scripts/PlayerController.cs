using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int damagePerShot = 1;
    private string buttonToFire = "Z";

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = new Vector3(horizontal, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement);

        // Vertical movement
        float vertical = Input.GetAxis("Vertical");
        Vector3 verticalMovement = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(verticalMovement);

        if (Input.GetButtonDown("Fire"))
        {
            Input.GetButtonDown(buttonToFire);
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();

            if (enemy != null)
            {
                // If the ray hits an enemy, deal damage to it
                enemy.TakeDamage(damagePerShot);
            }
        }
    }
}
