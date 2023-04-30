using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // the name of the scene to load

    public void ChangeScene()
    {
        // load the new scene
        SceneManager.LoadScene(sceneName);
    }
}