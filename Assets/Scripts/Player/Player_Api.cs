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
                transform.TransformDirection(Vector3.down), // Hit down
                out var downHit)) // Return ray
            {
                DownHit = downHit; //Send hit to static
            }
        }
    }
}