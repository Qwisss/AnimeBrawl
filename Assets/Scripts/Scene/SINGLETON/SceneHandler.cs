using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public static SceneHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchTo(int sceneIndex)
    {
        try
        {
            SceneManager.LoadScene(sceneIndex);
        }
        catch (System.Exception)
        {
            Debug.Log("Scene " + sceneIndex + " not found");
            throw;
        }
    }
}