using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 mouseMovement;
    public float mouseSensitivity = 5f;

   // public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseRotation();
        HandlePlayerMovement();
        HandleShooting();
    }

    private void HandleMouseRotation()
    {
        mouseMovement.x += Input.GetAxisRaw("Mouse X") * mouseSensitivity;// *Time.deltaTime;
        mouseMovement.y += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;// *Time.deltaTime;

        transform.localRotation = Quaternion.Euler(-mouseMovement.y, mouseMovement.x, 0f);
    }

    private void HandlePlayerMovement()
    {
        float speed = 5f;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 localMonoDirection = new Vector3(x, 0f, z).normalized;

        Vector3 worldMonoDirection = transform.TransformDirection(localMonoDirection);

        if (x != 0f || z != 0f)
        {
            Debug.Log("World dir: " + worldMonoDirection + "vs local dir: " + localMonoDirection);
        }

        //velocity
        Vector3 dPos = speed * worldMonoDirection * Time.deltaTime;
        dPos.y = 0f;

        Vector3 newPos = transform.position + dPos;

        transform.position = newPos;
    }

    private void HandleShooting()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 500f, Color.white);
        if (Input.GetAxis("Fire1") != 0f)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        float gunRange = 500f;
        RaycastHit hit;

       /* GameObject tempExplosion = Instantiate(explosionPrefab);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, gunRange))
        {
            Debug.Log("You hit: " + hit.collider.name);
            tempExplosion.transform.position = hit.point;
        }
        else
        {
            tempExplosion.transform.position = transform.TransformDirection(Vector3.forward) * gunRange;
        }*/

        //tempExplosion.GetComponent<ParticleSystem>().Play();
    }
}
