using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionDiablo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Stell dich doch nicht so blöd an!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.tag == "Green")
        {
            Debug.Log("GRün hat getroffen!");
            GameObject.Find("DiabloKörper").GetComponent<Renderer>().material.color = Color.green;
            Destroy(other.gameObject);
        }

    }
}
