using System;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable Unity.IncorrectMonoBehaviourInstantiation

namespace Player
{
    public class Player_Movement : MonoBehaviour
    {
        private void Update()
        {
            #region ChangeStates

            if (Input.GetKeyDown(KeyCode.F))
            {
                Player_Api.ChangeFlyMode();
            }

            //Debug.Log(transform.InverseTransformDirection(Player_Api.Rb.velocity));
            if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
            {
                
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                var localVelocity = transform.InverseTransformDirection(Player_Api.Rb.velocity);
                if (localVelocity.z > 0)
                {
                    Player_Api.Rb.AddForce(-Player_Api.player.transform.forward * localVelocity.z / 4 -
                                           Player_Api.player.transform.right * (localVelocity.z / 2));
                }
                else if (localVelocity.z < 0)
                {
                    Player_Api.Rb.AddForce(-Player_Api.player.transform.forward * localVelocity.z / 4 +
                                           Player_Api.player.transform.right * (localVelocity.z / 2));
                }
            }
            else if (Input.GetKey(KeyCode.E))
            {
                var localVelocity = transform.InverseTransformDirection(Player_Api.Rb.velocity);
                if (localVelocity.z > 0)
                {
                    Player_Api.Rb.AddForce(-Player_Api.player.transform.forward * localVelocity.z / 4 +
                                           Player_Api.player.transform.right * (localVelocity.z / 2));
                }
                else if (localVelocity.z < 0)
                {
                    Player_Api.Rb.AddForce(-Player_Api.player.transform.forward * localVelocity.z / 4 -
                                           Player_Api.player.transform.right * (localVelocity.z / 2));
                }
            }

            #endregion

            #region Moving

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 tempVect = Player_Api.player.transform.forward * v +
                               Player_Api.player.transform.right * h;

            tempVect = tempVect.normalized * (500 * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Player_Api.Rb.AddForce(tempVect * 2);
            }
            else
            {
                Player_Api.Rb.AddForce(tempVect);
            }

            if (Player_Api._flyMode)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    Player_Api.Rb.AddForce(Player_Api.player.transform.up.normalized * 50);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player_Api.Rb.AddForce(Player_Api.player.transform.up.normalized * 500);
                }
            }

            #endregion

            #region Rotation

            if (Player_Api.IsGrounded)
            {
                Player_Api.player.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
                //Player_Api.player.transform.localEulerAngles = new Vector3(0, Player_Api.player.transform.localEulerAngles.y, 0); //TODO: Lerp

                if (!Player_Api._flyMode)
                {
                    Quaternion target = Quaternion.Euler(0, Player_Api.player.transform.eulerAngles.y, 0);
                    Player_Api.player.transform.rotation =
                        Quaternion.Slerp(Player_Api.player.transform.rotation, target, Time.deltaTime);
                }
            }
            else
            {
                Player_Api.player.transform.Rotate(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0);
                //this.gameObject.transform.localEulerAngles = new Vector3(this.gameObject.transform.localEulerAngles.x, this.gameObject.transform.localEulerAngles.y, 0);
            }

            #region CursorLock
            
            if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
            }
            
            #endregion

            if (Player_Api._flyMode)
            {
                if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
                {
                    Quaternion target = Quaternion.Euler(0, Player_Api.player.transform.eulerAngles.y, 0);
                    Player_Api.player.transform.rotation =
                        Quaternion.Slerp(Player_Api.player.transform.rotation, target, Time.deltaTime * 6);
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    Player_Api.player.transform.Rotate(new Vector3(0, 0, 2) * Time.deltaTime * 60);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Player_Api.player.transform.Rotate(new Vector3(0, 0, -2) * Time.deltaTime * 60);
                }
            }
            else
            {
                // if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
                // {
                //     Quaternion target = Quaternion.Euler(0, Player_Api.player.transform.eulerAngles.y, 0);
                //     Player_Api.player.transform.rotation =
                //         Quaternion.Slerp(Player_Api.player.transform.rotation, target, Time.deltaTime * 6);
                // }
                // else if (Input.GetKey(KeyCode.Q))
                // {
                //     Player_Api.player.transform.Rotate(new Vector3(0, 0, 2) * Time.deltaTime * 60);
                // }
                // else if (Input.GetKey(KeyCode.E))
                // {
                //     Player_Api.player.transform.Rotate(new Vector3(0, 0, -2) * Time.deltaTime * 60);
                // }
            }

            #endregion
        }
    }
}