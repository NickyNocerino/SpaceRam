using UnityEngine;
using System.Collections;

public class redship : MonoBehaviour {
    public node startpos;
    public int startdir;
    public node lastnode;
    public int dir;
    public node pos;
    private int[] queue;
    public int qnum;
    private int move;
    public blueship enemy;
    private AudioSource audio;
    // Use this for initialization
    void Start () {
        transform.position = startpos.transform.position;
        pos = startpos;
        pos.occupied = true;
        lastnode = pos.down;
        dir = startdir;
        queue = new int[qnum];
        move = 0;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (move < queue.Length)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                queue[move] = 1;
                move++;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                queue[move] = 3;
                move++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                queue[move] = 4;
                move++;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                queue[move] = 2;
                move++;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Resolve());
        }
    }
    void moveUp()
    {
        dir = 1;
        if (pos.up.occupied == false)
        {
            lastnode = pos;
            
            pos = pos.up;
            transform.position = pos.transform.position;
            lastnode.occupied = false;
            pos.occupied = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Rotate(Vector3.forward * 0);

        }
        else
        {
            if (enemy.dir != 3)
            {
                Application.LoadLevel("P1win");
                // win
            }
            else
            {
                Application.LoadLevel("Draw");
                //draw
            }
            //in case of collission
        }
    }
    void moveDown()
    {
        dir = 3;
        if (pos.down.occupied == false)
        {
            lastnode = pos;
            
            pos = pos.down;
            transform.position = pos.transform.position;
            lastnode.occupied = false;
            pos.occupied = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Rotate(Vector3.forward * 180);

        }
        else
        {
            if (enemy.dir != 1)
            {
                Application.LoadLevel("P1win");
                // win
            }
            else
            {
                Application.LoadLevel("Draw");
                //draw
            }
            //in case of collission
        }
    }
    void moveLeft()
    {
        dir = 4;
        if (pos.left.occupied == false)
        {
            lastnode = pos;
            
            pos = pos.left;
            transform.position = pos.transform.position;
            lastnode.occupied = false;
            pos.occupied = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Rotate(Vector3.forward * 90);

        }
        else
        {
            if (enemy.dir != 2)
            {
                Application.LoadLevel("P1win");
                // win
            }
            else
            {
                Application.LoadLevel("Draw");
                //draw
            }
            //in case of collission
        }
    }
    void moveRight()
    {
        dir = 2;
        if (pos.right.occupied == false)
        {
            lastnode = pos;
            
            pos = pos.right;
            transform.position = pos.transform.position;
            lastnode.occupied = false;
            pos.occupied = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Rotate(Vector3.forward * -90);

        }
        else
        {
            if (enemy.dir != 4)
            {
                Application.LoadLevel("P1win");
                // win
            }
            else
            {
                Application.LoadLevel("Draw");
                //draw
            }
            //in case of collission
        }
    }
    IEnumerator Resolve()
    {
        for(int i=0;i<move;i++)
        {
            if (queue[i] == 1)
                moveUp();
            if (queue[i] == 3)
                moveDown();
            if (queue[i] == 2)
                moveRight();
            if (queue[i] == 4)
                moveLeft();
            audio.Play();
            yield return new WaitForSeconds(0.15f);
        }
        move = 0;
    }
    
}
