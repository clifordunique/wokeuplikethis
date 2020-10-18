using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    

    private void Awake()
    {
        GetComponent<CutsceneSoundScript>();
        //Destroy(this.gameObject);

        Destroy(GameObject.Find("BGMusic"));

    }
}
