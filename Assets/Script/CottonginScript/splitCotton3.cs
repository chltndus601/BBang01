// cottonginScene
// by haeun
// Cotton3

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitCotton3 : MonoBehaviour
{
    public GameObject partPrefab; // 9등분된 오브젝트의 프리팹
    public GameObject transparentPlateObject; // 투명한 판 오브젝트
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == transparentPlateObject)
        {
            SplitObject();
            Destroy(gameObject);
        }
    }

    void SplitObject()
    {
        Vector3 originalPosition = transform.position;
        Vector3 originalScale = transform.localScale;
        Vector3[] offsets = new Vector3[]
        {
            new Vector3(-0.1f, 0, 0.1f), // front-left
            new Vector3(0, 0, 0.1f), // front-center
            new Vector3(0.1f, 0, 0.1f), // front-right
            new Vector3(-0.1f, 0, 0), // middle-left
            new Vector3(0, 0, 0), // middle-center
            new Vector3(0.1f, 0, 0), // middle-right
            new Vector3(-0.1f, 0, -0.1f), // back-left
            new Vector3(0, 0, -0.1f), // back-center
            new Vector3(0.1f, 0, -0.1f) // back-right
        };

        for (int i = 0; i < 9; i++)
        {
            Vector3 partPosition = originalPosition + Vector3.Scale(offsets[i], originalScale);
            GameObject part = Instantiate(partPrefab, partPosition, Quaternion.identity);
            part.transform.localScale = originalScale / 3; // 9등분이므로 스케일을 1/3로 조정
            Rigidbody partRb = part.GetComponent<Rigidbody>();
            if (partRb == null)
            {
                partRb = part.AddComponent<Rigidbody>();
            }
            partRb.mass = rb.mass / 9; // 원래 오브젝트의 질량을 9등분
            partRb.useGravity = false; // 초기에는 중력을 사용하지 않음
            partRb.isKinematic = true; // 초기에는 고정된 상태로 설정

            // 일정 시간 후 중력과 물리 효과 활성화
            StartCoroutine(ActivatePhysics(partRb, 0.1f));
        }
    }

    IEnumerator ActivatePhysics(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false; // 고정 해제
        rb.useGravity = true; // 중력 활성화
    }
}
