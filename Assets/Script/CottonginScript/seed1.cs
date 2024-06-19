// cottonginScene
// by haeun
// by Cotton1

using UnityEngine;

public class seed2: MonoBehaviour
{
    public GameObject[] objectsToDrop; // 중력을 받아 떨어질 오브젝트들을 담는 배열

    private bool hasCollided = false; // 충돌 여부를 나타내는 변수

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 특정 조건을 만족하고 충돌이 처음 발생했을 때
        if (!hasCollided && collision.gameObject.CompareTag("A"))
        {
            // 배열에 있는 모든 떨어뜨릴 오브젝트들에 대해 Rigidbody를 추가하여 중력을 활성화함
            foreach (GameObject obj in objectsToDrop)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                // Rigidbody가 없으면 추가
                if (rb == null)
                {
                    rb = obj.AddComponent<Rigidbody>();
                }
                // 중력 활성화
                rb.useGravity = true;
            }
            hasCollided = true; // 충돌 여부를 true로 설정하여 다시 충돌하지 않도록 함
        }
    }
}
