using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseButton : MonoBehaviour {
    public void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}