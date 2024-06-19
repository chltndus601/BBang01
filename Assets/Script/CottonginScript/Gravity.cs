// cottonginScene
// by sooyeon
// Cotton1, 2, 3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gravity : MonoBehaviour
{
    public float gravityScale = 10.0f; // 원하는 중력 배율을 설정하세요.
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        Vector3 extraGravity = (gravityScale - 1) * Physics.gravity;
        rb.AddForce(extraGravity, ForceMode.Acceleration);
    }
}
