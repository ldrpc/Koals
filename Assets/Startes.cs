using UnityEngine;
using System.Collections;
using System;
using ExitGames.Demos.DemoAnimator;

public class Startes : Photon.PunBehaviour, IPunObservable
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        

    }
    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.transform.position);
           
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();

           

        }
    }




}
