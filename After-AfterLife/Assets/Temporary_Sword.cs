using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_Sword : MonoBehaviour
{
    private bool rotating = false;
    public GameObject Sword;
    public GameObject Player;
    public float rotspeed;
    public float maxrot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rotating = true;
        }
        if (rotating == true) 
        {
            Sword.transform.Rotate(0, 0, rotspeed * Time.deltaTime);
        }
        if (Sword.transform.eulerAngles.z <= maxrot) 
        {
            Debug.Log(Sword.transform.eulerAngles.z);
            rotating = false;
        }
        
    }
}
