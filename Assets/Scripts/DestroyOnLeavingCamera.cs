using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLeavingCamera : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
