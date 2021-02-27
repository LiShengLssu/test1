using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    float a;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position += new Vector3(0, 0, 1);
        gameObject.transform.Rotate(new Vector3(0, 0, 1));
        gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        
    }
}
