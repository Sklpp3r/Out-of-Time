using System.Drawing.Drawing2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody RB;

    [Header("Movement")]
    [SerializeField] private float _playerMoveSpeed;
    [SerializeField] private float _playerJumpForce;
    [SerializeField] private float _playerDashSpeed;
    [SerializeField] private Transform _camera;


    private Vector3 input;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public float sensX, sensY;
    private float xRotation, yRotation;
    private bool readyToJump;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }


    void Start()
    {

    }

    void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        Cursor.lockState = CursorLockMode.Locked;

        MovePlayer();
        GetInput();
        CamControl();
    }






    //INPUT ALMA
    private void GetInput()
    {
        input.z = Input.GetAxis("Vertical") * Time.deltaTime * _playerMoveSpeed;
        input.x = Input.GetAxis("Horizontal") * Time.deltaTime * _playerMoveSpeed;
    }



    //ETRAFA BAKMA 
    private void CamControl()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _camera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }


    //HAREKET
    private void MovePlayer()
    {
        Vector3 moveDirection = transform.TransformDirection(input) * _playerMoveSpeed * Time.deltaTime;
        RB.MovePosition(RB.position + moveDirection);
    }

    [System.Obsolete]
    private void Jump()
    {

        RB.velocity = new Vector3(RB.velocity.x, 0f, RB.velocity.z);

        RB.AddForce(transform.up * _playerJumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }


}
