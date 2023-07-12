using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerControllerScript;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Dokundun");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Bitti");
            playerControllerScript.runningSpeed = 0;
        }
    }
    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }

}
