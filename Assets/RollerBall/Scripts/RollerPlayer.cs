using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]
public class RollerPlayer : MonoBehaviour, IDestructable
{
    [SerializeField] float maxForce = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] ForceMode forceMode;
    [SerializeField] Transform viewTransform;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Health>().deathSound = GameObject.Find("PlayerDeath").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        // convert world to view
        Quaternion viewSpace = Quaternion.AngleAxis(viewTransform.rotation.eulerAngles.y, Vector3.up);
        direction = viewSpace * direction;

        // scale force
        force = direction * maxForce;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        RollerGameManager.Instance.playerHealth = GetComponent<Health>().health;
    }

    private void FixedUpdate()
    {
        rb.AddForce(force, forceMode);
    }

    public void Destroyed()
    {
        RollerGameManager.Instance.OnPlayerDead();
    }
}