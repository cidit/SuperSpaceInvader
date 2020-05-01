using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{

    const float BulletSpeed = 50000, WeaponRange = 100;
    Transform BarrelExit;

    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        BarrelExit = transform.Find("Barrel Exit");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.up, WeaponRange))
            Debug.Log("In range.");
    }

    public void Shoot() {
        var bullet = Instantiate(bulletPrefab, BarrelExit.position, new Quaternion());
        bullet.GetComponent<Rigidbody>().AddForce(transform.up * Time.deltaTime * BulletSpeed);
    }
}
