using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboStyle : MonoBehaviour
{
    public Animator anim;
    public int noOfClick = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.9f;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay) 
        {
            noOfClick = 0;
        }
    }

}
