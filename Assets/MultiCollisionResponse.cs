// using UnityEngine;
// using System.Collections;

// public class TriggerPrint : MonoBehaviour
// {
//     public Transform objectToMove;  // 이동할 오브젝트의 Transform
//     public Transform exitPoint;  // 이동을 시작할 위치
//     public string targetObjectName = "Object2";  // 충돌을 감지할 오브젝트 이름
//     public float moveSpeed = 5.0f;  // 이동 속도

//     private void OnCollisionEnter(Collision collision)
//     {
//         // 충돌한 오브젝트가 설정한 targetObjectName과 일치할 경우
//         if (collision.collider.gameObject.name == targetObjectName)
//         {
//             Debug.Log("Collision detected with " + targetObjectName);
//             Vector3 targetPosition = exitPoint.position - exitPoint.right * 1.0f;  // 이동할 최종 위치 계산
//             StartCoroutine(MoveObject(objectToMove, targetPosition));  // 이동할 오브젝트와 목표 위치를 Coroutine으로 전달
//         }
//     }

//     IEnumerator MoveObject(Transform obj, Vector3 targetPosition)
//     {
//         // 목표 위치에 도달할 때까지 반복
//         while (Vector3.Distance(obj.position, targetPosition) > 0.01f)
//         {
//             // obj의 현재 위치에서 목표 위치로 매 프레임 이동
//             obj.position = Vector3.MoveTowards(obj.position, targetPosition, moveSpeed * Time.deltaTime);
//             yield return null;  // 다음 프레임까지 대기
//         }
//     }
// }

using UnityEngine;
using System.Collections;

public class MultiCollisionResponse : MonoBehaviour
{
    public Transform exitPoint;  // 이동을 시작할 위치
    public Transform objectToMoveForOneCollision;  // 하나의 구가 충돌했을 때 이동할 오브젝트 (Object3)
    public Transform objectToMoveForTwoCollisions;  // 두 개의 구가 충돌했을 때 이동할 오브젝트 (Object4)
    public Transform objectToMoveForThreeCollisions;  // 세 개의 구가 충돌했을 때 이동할 오브젝트 (Object5)
    public float moveSpeed = 5.0f;  // 이동 속도

    private int collisionCount = 0;  // 충돌 횟수를 세기 위한 변수

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") // "Ball" 태그를 가진 오브젝트와 충돌 시
        {
            collisionCount++; // 충돌 카운트 증가
            HandleMovementBasedOnCollisionCount(); // 충돌 횟수에 따른 이동 처리
        }
    }

    private void HandleMovementBasedOnCollisionCount()
    {
        Transform objectToMove = null;
        Vector3 targetPosition = exitPoint.position - exitPoint.right * 1.0f; // 이동할 최종 위치 계산

        switch (collisionCount)
        {
            case 1: // 한 개의 구가 충돌한 경우
                objectToMove = objectToMoveForOneCollision;
                break;
            case 2: // 두 개의 구가 충돌한 경우
                objectToMove = objectToMoveForTwoCollisions;
                break;
            case 3: // 세 개의 구가 충돌한 경우
                objectToMove = objectToMoveForThreeCollisions;
                break;
        }

        if (objectToMove != null)
            StartCoroutine(MoveObject(objectToMove, targetPosition));
    }

    IEnumerator MoveObject(Transform obj, Vector3 targetPosition)
    {
        while (Vector3.Distance(obj.position, targetPosition) > 0.01f)
        {
            obj.position = Vector3.MoveTowards(obj.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }
    }
}
