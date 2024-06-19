// WeavingScene
// by eunji

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rudder : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        print("SuiSouisOn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeActvieState()
    {
        print("�ż�ȣ12");
        if (animator.GetBool("isOn"))
        {
            animator.SetBool("isOn", false);
            print("SuiSouisOnOn");
        }
        else
        {
            animator.SetBool("isOn", true);
            print("SuiSouisOnOff");
        }
    }
}
