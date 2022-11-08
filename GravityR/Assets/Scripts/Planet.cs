using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlayerManager PM;
    public GameManager GM;
    public GameObject Player;
    public Map_Destroy MD;
    public Rigidbody2D Plrb;
    public float GravityForce;
    public float Radius=1;
    public float Distance=1;
    public float m=1;

    public Vector2 dir;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Plrb = Player.GetComponent<Rigidbody2D>();
        PM = Player.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!MD.iscloned) return;
        Distance = Vector2.Distance(Player.transform.position, transform.position);
        GravityForce = 9.8f * (m / ((Distance - Radius)));
        dir = (transform.position - Player.transform.position).normalized;
        if (PM.IsGameing)
        {
            Plrb.AddForce(GM.GravitySpeed * dir * GravityForce * Time.deltaTime);
        }
       
    }
}
