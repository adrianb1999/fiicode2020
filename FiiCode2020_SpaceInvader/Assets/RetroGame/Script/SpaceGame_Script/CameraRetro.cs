using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRetro : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 5f;
    private const float Y_ANGLE_MAX = 45f;

    public Transform Target;

    Transform camTransform;
    [SerializeField] float distance = 25f;
    
    private float currentX = 0f;
    private float currentY = 0f;
    
    [SerializeField] float sensivityX = 4f;
    [SerializeField] float sensivityY = 1f;
    [SerializeField] float height = 1f;
    void Start()
    {
        camTransform = this.transform;
    }
    private void Update()
    {
        if (Target == null || !Input.GetKey(KeyCode.Mouse2)) 
            return;
        currentX += Input.GetAxis("Mouse X") * sensivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensivityY;
       // currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX); //limitam valoarea lui y cu capetele Y_ANGLE_MIN si Y_ANGLE_MAX
    }
    private void FixedUpdate()
    {
        distance += -Input.mouseScrollDelta.y * 0.1f;
        distance = Mathf.Clamp(distance, 5f, 20f);
    }
    void LateUpdate()
    {
        if (Target == null)
            return;

        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        camTransform.position = Target.position + rotation * dir;
        camTransform.LookAt(Target.position + new Vector3(0, height, 0));
    }
}
