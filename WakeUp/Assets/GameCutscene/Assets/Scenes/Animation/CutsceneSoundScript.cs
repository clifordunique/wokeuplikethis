using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSoundScript : MonoBehaviour
{
    public SceneManager levelToLoad;
    // Use this for initialization
    void Start()
    {

    }

    //Play Global
    private static CutsceneSoundScript instance = null;
    public static CutsceneSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        // Destroy gameobject in scene Scene12
        /**if (instance = SceneManager.GetActiveScene(levelToLoad))
        {
            Destroy(this.gameObject);
        }**/
    }
    //Play Gobal End

    // Update is called once per frame
    void Update()
    {

    }
}
