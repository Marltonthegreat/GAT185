using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0) velocity.y = 0;

        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        controller.Move(direction * speed * Time.deltaTime);

        animator.SetFloat("Speed", controller.velocity.magnitude);

        if (controller.velocity.magnitude > 0) transform.forward = controller.velocity;

        if (controller.isGrounded && Input.GetKeyDown("Space")) velocity.y += jumpForce;

        velocity += Physics.gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}