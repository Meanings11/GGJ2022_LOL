using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenterEvictButton : MonoBehaviour
{
    public GameObject EvictDialogUI;
    public GameObject Renter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EvictOnClick()
    {
        EvictDialogUI.SetActive(true);
    }

    public void YesOnClick()
    {
        Destroy(Renter);
    }

    public void NoOnClick()
    {
        EvictDialogUI.SetActive(false);
    }
}
