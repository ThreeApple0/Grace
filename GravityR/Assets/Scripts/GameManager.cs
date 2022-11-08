using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameing = false;
    public float GravitySpeed = 1;
    public PlayerManager PlM;
    public int mapNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resett()
    {
        PlM.RealVec = Vector2.zero;
        PlM.MoveDir = Vector2.zero;
        
        mapNum = 0;
    }
}
