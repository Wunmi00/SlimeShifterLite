using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : Singleton<MenuLoader>
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    

    IEnumerator sceneTransition(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
