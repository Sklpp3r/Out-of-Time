using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
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
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwingSword();
        }
    }
}
