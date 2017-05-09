using UnityEngine;
using System.Collections;

public class endScreen : MonoBehaviour {
    public SpriteRenderer play;
    public SpriteRenderer quit;
    public bool playagain;
	// Use this for initialization
	void Start () {
        playagain = true;
        quit.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            playagain = !playagain;
            if (quit.enabled == true)
            {
                quit.enabled = false;
                play.enabled = true;
            }
            else
            {
                quit.enabled = true;
                play.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playagain)
            {
                Application.LoadLevel("MainGame");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
