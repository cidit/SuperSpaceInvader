using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    const float MouseSensitivity = 100, MovementSpeed = 10;
    const float xRange = 20, yRange = 10;
    WeaponBehaviour weapon;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        CamControl();
        MovControl();
        WeaponSwitch();
        ShootControl();
    }

    void CamControl() {
        var vals = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        vals *= Time.deltaTime * MouseSensitivity;
        transform.Rotate(Vector3.up * vals.x, Space.World);
        transform.Rotate(Vector3.right * vals.y);
    }

    void MovControl() {
        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.position.z);
        movement *= Time.deltaTime * MovementSpeed;
        var newPosition = movement + transform.position;
        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -xRange, xRange),
                                          Mathf.Clamp(newPosition.y, -yRange, yRange));

    }

    void ShootControl() {
        if (Input.GetKeyDown(KeyCode.Space))
            weapon.Shoot();
    }

    void WeaponSwitch() {

        weapon = GetComponentInChildren<WeaponBehaviour>();

    }
}
