using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 10;
    public Collider swordCollider;
    void Start()
    {
        swordCollider.enabled = false;
    }

    public void SwingSword()
    {
        swordCollider.enabled = true;
        Invoke("DisableCollider", 0.2f);
    }
    
    private void DisableCollider()
    {
        swordCollider.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol tık
        {
            SwingSword();
        }
    }
}
