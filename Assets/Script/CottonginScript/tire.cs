// cottonginScene
// by sooyeon
// Canvas > Cotton_gin > tire2, 3, 4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tire : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // ȸ�� �ӵ�
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