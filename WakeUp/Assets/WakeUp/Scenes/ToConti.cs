using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToConti : MonoBehaviour
{
    [SerializeField]
    private float delay = 10f;
    [SerializeField]
    private string sceneName;
    private float timeLapse;



    // Update is called once per frame
    private void Update()
    {
        timeLapse += Time.deltaTime;

        if(timeLapse > delay)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
