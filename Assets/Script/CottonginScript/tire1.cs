// cottonginScene
// by sungho
// Canvas > Cotton_gin > tire1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire1 : MonoBehaviour
{
    public float rotationSpeed = 60.0f; // ȸ�� �ӵ�
    public bool alive = false;
    public float suisoutime = 0.0f;


    void Update()
    {
        // Z���� �������� ��ü�� ȸ����Ű�� �ڵ�
        if(alive)
        {
            transform.Rotate(0, 0, rotationSpeed);
        }

        //if (suisoutime > 60f)
        //{
        //    suisoutime = 0.0f;
        //}
        
    }

    public void ChangeActvieState()
    {
        print("�ż�ȣ12");
        if (alive)
        {
            alive = false;
            print("SuiSouisOnOff");
        }
        else
        {
            alive = true;
            print("SuiSouisOnOn");
        }
    }
}