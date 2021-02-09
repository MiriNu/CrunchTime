using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour
{
    GameObject[] activatables;
    float minTime = 4f;
    float maxTime = 7f;
    int randomActivatable;
    // Start is called before the first frame update
    void Start()
    {
        activatables = GameObject.FindGameObjectsWithTag("Activatable");
        Invoke("RequestActivation", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShutDown(GameObject activatable)
    {
        activatable.GetComponent<SpriteRenderer>();
    }

    void AskActivation(GameObject activatable)
    {
        activatable.GetComponent<SpriteRenderer>();
    }

    void RequestActivation()
    {
        float randomTime = Random.Range(minTime, maxTime);

        // Choose building/train/drone
        randomActivatable = Random.Range(0, activatables.Length-1);
        // Prepare for activation request
        ShutDown(activatables[randomActivatable]);
        AskActivation(activatables[randomActivatable]);
        Invoke("RequestActivation", randomTime);

    }
}
