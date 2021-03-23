using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public ParticleSystem weaponProjectile;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        this.transform.rotation = rotation;

        if (Input.GetMouseButtonDown(0)) // left click
        {
            weaponProjectile.Play();
        }
    }
}
