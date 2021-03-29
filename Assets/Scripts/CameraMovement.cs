using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey(KeyCode.W)) movement.z += movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) movement.x -= movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) movement.z -= movementSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) movement.x += movementSpeed * Time.deltaTime;

        if (Input.mousePosition.x <= 1) movement.x -= movementSpeed * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width-1) movement.x += movementSpeed * Time.deltaTime;
        if (Input.mousePosition.y <= 1) movement.z -= movementSpeed * Time.deltaTime; ;
        if (Input.mousePosition.y >= Screen.height-1) movement.z += movementSpeed * Time.deltaTime; ;


        transform.position += movement;
    }
}
