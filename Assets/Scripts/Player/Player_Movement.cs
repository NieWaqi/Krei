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
            #region Moving
            
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            
            Vector3 tempVect = Player_Api.player.transform.forward * v +
                               Player_Api.player.transform.right * h;
            
            tempVect = tempVect.normalized * (500 * Time.deltaTime);
            
            Player_Api.Rb.AddForce(tempVect);
            
            #endregion

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player_Api.Rb.AddForce(Player_Api.player.transform.up.normalized * 500);
            }
        }
    }
}
