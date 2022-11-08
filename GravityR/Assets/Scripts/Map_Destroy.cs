using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Destroy : MonoBehaviour
{
    public bool iscloned = true;
    public GameManager GM;
    // Start is called before the first frame update
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iscloned)
        {
            if (!GM.IsGameing)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
