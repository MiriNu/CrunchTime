using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFace : MonoBehaviour
{
    public GameObject go;
    private PlayerMovement pm;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        pm = go.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.runSpeed <= 12 )
        {
            animator.SetFloat("speed", pm.runSpeed);
        }
    }
}
