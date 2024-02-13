using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownTreeStates : MonoBehaviour
{
    public float treeHealth;
    public float maxTreeHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxTreeHealth = treeHealth;
    }
}
