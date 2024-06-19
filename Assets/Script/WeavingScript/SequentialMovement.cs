// weavingScene
// by eunji, dayoung

//Final code : 솜틀기에서 솜이 들어가고 대기 시간 후 이불이 나오는 코드
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SequentialMovement : MonoBehaviour
{
    public Transform object1;  //첫 번째로 이동할 오브젝트
    public Transform object2;  //두 번째로 이동할 오브젝트
    public Transform objectA;
    public float moveDistance = 5.0f;  //왼쪽으로 이동할 거리
    public float moveSpeed = 1.0f;  //이동 속도
    public float delayBetweenMovements = 2.0f;  //대기 시간

    private Vector3 object1StartPos;
    private Vector3 object2StartPos;

    public bool suisou = false;



    void Start()
    {
        //처음 위치 저장
        object1StartPos = object1.position;
        object2StartPos = object2.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        //충돌한 오브젝트가 objectA인지 확인
        if (collision.transform == objectA)
        {
            suisou=true;
        }
    }

    public void ColliStart()
    {   
        if(suisou) {
        StartCoroutine(MoveObjectsSequentially());
        }
    }

    IEnumerator MoveObjectsSequentially()
    {
        //첫 번째 오브젝트 이동
        Vector3 targetPosition1 = object1StartPos + Vector3.right * moveDistance;
        yield return StartCoroutine(MoveObject(object1, targetPosition1));

        //대기
        yield return new WaitForSeconds(delayBetweenMovements);

        //두 번째 오브젝트 이동
        Vector3 targetPosition2 = object2StartPos + Vector3.right * moveDistance;
        yield return StartCoroutine(MoveObject(object2, targetPosition2));
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

