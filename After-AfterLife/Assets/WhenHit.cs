using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenHit : MonoBehaviour
{
    public GameObject enemy;
    private bool Enemy_In_Range = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_In_Range == true && Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(enemy);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Hitzone")
        {
            Enemy_In_Range = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player Hitzone")
        {
            Enemy_In_Range = false;
        }
    }
}
