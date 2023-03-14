using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameControllerScript : MonoBehaviour
{

    public int levelNumber;

    public Player_Controller player;
    public TextMeshProUGUI chatBoxText;
    public GameObject chatBox;

    int score;
    int lives;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<Player_Controller>();
        score = player.score;
        lives = player.lives;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.score;
    }

    public void next_Level()
    {
        SceneManager.LoadScene(levelNumber + 1);
    }

    public void showDialog(string text) 
    {
        chatBox.SetActive(true);
        chatBoxText.SetText(text);
    }

    public void hideDialog()
    {
        chatBox.SetActive(false);
    }
}
