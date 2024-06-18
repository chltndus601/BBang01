using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] float mouseSpeed = 8f;
    private Animator animator;
    private float gravity;
    private CharacterController controller;
    private Vector3 mov;

    public GameObject sommePrefab;

    private float mouseX;


    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector3 firePos = transform.position + new Vector3(0f, 0.5f, 0f) + animator.transform.forward;// + animator.transform.forward;
            var somme = Instantiate(sommePrefab, firePos, Quaternion.identity).GetComponent<Somme>();
            somme.Fire(animator.transform.forward);
            animator.SetInteger("bullets", 1+ animator.GetInteger("bullets"));
            print(animator.GetInteger("bullets"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mov = Vector3.zero;
        gravity = 10f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (controller.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mov = controller.transform.TransformDirection(mov*45);
        }
        else
        {
            mov.y -= gravity * Time.deltaTime;
        }

        controller.Move(mov * Time.deltaTime * speed);
        Fire();

    }
}