using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signScript : MonoBehaviour
{
    public string text;
    public gameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.showDialog(text);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.hideDialog();
    }
}
