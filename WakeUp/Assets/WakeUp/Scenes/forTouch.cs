using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forTouch : MonoBehaviour
{
    public GameObject Option_1;

    public float goTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(HideAndShow(goTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator HideAndShow(float delay)
    {
        Option_1.SetActive(false);
        yield return new WaitForSeconds(delay);
        Option_1.SetActive(true);
    }

}
