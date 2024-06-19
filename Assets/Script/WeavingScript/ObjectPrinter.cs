// WeavingScene
// by eunji

//Test code : 초기 기능 구현할 때 기능 테스트 코드
//Sequential Movement 코드가 최종. : 이불 나오는 코드
using UnityEngine;
using System.Collections;

public class ObjectPrinter : MonoBehaviour
{
    public GameObject flatObjectPrefab; //납작한 오브젝트
    public Transform exitPoint; //오브젝트가 나올 구멍 위치

    IEnumerator PrintObject()
    {
        GameObject printedObject = Instantiate(flatObjectPrefab, exitPoint.position, Quaternion.identity);

        Vector3 targetPosition = exitPoint.position - exitPoint.right * 1.0f;

        while (Vector3.Distance(printedObject.transform.position, targetPosition) > 0.01f)
        {
            printedObject.transform.position = Vector3.MoveTowards(printedObject.transform.position, targetPosition, 0.1f * Time.deltaTime);
            yield return null;
        }
    }

    public void StartPrinting()
    {
        StartCoroutine(PrintObject());
    }
}
