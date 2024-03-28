using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public GameObject liquid;
    public GameObject liquidMesh;

    public int sloshSpeed = 60;
    public int rotateSpeed = 15;

    public int difference = 25;

  
    void Update()
    {
        Slosh();

        liquidMesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
    }

    void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        Vector3 finalRotation = Quaternion.RotateTowards(liquid.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        liquid.transform.localEulerAngles = finalRotation;
    }


    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;

        if(value > 180)
        {
            returnValue = Mathf.Clamp(value, 360 - difference, 360);

        }

        else
        {
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;
    }
}
