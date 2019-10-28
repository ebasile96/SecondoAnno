using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanInput : MonoBehaviour
{
    
    public Animator EthanAnim;
    bool moving = false;
    float targetForward;
    public float velocita;
    public float velocitaRotazione;
    Vector3 position;
    Quaternion rotation;
    [Header("JumpData")]
    //arco del movimento
    public AnimationCurve jumpCurve;
    //tempo che impiega  a fare il salto
    public float JumpTime = 1;
    bool Jumping = false;
    float JumpTimeStart;
    [Tooltip("Altezza salto (moltiplicatore della curva)")]
    public float JumpHeight = 1;

    


    private void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {

        //EthanAnim.SetBool("GoToWalk", Input.GetKey(KeyCode.W));
        //EthanAnim.SetBool("GoToBackward", Input.GetKey(KeyCode.S));
        //EthanAnim.SetBool("TurnLeft", Input.GetKey(KeyCode.A));
        //EthanAnim.SetBool("TurnRight", Input.GetKey(KeyCode.D));
        //EthanAnim.SetBool("StandTurnLeft1", Input.GetKey(KeyCode.Q));
        //EthanAnim.SetBool("StandTurnRight1", Input.GetKey(KeyCode.E));

        //input
        float forward = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        bool running = Input.GetKey(KeyCode.LeftShift);


        if (Input.GetKeyDown(KeyCode.Q))
            EthanAnim.SetTrigger("L2");

        if (Input.GetKeyDown(KeyCode.E))
            EthanAnim.SetTrigger("R3");

        if (Input.GetKeyDown(KeyCode.Space) && !Jumping)
        {
            EthanAnim.SetTrigger("Jump");
            Jumping = true;
            JumpTimeStart = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !Jumping)
        {
            EthanAnim.SetTrigger("Dash");
            
        }

            


        //logica
        if (running) forward = forward * 2;
            targetForward = Mathf.Lerp(targetForward, forward, Time.deltaTime * 4);

        position = position + this.transform.forward * targetForward * velocita * Time.deltaTime;
        rotation = Quaternion.Euler(Vector3.up * rotate * velocitaRotazione * Time.deltaTime) * rotation;

        
        if (Jumping)
        {
            float tempoPassato = Time.time - JumpTimeStart;
            float ratio = Mathf.Clamp01(tempoPassato / JumpTime);
            position.y = jumpCurve.Evaluate(ratio) * JumpHeight;

            if (ratio == 1)
                Jumping = false;
        }

       
        


        //rendering
        this.transform.SetPositionAndRotation(position, rotation);
        EthanAnim.SetFloat("forward", targetForward);
        EthanAnim.SetFloat("rotate", rotate);


        
    }

    public void CheckInput()
    {
        if (Input.GetKey(KeyCode.W) && !moving)
        {
            moving = !moving;
            EthanAnim.SetBool("GoToWalk", moving);
        }
        else
        if (Input.GetKey(KeyCode.W) && moving)
        {
            moving = !moving;
            EthanAnim.SetBool("GoToWalk", moving);
        }
    }

    public void StandTurn()
    {
        if(Input.GetKey(KeyCode.A) && !moving)
        {
            moving = !moving;
            EthanAnim.SetBool("StandTurnLeft1", moving);

        }else if (Input.GetKey(KeyCode.A) && moving)
        {
            moving = !moving;
            EthanAnim.SetBool("StandTurnLeft1", moving);
        }
    }
}
