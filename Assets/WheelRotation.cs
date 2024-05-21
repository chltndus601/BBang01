using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // 바퀴의 회전 속도를 조절하는 변수
    private bool isRotating = false; // 바퀴가 현재 회전하고 있는지를 추적하는 플래그

    // 이 메서드는 UI 버튼 클릭 시 호출됩니다.
    public void ToggleRotation()
    {
        isRotating = !isRotating; // 바퀴의 회전 상태를 토글합니다.
    }

    // 바퀴의 실제 회전을 처리합니다.
    void Update()
    {
        if (isRotating)
        {
            // 회전 속도에 Time.deltaTime을 곱하여 프레임 속도에 독립적으로 만듭니다.
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    // 회전 속도를 설정하는 메서드입니다. UI에서 이 메서드를 호출하여 회전 속도를 변경할 수 있습니다.
    public void SetRotationSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
