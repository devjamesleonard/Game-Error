using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector2 startpoint, Vector2 endpoint, Vector3 pos)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        if (endpoint.x - startpoint.x > 7)
        {
            endpoint.x = startpoint.x + 7;
        }
        else if (startpoint.x - endpoint.x > 7) 
        {
            endpoint.x = startpoint.x - 7;
        }
        if(endpoint.y - startpoint.y > 9)
        {
            endpoint.y = startpoint.y + 9;
        
        }else if(startpoint.y - endpoint.y > 9)
        {
            endpoint.y = startpoint.y - 9;
        }
        float xoff = startpoint.x - pos.x;

        float yoff = startpoint.y - pos.y;
        points[0] = new Vector3(startpoint.x-xoff, startpoint.y - yoff, 0);
        points[1] = new Vector3(endpoint.x - xoff, endpoint.y - yoff, 0);
        lr.SetPositions(points);
        


    }
    public void EndLine()
    {
        lr.positionCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
