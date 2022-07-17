using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject aimObj;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 aimPos = new Vector3(0.0f, 4.0f, 0.0f);
        Instantiate(aimObj, aimPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
