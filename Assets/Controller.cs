using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.Networking;
using System;
using ExitGames.Demos.DemoAnimator;

public class Controller : Photon.PunBehaviour, IPunObservable
{
    // Update is called once per frame
    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    public Camera cam;
    public Vector2 location;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        var move = new Vector3(x, y, 0);

        this.gameObject.transform.position += move  * 3.5f * Time.deltaTime;



    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        GameObject countText = GameObject.Find("CountText");
        countText.GetComponent<Text>().text = "Count: " + count.ToString();
        GameObject winText = GameObject.Find("WinText");
        winText.GetComponent<Text>().text = "";

       
        }


    

    public bool hello;
    private Vector3 position;

    

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.transform.position);
            stream.SendNext(this.gameObject.active);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();

            this.gameObject.SetActive((Boolean)stream.ReceiveNext());

        }
    }

 
}
