using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
  public void ClickCyan()
  {
    SceneManager.LoadScene("Cyan1");
  }

  public void ClickAgain()
  {
    SceneManager.LoadScene("Cyan1");
  }
}

