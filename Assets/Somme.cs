using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somme : MonoBehaviour
{
    bool isFire;
    Vector3 direction;
    [SerializeField]
    float speed = 0.2f;
    Vector3 upper;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.z<-900 || transform.position.z > -450)
        {   
            transform.Translate(direction * speed);
            upper[0] = 0f;
            upper[1] = -180f - transform.position.y;
            upper[2] = 722.05f - transform.position.z;
            transform.Translate(upper);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire)
        {
            //transform.Translate(direction * Time.deltaTime * speed);
            print(transform.position.x);
        }
    }

    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }
}
