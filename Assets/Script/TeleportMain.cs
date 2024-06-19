// cottonginScene, weavingScene
// by haeun, sooyeon, dayoung

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMain : MonoBehaviour
{
    public GameObject ovrRig; // OVR Rig를 참조합니다.
    public Vector3 teleportPosition1; // 첫 번째 위치
    public Vector3 teleportPosition2; // 두 번째 위치
    public Vector3 teleportPosition3; // 세 번째 위치
    public Vector3 teleportPosition4; // 네 번째 위치
    private int currentPosition = 0; // 현재 위치 상태를 나타내는 변수 (0, 1, 2, 3)

    void Update()
    {
        // B 버튼이 눌렸을 때 실행
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            switch (currentPosition)
            {
                case 0:
                    Teleport(teleportPosition1);
                    currentPosition = 1;
                    break;
                case 1:
                    Teleport(teleportPosition2);
                    currentPosition = 2;
                    break;
                case 2:
                    Teleport(teleportPosition3);
                    currentPosition = 3;
                    break;
                case 3:
                    Teleport(teleportPosition4);
                    currentPosition = 0;
                    break;
            }
        }
    }

    void Teleport(Vector3 teleportPosition)
    {
        // OVR Rig의 위치를 새로운 위치로 설정합니다.
        if (ovrRig != null)
        {
            Transform parentTransform = ovrRig.transform.parent;
            if (parentTransform != null)
            {
                // 부모가 있는 경우 부모의 위치와 회전을 고려하여 이동
                Vector3 globalPosition = parentTransform.TransformPoint(teleportPosition);
                ovrRig.transform.position = globalPosition;
            }
            else
            {
                // 부모가 없는 경우 직접 위치 설정
                ovrRig.transform.position = teleportPosition;
            }
            UnityEngine.Debug.Log("Teleported to position: " + ovrRig.transform.position);
        }
        else
        {
            UnityEngine.Debug.LogError("OVR Rig is not assigned.");
        }
    }
}
