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
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    public bool loseGame;


    private void Start()
    {
      
        PlayerAnim = Player.GetComponentInChildren<Animator>();
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Dokundun");
            EndPanel.SetActive(true);
            PlayerAnim.SetBool("lose", true);
            playerControllerScript.runningSpeed = 0;
            loseGame = true;
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
            loseGame = true;

            if (score >= 100)
            {
                transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
                Debug.Log("Win");
                PlayerAnim.SetBool("win", true);
                EndPanel.SetActive(true);
            }
            else
            {
                PlayerAnim.SetBool("lose", true);
                EndPanel.SetActive(true);
            
            }
                
        }
    }
    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
