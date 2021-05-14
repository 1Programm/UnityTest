using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    private PlayerMovement a;
    private void Start()
    {
        a = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(!inventory.activeSelf);
            a.setMovementEnabled(!inventory.activeSelf);
        }
    }
}
