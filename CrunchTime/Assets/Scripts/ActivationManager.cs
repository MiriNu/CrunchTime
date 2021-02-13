using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour
{
    GameObject[] activatables;
    public float minTime = 4f;
    public float maxTime = 7f;
    int randomActivatable;
    float glowTimer = 2f;
    public int strikes = 5;
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        activatables = GameObject.FindGameObjectsWithTag("Activatable");
        Invoke("RequestActivation", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (strikes == 0 )
        {
            // Game over
        }

   
    }

    void RequestActivation()
    {
        float randomTime = Random.Range(minTime, maxTime);

        // Choose building/train/drone
        randomActivatable = Random.Range(0, activatables.Length-1);
        // Prepare for activation request
        Activatable activatable = activatables[randomActivatable].GetComponent<Activatable>();
        if (!activatable.isGlow())
        {
            activatable.Glow(glowTimer);
        }

        Invoke("RequestActivation", randomTime);

    }
}
