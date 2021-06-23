using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float repeatPosition;
    Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        repeatPosition = (GetComponent<BoxCollider>().size.x )/2;
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <startpos.x - repeatPosition)
        {
            transform.position = startpos;
        }
    }
}
