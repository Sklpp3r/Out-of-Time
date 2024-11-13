using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody RB;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform _camera;

    private Vector3 input;

    public float sensX, sensY;
    private float xRotation, yRotation;



    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MovePlayer();
        GetInput();
        CamControl();
    }





    

    private void GetInput()
    {
        input.z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        input.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    }

    private void CamControl()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _camera.rotation = Quaternion.Euler(xRotation, yRotation,0);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = transform.TransformDirection(input) * moveSpeed * Time.deltaTime;
        RB.MovePosition(RB.position + moveDirection);
    }


}
