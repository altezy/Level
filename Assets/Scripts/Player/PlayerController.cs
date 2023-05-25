using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private PlayerInventory inventory;

    public PlayerInventory Inventory => inventory;

    private void Update()
    {
        var moveDirection = (transform.right * Input.GetAxis("Horizontal") 
                             + transform.forward * Input.GetAxis("Vertical")) * movementSpeed;
        transform.position = Vector3.Lerp(transform.position, transform.position + moveDirection, Time.deltaTime);
        var rotateDirection = transform.up * Input.GetAxis("Mouse X") * rotationSpeed;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, transform.eulerAngles + rotateDirection, Time.deltaTime);
        var cameraRotateDirection = Vector3.left * Input.GetAxis("Mouse Y") * rotationSpeed;
        camera.transform.localEulerAngles = Vector3.Lerp(camera.transform.localEulerAngles,
            camera.transform.localEulerAngles + cameraRotateDirection, Time.deltaTime);
    }
}
