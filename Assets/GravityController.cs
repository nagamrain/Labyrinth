using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] float acceleration = 9.8f;
    Quaternion gravityOffset = Quaternion.identity;
    bool isActive = true;
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Physics.gravity = gravityOffset * GetGravityFromSensor();
        }
        else
        {
            Physics.gravity = Vector3.zero;
        }
    }

    public void CalibrateGravity()
    {
        gravityOffset = Quaternion.FromToRotation(GetGravityFromSensor(),  Vector3.down * acceleration);
    }

    public Vector3 GetGravityFromSensor()
    {
        Vector3 gravity;
        if (Input.gyro.gravity != Vector3.zero)
            gravity = Input.gyro.gravity * acceleration;
        else
            gravity = Input.acceleration * acceleration;

        gravity.z = Mathf.Clamp(gravity.z, float.MinValue, -1);

        return new Vector3(gravity.x, gravity.z, gravity.y);
    }

    public void SetActive(bool value)
    {
        isActive = value;
        if (value)
        {
            Time.timeScale = 1;         
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
