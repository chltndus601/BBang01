using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiSou : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeActvieState()
    {
        print("½Å¼ºÈ£12");
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
