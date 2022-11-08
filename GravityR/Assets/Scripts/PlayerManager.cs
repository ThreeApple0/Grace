using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Vector2 MoveDir;
    public Vector2 RealVec;
    public float maxSpeed=50;
    public bool IsGameing = false;
    public FixedJoystick Joyst;
    public float MoveSpeed = 5f;
    public float BackSpeed = 5f;
    public Camera MainCam;
    public Text ScoreTx;
    public int NowScore=0;
    public int NowMaxScore = 0;
    public Rigidbody2D rb;
    public UIManager UIM;
    public GameManager GM;
    public TouchManager TM;
    public float vecMM;

    GameObject MapP;
    // Start is called before the first frame update
    void Awake()
    {
        MainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameing)
        {
            PlayerMove();
            CameraMove();
            ScoreCheck();
            MapCreate();
        }
        else
        {
            NowScore = 0;
            NowMaxScore = 0;
        }
    }

    void CameraMove()
    {
        // MainCam.transform.position = Vector3.Lerp(MainCam.transform.position,
        //new Vector3(MainCam.transform.position.x, transform.position.y + 5, MainCam.transform.position.z), Time.deltaTime * 2f);

        MainCam.transform.position = new Vector3(MainCam.transform.position.x, transform.position.y + 5, MainCam.transform.position.z);

    }

    void PlayerMove()
    {
        //MoveDir = new Vector2(Joyst.Horizontal,Joyst.Vertical).normalized;
        //RealVec = RealVec + MoveDir * MoveSpeed;
        if (TM.touchstat != 0)
        {
            MoveDir = new Vector2(MoveDir.x, MoveDir.y + MoveSpeed * Time.deltaTime);
        }
        else
        {
            MoveDir = new Vector2(MoveDir.x, MoveDir.y - BackSpeed * Time.deltaTime);
        }

        if(TM.touchstat == 2)
        {
            MoveDir = new Vector2(-MoveSpeed, MoveDir.y);
        }
        else if(TM.touchstat == 3)
        {
            MoveDir = new Vector2(MoveSpeed, MoveDir.y);
        }
        else
        {
            MoveDir = new Vector2(0, MoveDir.y);
        }

        if (MoveDir.y >= maxSpeed)
        {
            MoveDir = new Vector2(MoveDir.x, maxSpeed);
        }
        if (MoveDir.y <= 0)
        {
            MoveDir = new Vector2(MoveDir.x, 0);
        }


        vecMM = RealVec.magnitude;

        // rb.AddForce(MoveDir * MoveSpeed * Time.deltaTime, ForceMode2D.Force);
        //rb.velocity = RealVec;
        transform.position = new Vector3(transform.position.x + MoveDir.x*Time.deltaTime, transform.position.y + MoveDir.y* Time.deltaTime, 0);
    }
    void ScoreCheck()
    {
        NowScore = Mathf.RoundToInt( (Vector3.Distance(new Vector3(0, 5, 0), new Vector3(0,transform.position.y,0))/5f));
        if (transform.position.y < 5) NowScore = 0;
        if (NowMaxScore < NowScore) {
            NowMaxScore = NowScore;
            ScoreTx.text = NowMaxScore.ToString();
        }

    }


    void MapCreate()
    {
        if (transform.position.y > GM.mapNum * 50)
        {
            MapP = Instantiate(Resources.Load("Map1")) as GameObject;
            MapP.transform.position = new Vector3(-5, GM.mapNum * 50+10, 0);
            GM.mapNum++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT");
        Debug.Log(collision);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("GameOver");

            IsGameing = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            transform.rotation = Quaternion.Euler(0,0,0);
            MainCam.transform.position = new Vector3(0, 0, -10);
            transform.position = new Vector3(0, -2, 0);
            
            UIM.OnGameOver();

        }
    }
   
}
