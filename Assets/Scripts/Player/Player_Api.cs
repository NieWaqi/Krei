using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    // ReSharper disable once InconsistentNaming
    public class Player_Api : MonoBehaviour
    {
        #region Unity Fields

        [FormerlySerializedAs("Player_GameObject")]
        public GameObject player;

        [FormerlySerializedAs("player_downPoint")]
        public GameObject playerDownPoint;

        #endregion

        #region Info Fields

        public GameObject playerModel {}
        
        public Rigidbody Rb { get; private set; }
        public RaycastHit DownHit { get; set; }

        #endregion

        #region Calc Fields

        //...

        #endregion


        private void Start()
        {
            Rb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Physics.SphereCast(
                playerDownPoint.transform.position, // current down point
                0.75f, // Player radius
                transform.TransformDirection(Vector3.down), // Hit down
                out var downHit)) // Return ray
            {
                DownHit = downHit; //Send hit to static
            }
        }
    }
}