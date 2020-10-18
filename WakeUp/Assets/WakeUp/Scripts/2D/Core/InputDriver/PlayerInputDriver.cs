using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

namespace DYP
{
    public class PlayerInputDriver : BaseInputDriver
    {


        public Joystick joystick;
        public float runSpeed = 8f;

        //repawnn
        public Vector3 respawnPoint;


        //JUmp
        private bool m_isAxisInUse = false;
        public Animator anim;

        void Start() {

            Screen.SetResolution(1280, 720, true);
            Application.targetFrameRate = 30;
        }

        private void Update()
        {
            UpdateInput(Time.deltaTime);
        }

        public override void UpdateInput(float timeStep)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Horizontal = joystick.Horizontal;
            /**
            if (joystick.Horizontal >= .2f)
            {
                Horizontal = runSpeed;
            }
            else if (joystick.Horizontal <= -.2f)
            {
                Horizontal = -runSpeed;
            }
            else {
                Horizontal = 0f;
            }
            **/
            //Jump naman


            //Vertical = Input.GetAxisRaw("Vertical");
            //Vertical = joystick.Vertical;
            Jump = Input.GetButtonDown("Jump");

            //Jump = Input.("Vertical");
            //Convert pa Axis try

            float Vertical = Input.GetAxisRaw("Vertical");

            /**if (Vertical >= .5f) {
                anim.SetBool("SpeedY");
            }**/

            //Jump Button and DashButton

            //Dash = Input.GetButtonDown("Fire3");

            /** if(Dash = )
             {
                 Get
             }**/



            /**Dash = Input.GetButtonDown("Fire3");

            HoldingDash = Input.GetButton("Fire3**/

            dashBtn();


            HoldingJump = CrossPlatformInputManager.GetButton("Jump");



            ReleaseJump = CrossPlatformInputManager.GetButtonUp("Jump");
        }

        public void Left() {
            Horizontal = -runSpeed;
        }

        public void Right() {
            Horizontal = runSpeed;
        }

        public void dashBtn() {
          

            Dash = Input.GetButtonDown("Fire3");
            HoldingDash = Input.GetButton("Fire3");
        }

        public void Upressed() {
            Horizontal = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "FallDetector") 
            {
                transform.position = respawnPoint;
            }
            if (other.tag == "CheckPoint")
            {
                respawnPoint = other.transform.position;
            }
        }
    }
}
