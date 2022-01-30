using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private float time;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        time=5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButtonDown(0)) {
            Debug.Log("start");
            transition.SetTrigger("Start");
            SceneManager.LoadScene (sceneBuildIndex:1);
        }*/
        if(Time.time>time-1){
            transition.SetTrigger("Start");
        }
        if(Time.time>time){
            SceneManager.LoadScene (sceneBuildIndex:1);
        }

    }
}
