// Weaving Scene
// by eunji

//Final code : 솜틀기 바퀴 회전하는 코드(솜틀기 켜지는 코드)
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; //바퀴 회전 속도
    private bool isRotating = false; //바퀴가 현재 회전하고 있는지 플래그

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    //회전 속도
    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
