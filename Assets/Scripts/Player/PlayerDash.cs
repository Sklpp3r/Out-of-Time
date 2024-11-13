using System.Diagnostics;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody RB;

    [SerializeField] Transform _camera;
    [SerializeField] private float DashForce;

    private bool _isDashing;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isDashing = Input.GetKeyDown(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        Dash();
    }




    private void Dash()
    {
        if (_isDashing)
        {
            RB.AddForce(_camera.transform.forward * DashForce, ForceMode.Impulse);
        }
    }
}
