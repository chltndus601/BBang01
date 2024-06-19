// cottonginScene
// by haeun
// Canvas > Cotton_gin > Roller_bar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Roller_bar : MonoBehaviour
{
    public float rotationSpeed = 60.0f; // 회전 속도
    void Update()
    {
        // Z축을 기준으로 객체를 회전시키는 코드
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}