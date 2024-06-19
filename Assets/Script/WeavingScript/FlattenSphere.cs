// WeavingScene
// by eunji, dayoung

//Final code : 컨트롤러 grab 버튼으로 누른 상태에서 A버튼을 누르면 솜이 납작해지는 코드.
using UnityEngine;

public class FlattenSphere : MonoBehaviour
{
    private bool isControllerInTrigger = false;

    void Update()
    {
        //OVRInput.Button.One = Oculus 컨트롤러 A 버튼
        if (isControllerInTrigger && OVRInput.GetDown(OVRInput.Button.One))
        {
            //현재 구 스케일
            Vector3 currentScale = transform.localScale;

            //구체를 더 납작하게 하기. 
            //Y축 스케일을 점점 줄여 나가고, X와 Z축 스케일을 점점 늘려 나가기.
            transform.localScale = new Vector3(currentScale.x *3/2 , currentScale.y /2, currentScale.z *3/2 );
            
        }
    }
    //컨트롤러에 태그 부착
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            isControllerInTrigger = true;
        }
    }
    //컨트롤러에 태그 부착
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            isControllerInTrigger = false;
        }
    }
}