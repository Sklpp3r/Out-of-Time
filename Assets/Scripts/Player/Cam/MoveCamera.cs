using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform _cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = _cameraPosition.position;
    }
}
