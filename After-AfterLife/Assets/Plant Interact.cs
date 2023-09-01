using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteract : MonoBehaviour
{
    private bool touching_plant = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            touching_plant = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            touching_plant = false;
        }
    }
    void Update()
    {
        if (touching_plant == true && Input.GetKeyDown(KeyCode.Space) == true)
        {
            Debug.Log("Plant Taken");
        }
    }
}
