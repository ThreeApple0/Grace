using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public Vector2 touchstart;
    public Vector2 touchnow;
    public bool istouch = false;
    public int touchstat = 0; // 0:터치안함 1: 앞으로 2:왼쪽 3:오른쪽

    public GameObject touchimage;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        touchstat = 0;
        touchimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GM.IsGameing)
        {
            return;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!istouch)
            {
                istouch = true;
                touchstart = touch.position;
            }
            touchnow = touch.position;
        }
        else
        {
            istouch = false;
        }

        if (istouch)
        {
            touchimage.SetActive(true);
            touchimage.transform.position = touchstart;
            if (touchstart.x < touchnow.x - 100)
            {
                touchstat = 3;
            }
            else if(touchstart.x > touchnow.x + 100)
            {
                touchstat = 2;
            }
            else
            {
                touchstat = 1;
            }
        }
        else
        {
            touchstat = 0;
            touchimage.SetActive(false);
        }
    }
}
