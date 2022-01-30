using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

   public float speed = 4f;
   public void leftPan() {
        Vector3 p = transform.position;
        if (p.x <= 2f) return;
        p.x -= speed;
        transform.position = p;
   }

    public void rightPan() {
        Vector3 p = transform.position;
        if (p.x >= 53f) return;
        p.x += speed;
        transform.position = p;
   }
}
