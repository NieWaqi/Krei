using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Player
{
    public class Player_DownPoint_StopRotation : MonoBehaviour
    {
        Quaternion rotation;
        void Awake()
        {
            rotation = transform.rotation;
        }
        void LateUpdate()
        {
            transform.rotation = rotation;
        }
    }
}
