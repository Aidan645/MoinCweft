using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Start is called before the first frame update
    public float LookSensitivity = 500f;
    public Transform CameraRig;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRig.eulerAngles += LookSensitivity * Time.deltaTime * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        transform.eulerAngles += LookSensitivity * Time.deltaTime * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        CameraRig.localEulerAngles = new Vector3(Mathf.Clamp(NormalizeAngle(CameraRig.localEulerAngles.x),-90,90),0,0);
    }

    /// <summary>
    ///  Normalizes an angle to be between -180 and 180
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    float NormalizeAngle(float angle)
    {
        float residue = angle % 180;
        return residue-(180*Mathf.Floor(angle/180));
    }
}
