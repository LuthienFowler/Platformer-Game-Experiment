using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour
{
    // Variables
    private PlayerMovement pMScript;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        pMScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
    }

    // Moving the background left if the player keeps moving right
    void MoveLeft()
    {
        if(pMScript.hi == 1 && Player.transform.position.x == pMScript.xBoundRight)
        {
            transform.Translate(Vector3.left * pMScript.speed * Time.deltaTime);
        } else if (pMScript.hi == -1 && Player.transform.position.x == pMScript.xBoundLeft)
        {
            transform.Translate(Vector3.right * pMScript.speed * Time.deltaTime);
        }
    }
}
