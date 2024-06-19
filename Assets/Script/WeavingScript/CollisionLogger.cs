// WeavingScene
// by eunji

//Test code : 콜라이더가 설정된 오브젝트끼리 충돌이 될 때, 어느 오브젝트가 충돌되었는 지 알려주는 코드.
//한마디로, 충돌 로그 출력 코드.

// using UnityEngine;

// public class CollisionLogger : MonoBehaviour
// {
//     void OnCollisionEnter(Collision collision)
//     {
//         // 충돌된 모든 접촉 지점에서 태그를 확인
//         foreach (ContactPoint contact in collision.contacts)
//         {
//             Debug.Log("Contact point with tag: " + contact.thisCollider.tag + " and " + contact.otherCollider.tag);
//             if ((contact.thisCollider.CompareTag("Plate") && contact.otherCollider.CompareTag("Big")) ||
//                 (contact.thisCollider.CompareTag("Big") && contact.otherCollider.CompareTag("Plate")))
//             {
//                 Debug.Log("Collision detected between Plate and Big object");
//             }
//         }
//     }
// }
