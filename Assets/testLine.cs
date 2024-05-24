using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, p1.transform.position);
        lineRenderer.SetPosition(1, p2.transform.position);
    }
}
