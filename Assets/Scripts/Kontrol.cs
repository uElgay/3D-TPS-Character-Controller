using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Kontrol : MonoBehaviour
{
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	private bool walking;
	private bool isWalking;
	private bool isMoving;
	public Transform playerTrans;
	
	void FixedUpdate(){
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
		if(isMoving==false){
			playerRigid.velocity =new Vector3(0,0,0);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			playerRigid.velocity = new Vector3(0,10.0f,0) * Time.deltaTime;
		}
	}
	void Update(){
		if(isWalking==false){
			if(Input.GetKeyDown(KeyCode.Space)){
			playerAnim.SetTrigger("jump");
			playerAnim.ResetTrigger("idle");
		}
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			playerAnim.SetTrigger("idle");
			playerAnim.ResetTrigger("jump");
		}
		if(Input.GetKeyDown(KeyCode.W)){
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			walking = true;
			isMoving = true;
			isWalking = true;
		}
		if(Input.GetKeyUp(KeyCode.W)){
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			walking = false;
			isMoving = false;
			isWalking = false;
		}
		if(Input.GetKeyDown(KeyCode.S)){
			playerAnim.SetTrigger("walkback");
			playerAnim.ResetTrigger("idle");
			isMoving = true;
		}
		if(Input.GetKeyUp(KeyCode.S)){
			playerAnim.ResetTrigger("walkback");
			playerAnim.SetTrigger("idle");
			isMoving = false;
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("run");
				playerAnim.ResetTrigger("walk");
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				w_speed = olw_speed;
				playerAnim.ResetTrigger("run");
				playerAnim.SetTrigger("walk");
			}
		}
		else
			w_speed = olw_speed;
	}
}

    