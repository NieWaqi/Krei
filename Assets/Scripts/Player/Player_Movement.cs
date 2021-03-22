using System;
using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable Unity.IncorrectMonoBehaviourInstantiation

namespace Player
{
    public class Player_Movement : MonoBehaviour
    {
        private Player_Api api = new Player_Api();

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            
            Vector3 tempVect = api.player.transform.forward * v +
                               api.player.transform.right * h;
            tempVect = tempVect.normalized * (500 * Time.deltaTime);
            api.Rb.AddForce(tempVect);
        }
    }
}
