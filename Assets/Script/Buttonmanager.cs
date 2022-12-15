using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{
  public void OnStart()
  {
    SceneManager.LoadScene("SampleScene");
  }
  public void OnExit()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
  }
  public void OnTitle()
  {
    SceneManager.LoadScene("StartScene");
  }
}
