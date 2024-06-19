// cottonginScene
// by sooyeon
// Canvas > Cotton_gin > bottem

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottem : MonoBehaviour
{
    Vector3 initialPosition;
    float delta = 15.0f; // ���Ϸ� �̵� ������ �ִ밪
    float speed = 2.0f; // �̵� �ӵ�
    public float suisoutime = 0.0f;
    public bool alive = false;
    //public Animator animator;

    void Start()
    {
        initialPosition = transform.position;
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 newPosition = initialPosition;
        if (alive)
        {
            suisoutime += 0.016f;
            UnityEngine.Debug.Log("good!");
        }

        newPosition.y += delta * Mathf.Sin(suisoutime * speed);
        transform.position = newPosition;

        // ��ġ ��ȭ Ȯ���� ���� �α� ���
        //UnityEngine.Debug.Log($"Position: {transform.position}");
    }

    public void ChangeActvieState()
    {
        print("�ż�ȣ12");
        if (alive)
        {
            alive = false;
            print("SuiSouisOnOn");
        }
        else
        {
            alive = true;
            print("SuiSouisOnOff");
        }
    }
}
