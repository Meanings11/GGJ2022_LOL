// This code is currently not used

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public int[] rooms = {-1,-1,-1};
    public int floorNum = 1;

    SpriteRenderer spriteRenderer;

    public Sprite floor1;
    public Sprite floor2;
    public Sprite floor3;

    // Start is called before the first frame update
    void Start()
    {  
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void addFloor(){
        floorNum++;
         if (floorNum == 1) {
            spriteRenderer.sprite = floor1;
        } else if (floorNum ==2) {
            spriteRenderer.sprite = floor2;
        } else if (floorNum == 3) {
            spriteRenderer.sprite = floor3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
