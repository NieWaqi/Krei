using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    // ReSharper disable once InconsistentNaming
    public class Player_Api : MonoBehaviour
    {
        #region Fields

        [FormerlySerializedAs("player")] [FormerlySerializedAs("Player_GameObject")]
        public GameObject playerModel;

        [FormerlySerializedAs("player_downPoint")]
        public GameObject playerDownPoint;

        public static Rigidbody Rb { get; private set; }
        public static GameObject player { get; set; }
        public static RaycastHit DownHit { get; set; }
        // public static bool SlidingRight { get; set; }
        // public static bool SlidingLeft { get; set; }
        public static bool _flyMode { get; set; }
        public static void ChangeFlyMode()
        {
            _flyMode = !_flyMode;
        }

        public static bool IsGrounded => DownHit.distance < 4.1f;

        #endregion

        #region AsyncFuncs

        

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
        }
    }
}