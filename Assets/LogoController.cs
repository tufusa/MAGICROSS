using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoController : MonoBehaviour
{
    float omega = 0.1f;
    int step = 0;
    public float coeff;

    void Start()
    {
        this.RotStart();
    }

    public void RotStart()
    {
        omega = 0.1f;
        step = (step) % 4 + 1;
        InvokeRepeating("rot", 0, 0.01f);
    }

    public void rot()
    {
        transform.Rotate(0, 0, omega);

        if (step != 4)
        {
            if (transform.eulerAngles.z < 90 * step - 45)
            {
                omega *= coeff;
            }
            else if (transform.eulerAngles.z < 90 * step)
            {
                omega /= coeff;
            }
            else
            {
                CancelInvoke("rot");
                Invoke("RotStart", 3f);
            }
        }
        else
        {
            if (transform.eulerAngles.z < 90 * step - 45)
            {
                omega *= coeff;
            }
            else if (transform.eulerAngles.z < 90 * step)
            {
                omega /= coeff;
            }
            if (transform.eulerAngles.z < 90)
            {
                CancelInvoke("rot");
                Invoke("RotStart", 3f);
            }
        }
    }
}
