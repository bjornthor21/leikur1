using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{
    public Transform player;  // breyta sem geymir stöðu leikmanns (rotation og position)
    public Vector3 offset;    // offsett svo camerann horfir aftan á leikmann
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;  // horfir camerann á leikmann

    void Update()
    {
        // ef offsett er í local eða world
        if (offsetPositionSpace == Space.Self)
        {
            // setur cameruna á sinn stað miðað við local
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            // setur cameruna á sinn stað miðað við world
            transform.position = player.position + offset;
        }

        // lætur cameruna snúa í sömu átt og player horfir
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            // snýr camerunni eins og player snýr
            transform.rotation = player.rotation;
        }
    }
}
