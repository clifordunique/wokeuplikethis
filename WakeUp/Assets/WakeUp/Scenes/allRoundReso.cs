using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class allRoundReso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        Application.targetFrameRate = 30;
    }

    public void Credits()
    {
        SceneManager.LoadScene("ScrollingCredit");
    }

    public void FaceBook()
    {
        Application.OpenURL("https://www.facebook.com/wakeupmaryofficial/");
    }

    public void GitHub()
    {
        Application.OpenURL("https://github.com/HiZtoria");
    }

    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCsWwle2S0dRAahsYRmi01Ig?view_as=subscriber");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/wakeupmarygame");
    }

    public void BackMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /**void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GoToStart();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToStart();
        }

        //?? Touch
    }
    **/
    public void GoToStart()
    {

        //playAnim();
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator playAnim()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");


    }

}
