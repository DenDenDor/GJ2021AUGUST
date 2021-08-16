using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadingScene : MonoBehaviour
{
[SerializeField] private int _waitTime;
[SerializeField] private int _number_current_scene;
[SerializeField] private bool _isIntermediateScene;
 private void Start() 
 {
     if(_isIntermediateScene)
     {
     StartCoroutine(Load());
     }
 }
 public void LoadScene(int _numberOfScene) => SceneManager.LoadScene(_numberOfScene);
 private IEnumerator Load()
 {
     yield return new WaitForSeconds(_waitTime);
     LoadScene(_number_current_scene);
 }
 

}
