using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneHandler : MonoBehaviour
{

    public static GameSceneHandler instance;

    [SerializeField] private string _currentScene;

    private AsyncOperation _load;
    private AsyncOperation _unLoad;
     
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name != "NewLocomotionSystemtest")
            {
                _currentScene = SceneManager.GetSceneAt(i).name;
                break;
            }
        }
    }

    private void SwithScenes(string toSceneName)
    {
        Debug.Log("Current Scene: " + _currentScene);
        Debug.Log("Target Scene: " + toSceneName);

        _load = SceneManager.LoadSceneAsync(toSceneName, LoadSceneMode.Additive);
        _unLoad = SceneManager.UnloadSceneAsync(_currentScene);
        _currentScene = toSceneName;
    }

    public void StartTransition(string toSceneName)
    {
        StartCoroutine(Transition(toSceneName));
    }

    public IEnumerator Transition(string toSceneName)
    {
        SwithScenes(toSceneName);

        yield return new WaitForSeconds(DataConfig.UpdateRate);

        while (_load.isDone == false && _unLoad.isDone == false)
        {
            yield return new WaitForSeconds(DataConfig.UpdateRate);
        }

        _load = null;
        _unLoad = null;

    }
}
