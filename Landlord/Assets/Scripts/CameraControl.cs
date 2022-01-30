using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float minX = 0f;
	public float maxX;
	public float scrollStep;

	public float timeDuration = 1.5f;
	
   public void leftPan()
   {
	   if (transform.position.x <= minX)
	   {
		   return;
	   }
	   float endPos = transform.position.x - scrollStep;
	   endPos = Mathf.Clamp(endPos, minX, maxX);
	   gameObject.transform.DOMoveX(endPos, timeDuration);
   }

    public void rightPan() {
	    if (transform.position.y >= maxX)
	    {
		    return;
	    }

	    float endPos = Mathf.Clamp(transform.position.x + scrollStep, minX, maxX);
	    gameObject.transform.DOMoveX(endPos, timeDuration);
   }
}
