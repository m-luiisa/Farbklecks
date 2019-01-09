using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToC1 : MonoBehaviour {

  public void ClickTutorial()
  {
    SceneManager.LoadScene("Tutorial1");
  }
}
