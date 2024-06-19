// WeavingScene
// by eunji

//Test code : 솜틀기 입구에 충돌된 구의 개수에 따라 출력되는 이불의 크기가 상이.
// SequentialMovement 코드가 최종.

using UnityEngine;
using System.Collections;

public class MultiCollisionResponse : MonoBehaviour
{
    public Transform exitPoint;  //이동을 시작할 위치
    public Transform objectToMoveForOneCollision;  //한개 구가 충돌했을 때 이동할 오브젝트(Object3)
    public Transform objectToMoveForTwoCollisions;  //두개 구가 충돌했을 때 이동할 오브젝트(Object4)
    public Transform objectToMoveForThreeCollisions;  //세개 구가 충돌했을 때 이동할 오브젝트(Object5)
    public float moveSpeed = 5.0f;  //이동 속도

    private int collisionCount = 0;  //충돌 횟수

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collisionCount++;
            HandleMovementBasedOnCollisionCount();
        }
    }

    private void HandleMovementBasedOnCollisionCount()
    {
        Transform objectToMove = null;
        Vector3 targetPosition = exitPoint.position - exitPoint.right * 1.0f;

        switch (collisionCount)
        {
            case 1: //구 한개 충돌
                objectToMove = objectToMoveForOneCollision;
                break;
            case 2: //구 두개 충돌
                objectToMove = objectToMoveForTwoCollisions;
                break;
            case 3: //구 세개 충돌
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
            yield return null;
        }
    }
}
