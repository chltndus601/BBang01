using UnityEngine;
using System.Collections;

public class ObjectPrinter : MonoBehaviour
{
    public GameObject flatObjectPrefab; // 납작한 오브젝트 프리팹
    public Transform exitPoint; // 오브젝트가 나올 구멍 위치

    // 오브젝트를 생성하고 이동시키는 코루틴
    IEnumerator PrintObject()
    {
        // 오브젝트 인스턴스화
        GameObject printedObject = Instantiate(flatObjectPrefab, exitPoint.position, Quaternion.identity);

        // 목표 지점 설정
        Vector3 targetPosition = exitPoint.position - exitPoint.right * 1.0f; // 구멍을 통해 1 유닛만큼 앞으로 이동

        // 원하는 위치로 이동시키기
        while (Vector3.Distance(printedObject.transform.position, targetPosition) > 0.01f)
        {
            printedObject.transform.position = Vector3.MoveTowards(printedObject.transform.position, targetPosition, 0.1f * Time.deltaTime);
            yield return null;
        }
    }

    // 프린트 시작 함수
    public void StartPrinting()
    {
        StartCoroutine(PrintObject());
    }
}
