using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    // ReSharper disable once InconsistentNaming
    public class Player_Api : MonoBehaviour
    {
        #region Unity Fields

        [FormerlySerializedAs("player")] [FormerlySerializedAs("Player_GameObject")]
        public GameObject playerModel;

        [FormerlySerializedAs("player_downPoint")]
        public GameObject playerDownPoint;

        #endregion

        #region Info Fields
        
        public static Rigidbody Rb { get; private set; }
        public static GameObject player { get; set; }
        public static RaycastHit DownHit { get; set; }

        public static bool IsGrounded => DownHit.distance < 4.1f;

        #endregion

        private void Start()
        {
            player = playerModel;
            Rb = playerModel.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Physics.SphereCast(
                playerDownPoint.transform.position, // current down point
                0.75f, // Player radius
                playerDownPoint.transform.TransformDirection(Vector3.down), // Hit down
                out var downHit)) // Return ray
            {
                DownHit = downHit; //Send hit to static
                Debug.DrawLine(transform.position, downHit.point, Color.red);
            }

            
            //Test Func
            if (IsGrounded)
            {
                this.gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                this.gameObject.transform.localEulerAngles = new Vector3(0, this.gameObject.transform.localEulerAngles.y, 0);
            }
            else
            { 
                this.gameObject.transform.Rotate(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0);
                //this.gameObject.transform.localEulerAngles = new Vector3(this.gameObject.transform.localEulerAngles.x, this.gameObject.transform.localEulerAngles.y, 0);
            }

            if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(this.transform.rotation.x * -1,0,this.transform.rotation.z * -1) * Time.deltaTime * 600);
            }
            else if(Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0,0,2) * Time.deltaTime * 60);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(0,0,-2) * Time.deltaTime * 60);
            }
            
        }
    }
}