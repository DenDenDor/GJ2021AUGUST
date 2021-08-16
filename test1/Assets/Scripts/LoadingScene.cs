using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{

[SerializeField] private int _number_of_lastScene;
[SerializeField] private int _number_of_firstScene;
 private void LoadScene(int _numberOfScene) => SceneManager.LoadScene(_numberOfScene);
 
 public void Exit() => LoadScene(_number_of_lastScene);
 public void Play() => LoadScene(_number_of_firstScene);

 

}
