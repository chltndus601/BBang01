// cottonginScene
// by sooyeon
// Canvas > Cotton_gin > bottem_joint

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottem_joint : MonoBehaviour
{
    public float angle = 3.5f; // �ִ� ȸ�� ����
    public float speed = 2.0f; // ȸ�� �ӵ�
    public float suisoutime = 0.0f; // init time - ���� �������� �ð��� �帣���� ����
    public bool alive = false;
    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Mathf.Sin �Լ��� ����Ͽ� �ð��� ���� -angle���� angle���� �պ��ϴ� ���� ���
        if (alive)
        {
            suisoutime += 0.016f;
            UnityEngine.Debug.Log("good!");
        }
        //float zRotation = Mathf.Sin(Time.time * speed + Mathf.PI) * angle;
        float zRotation = Mathf.Sin(suisoutime * speed + Mathf.PI) * angle;
        //UnityEngine.Debug.Log($"Position: {zRotation},{suisoutime},{animator.GetBool("isOn")}");
        // z���� �������� ȸ�� ����
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }

    public void ChangeActvieState()
    {
        print("�ż�ȣ12");
        if (alive)
        {
            alive=false;
            print("SuiSouisOnOn");
        }
        else
        {
            alive= true;
            print("SuiSouisOnOff");
        }
    }

}
