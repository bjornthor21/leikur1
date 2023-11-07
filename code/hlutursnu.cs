using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        // Snýr hlut í hring notað til að snúa peningunum
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);
    }
}
