using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    public float autoRotateSpeed = 50.0f;
    public float rotateSpeed = 100.0f;

    bool isAutoRotate = true;

    void LateUpdate()
    {
        if (isAutoRotate)
            this.transform.RotateAround(this.transform.position, Vector3.up, autoRotateSpeed * Time.deltaTime);
    }

    private void OnMouseDrag()
    {
        isAutoRotate = false;

        float rotX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

        this.transform.RotateAround(this.transform.position, Vector3.up, -rotX);
        this.transform.RotateAround(this.transform.position, Vector3.right, -rotY);
        
        // 放掉物件同時改變自動旋轉的方向
        if (Input.GetAxis("Mouse X") < 0)
        {
            autoRotateSpeed = Mathf.Abs(autoRotateSpeed);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            autoRotateSpeed = Mathf.Abs(autoRotateSpeed) * -1;
        }
    }

    private void OnMouseUp()
    {
        isAutoRotate = true;
    }
}
