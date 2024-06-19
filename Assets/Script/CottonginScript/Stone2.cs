// cottonginScene
// by haeun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone2 : MonoBehaviour
{
    public GameObject rollerObject; // 롤러 오브젝트
    public float attractionForce = 20.0f; // 롤러가 오브젝트를 끌어당기는 힘
    public float attractionRadius = 0.1f; // 롤러에 달라붙는 반경
    public float rotationThreshold = 360.0f; // 한 바퀴 회전 기준 각도
    public float mass = 200.0f; // 질량
    public float drag = 0.0f; // 항력
    public float attachDelay = 3.0f; // 롤러에 붙기 전 대기 시간
    public GameObject boxObject; // Box 오브젝트
    public GameObject transparentPlateObject; // 투명한 판 오브젝트
    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private bool isAttachedToRoller = false; // 롤러에 붙어 있는지 여부
    private bool detachInitiated = false; // 분리 코루틴이 시작되었는지 여부
    private bool hasFallen = false; // 오브젝트가 한 번 떨어졌는지 여부
    private bool hasStopped = false; // Box에 충돌하여 멈췄는지 여부
    private float initialRollerRotation; // 초기 롤러 회전 각도
    private float totalRotation = 0f; // 누적 회전 각도

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.mass = mass;
            rb.drag = drag;
        }
    }

    void FixedUpdate()
    {
        if (!isAttachedToRoller && !detachInitiated && !hasFallen && !hasStopped)
        {
            float distanceToRoller = Vector3.Distance(transform.position, rollerObject.transform.position);
            if (distanceToRoller <= attractionRadius)
            {
                Vector3 directionToRoller = (rollerObject.transform.position - transform.position).normalized;
                rb.AddForce(directionToRoller * attractionForce);
            }
        }
        else if (isAttachedToRoller)
        {
            float currentRollerRotation = rollerObject.transform.rotation.eulerAngles.z;
            float rotationDifference = Mathf.DeltaAngle(initialRollerRotation, currentRollerRotation);
            totalRotation += Mathf.Abs(rotationDifference);
            initialRollerRotation = currentRollerRotation;
            if (totalRotation >= rotationThreshold)
            {
                DetachFromRoller();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == rollerObject && !isAttachedToRoller && !detachInitiated && !hasFallen)
        {
            AttachToRoller(collision.contacts[0].point);
        }
        else if (collision.gameObject == boxObject && !hasStopped)
        {
            StopMovement();
        }
        else if (collision.gameObject == transparentPlateObject && !isAttachedToRoller && !detachInitiated && !hasFallen)
        {
            if (sphereCollider != null)
            {
                sphereCollider.radius = 0.0005f; // SphereCollider 반경 변경
                Debug.Log("SphereCollider radius changed to 0.05");
            }
            AttachToRoller(transform.position);
        }
    }

    void AttachToRoller(Vector3 collisionPoint)
    {
        isAttachedToRoller = true;
        detachInitiated = true;
        transform.SetParent(rollerObject.transform);
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        // 롤러 표면에 정확히 붙도록 위치 조정
        Collider rollerCollider = rollerObject.GetComponent<Collider>();
        if (rollerCollider != null)
        {
            Vector3 closestPoint = rollerCollider.ClosestPoint(collisionPoint);
            transform.position = closestPoint;
        }
        // Adjust position to ensure contact
        Vector3 rollerSurfaceNormal = (transform.position - rollerObject.transform.position).normalized;
        transform.position -= rollerSurfaceNormal * 0.001f; // Minimal offset for exact contact
        // 충돌 검사 후 위치 재조정
        Vector3 adjustedPosition = transform.position;
        if (Physics.Raycast(transform.position, -rollerSurfaceNormal, out RaycastHit hit, 0.1f))
        {
            adjustedPosition = hit.point;
        }
        transform.position = adjustedPosition;
        transform.localRotation = Quaternion.identity;
        initialRollerRotation = rollerObject.transform.rotation.eulerAngles.z;
        totalRotation = 0f;
        transform.localScale = new Vector3(0.2f, 0.4f, 0.3f);
        // 중력과 속도 초기화
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void DetachFromRoller()
    {
        isAttachedToRoller = false;
        detachInitiated = false;
        hasFallen = true; // 오브젝트가 한 번 떨어졌음을 표시
        transform.parent = null;
        if (rb != null)
        {
            rb.isKinematic = false; // 물리 속성을 해제하여 중력 적용
            rb.useGravity = true;   // 중력 활성화
            rb.velocity = Vector3.zero; // 속도를 0으로 설정하여 바로 아래로 떨어지도록 함
            rb.angularVelocity = Vector3.zero; // 회전 속도를 0으로 설정
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 충돌 감지 모드 설정
            rb.WakeUp(); // 물리 상호 작용을 즉시 활성화
        }
    }

    void StopMovement()
    {
        hasStopped = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
