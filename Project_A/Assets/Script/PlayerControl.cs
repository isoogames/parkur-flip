using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    bool run = true, zemin = false;
    bool rot = true;
    bool jump = false;
    Rigidbody rb;
    public GameObject childPlayer, jumpBtn, restPanel, playerClon;
    Quaternion basRot;
    Animation cPlayeranim;
    public Transform z1, z2, z3;
    float xForce,yForce,zForce;
    private void Start()
    {
        basRot = childPlayer.transform.rotation;
        rb = transform.GetComponent<Rigidbody>();
        cPlayeranim = childPlayer.GetComponent<Animation>();
        cPlayeranim.Play("kosAnim");
        
    }
    void FixedUpdate()
    {
        
        if (jump)
        {
            rb.AddForce(xForce, yForce, zForce, ForceMode.Impulse);
            jump = false;
        }
    }
    public void jump_T()
    {
        cPlayeranim.Stop();
        zemin = false;
        jump = true;
        jumpBtn.SetActive(false);

    }
    private void rotreset()
    {
        childPlayer.transform.rotation = Quaternion.RotateTowards(childPlayer.transform.rotation, basRot, Time.deltaTime * 50f);
    }
    private void Update()
    {
        if (run)
        {
            transform.Translate(0, 0, Time.deltaTime * 2.2f);
        }
        if (zemin)
        {
            rotreset();
        }

        if (Input.GetMouseButton(0))
        {

            if (rot)
            {
                childPlayer.transform.Rotate(Time.deltaTime * 360f, 0, 0);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            rot = false;
        }
    }
    float playerotX;
    private void playerGameOver()
    {

        playerClon.transform.position = childPlayer.transform.position;
        playerClon.transform.rotation = childPlayer.transform.rotation;
        childPlayer.SetActive(false);
        playerClon.SetActive(true);

    }
    float zeminX;
    private void dozeminKontrol(GameObject zemin)
    {
        zeminX = zemin.transform.localPosition.x;
      
        if (zeminX==1.6f)  // right
        {
           
            if (bulunZeminx == 1.6f)
            {
                xForce = 0;
                yForce = 7.5f;
                zForce = 2.2f;
            }
            else if(bulunZeminx == -1.6f)
            {
                xForce = 1.7f;
                yForce = 7.6f;
                zForce = 2.2f;
            }
            else
            {
                xForce = 0.8f;
                yForce = 7.5f;
                zForce = 2.2f;
            }
        }
        else if (zeminX==-1.6f) // left
        { 
            
            if (bulunZeminx == 1.6f)
            {
                xForce = -1.7f;
                yForce = 7.6f;
                zForce = 2.2f;
              
            }
            else if (bulunZeminx == -1.6f)
            {
                xForce = 0;
                yForce = 7.5f;
                zForce = 2.2f;
            }
            else
            {
                xForce = -0.8f;
                yForce = 7.5f;
                zForce = 2.2f;
            }
        }
        else // center
        {
           
            if (bulunZeminx == 1.6f)
            {
                xForce = -0.8f;
                yForce = 7.5f;
                zForce = 2.2f;
            }
            else if (bulunZeminx == -1.6f)
            {
                xForce = 0.8f;
                yForce = 7.5f;
                zForce = 2.2f;
            }

            else
            {
                xForce = 0f;
                yForce = 7.5f;
                zForce = 2.2f;
            }
        }
       
    }


    int id;
    GameObject doZemin;
    float bulunZeminx;
    private void OnCollisionEnter(Collision collision)
    {
        
         if (collision.gameObject.tag.Equals("zemin1"))
        {
            playerotX = childPlayer.transform.localRotation.x * 100;
            
            if (playerotX<=20&&playerotX>=-20)
            {
                transform.rotation = new Quaternion(0,0,0,0);
                rot = true;
                run = true;
                jumpBtn.SetActive(true);
                zemin = true;
                cPlayeranim.Play("kosAnim");
                id = collision.gameObject.transform.GetSiblingIndex();
                bulunZeminx = collision.transform.localPosition.x;
                if (id<3)
                {
                    doZemin = z1.GetChild(id + 1).gameObject;
                }
                else
                {
                    doZemin = z2.GetChild(0).gameObject;
                }
                dozeminKontrol(doZemin);
            }
            else
            {
                run = false;
                restPanel.SetActive(true);
                cPlayeranim.Stop();
                playerGameOver();
            }
           
        }
        if (collision.gameObject.tag.Equals("zemin2"))
        {
            playerotX = childPlayer.transform.localRotation.x * 100;

            if (playerotX <= 20 && playerotX >= -20)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rot = true;
                run = true;
                jumpBtn.SetActive(true);
                zemin = true;
                cPlayeranim.Play("kosAnim");
                bulunZeminx = collision.transform.localPosition.x;
                id = collision.gameObject.transform.GetSiblingIndex();
                if (id < 3)
                {
                    doZemin = z2.GetChild(id + 1).gameObject;
                }
                else
                {
                    doZemin = z3.GetChild(0).gameObject;
                }
                dozeminKontrol(doZemin);
            }
            else
            {
                run = false;
                restPanel.SetActive(true);
                cPlayeranim.Stop();
                playerGameOver();
            }

        }
        if (collision.gameObject.tag.Equals("zemin3"))
        {
            playerotX = childPlayer.transform.localRotation.x * 100;

            if (playerotX <= 20 && playerotX >= -20)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rot = true;
                run = true;
                jumpBtn.SetActive(true);
                zemin = true;
                cPlayeranim.Play("kosAnim");
                bulunZeminx = collision.transform.localPosition.x;
                id = collision.gameObject.transform.GetSiblingIndex();
                if (id < 3)
                {
                    doZemin = z3.GetChild(id + 1).gameObject;
                }
                else
                {
                    doZemin = z1.GetChild(0).gameObject;
                }
                dozeminKontrol(doZemin);
            }
            else
            {
                run = false;
                restPanel.SetActive(true);
                cPlayeranim.Stop();
                playerGameOver();
            }

        }
        
        if (collision.gameObject.tag.Equals("dont"))
        {
            run = false;
            restPanel.SetActive(true);
            cPlayeranim.Stop();
            playerGameOver();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("zemin"))
        {
            jumpBtn.SetActive(false);
      
        }

    }
   

}
