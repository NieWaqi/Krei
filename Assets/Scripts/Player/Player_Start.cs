using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    // ReSharper disable once InconsistentNaming
    public class Player_Start : MonoBehaviour
    {
        [FormerlySerializedAs("Player")] public GameObject player;
        void Start()
        {
            var playerStartTransform = transform;
            player.transform.position = playerStartTransform.position;
            player.transform.rotation = playerStartTransform.rotation;
            player.transform.eulerAngles = playerStartTransform.eulerAngles;
        }
    }
}
