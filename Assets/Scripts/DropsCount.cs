using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsCount : MonoBehaviour {

  public int green;
  public int red;
  public int yellow;
  public int cyan;
  public int blue;
  public int magenta;


  // Use this for initialization
  void Start () {
    PlayerPrefs.SetInt("Green", green);
    PlayerPrefs.SetInt("Red", red);
    PlayerPrefs.SetInt("Yellow", yellow);
    PlayerPrefs.SetInt("Cyan", cyan);
    PlayerPrefs.SetInt("Blue", blue);
    PlayerPrefs.SetInt("Magenta", magenta);
  }
	
}
