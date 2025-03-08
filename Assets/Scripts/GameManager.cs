using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CollectedCoins;
    public int TotalNumberOfCoins;

    public TextMeshProUGUI displayCoins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.TotalNumberOfCoins = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        Debug.Log("Total Number of coins to collect: " + this.TotalNumberOfCoins);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.CollectedCoins >= this.TotalNumberOfCoins)
        {
            Debug.Log("You won!");
            SceneManager.LoadScene("MenuScene"); // Move to Main Menu after collecting coins
        }
    }

    public void CoinCollected()
    {
        this.CollectedCoins = this.CollectedCoins + 1;
        displayCoins.text = this.CollectedCoins.ToString() + " / " + this.TotalNumberOfCoins.ToString() + " coins collected!"; // display number of coins collected
        Debug.Log("Collected " + this.CollectedCoins + " / " + this.TotalNumberOfCoins + " coins.");
    }
}
