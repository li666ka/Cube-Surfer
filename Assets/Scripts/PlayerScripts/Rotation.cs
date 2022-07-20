using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool _isRotating = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.ColliderRotate))
        {
            other.gameObject.SetActive(false);
            if (!_isRotating)
            {
                _isRotating = true;
                StartCoroutine(StartRotation());
            }
        }
    }

    private IEnumerator StartRotation()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForFixedUpdate();
            transform.Rotate(Vector3.up, 3f);
        }
        _isRotating = false;
    }
}
