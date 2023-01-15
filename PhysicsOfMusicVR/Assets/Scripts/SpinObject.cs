using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
        Transform pivotPoint;
    public float RotationSpeed = 0.1f;
    public bool RotateAxisX = false;
    public bool RotateAxisY = false;
    public bool RotateAxisZ = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pivotPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundPivot();
    }

    void RotateAroundPivot()
    {
        if(RotateAxisX == true)
            pivotPoint.Rotate(Time.deltaTime * RotationSpeed, 0, 0);    
        
        if(RotateAxisY == true)
            pivotPoint.Rotate(0, Time.deltaTime * RotationSpeed, 0);
        
        if(RotateAxisZ == true)
            pivotPoint.Rotate(0, 0, Time.deltaTime * RotationSpeed);
        
    }
}
