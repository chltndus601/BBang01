using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonginMain : MonoBehaviour
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
    public void ChangeActvieState ()
    {
        print("dddd2");
        if (animator.GetBool("UpperActive"))
        {
            animator.SetBool("UpperActive", false);
            print("dddd");
        }
        else
        {
            animator.SetBool("UpperActive", true);
            print("dddd1");
        }
    }
    
}
