using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    public event Action<bool> PlayerDied;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Wall) || collision.gameObject.CompareTag(Tags.Platform))
        {
            PlayerDied(true);
        }
    }
}
