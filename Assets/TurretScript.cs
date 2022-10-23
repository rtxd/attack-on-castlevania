using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public float power = 0;
    public GameObject arrow;
    float angle;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        angle = Vector2.SignedAngle(Vector2.right, direction);
        transform.eulerAngles = new Vector3(0, 0, angle);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            power++;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            shoot();
        }
    }

    void shoot()
    {
        Debug.Log("fire");
        Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, -1.3f), transform.rotation);
    }
}
