using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    private SpriteRenderer stateSprite;
    private enum ActivatableStates { ShutDown, Active, Glow };
    private ActivatableStates state;
    public Sprite spriteShutDown;
    public Sprite spriteActive;
    public Sprite spriteGlow;
    public Sprite signGlow;
    public Sprite signOff;
    public Sprite signOn;

    private int childrenCount;
    private GameObject child;
    private float timeRemaining;
    public float timerLength = 3f;

    public ActivationManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = GameObject.Find("ActivationManager").GetComponent<ActivationManager>();
        stateSprite = gameObject.GetComponent<SpriteRenderer>();
        childrenCount = gameObject.transform.childCount;
        ShutDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && isGlow())
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining == 0 && isGlow())
        {
            ShutDown();
            if (AM.strikes > 0)
            {
                AM.strikes--;
            }
           
        }
    }

    public bool isGlow()
    {
        if (state == ActivatableStates.Glow)
            return true;
        return false;
    }

    public void ShutDown()
    {
        state = ActivatableStates.ShutDown;
        stateSprite.sprite = spriteShutDown;
        for (int i = 0; i < childrenCount; i++)
        {
            Debug.Log(childrenCount);
            Debug.Log(i);
            child = gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<SpriteRenderer>().sprite = signOff;
        }
    }

    public void Glow(float glowTimer)
    {
        state = ActivatableStates.Glow;
        stateSprite.sprite = spriteGlow;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<SpriteRenderer>().sprite = signGlow;
        }
        timerLength =  glowTimer;
        timeRemaining = glowTimer;
    }

    public void Activate()
    {
        state = ActivatableStates.Active;
        stateSprite.sprite = spriteActive;
        for (int i = 0; i < childrenCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            child.GetComponent<SpriteRenderer>().sprite = signOn;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            switch (state)
            {
                case ActivatableStates.ShutDown:
                    Activate();
                    break;
                case ActivatableStates.Glow:
                    Activate();
                    AM.points++;
                    if (AM.points % 5 == 0)
                    {
                        AM.minTime /= 1.5f;
                        AM.maxTime /= 1.5f;
                    }
                    break;
                case ActivatableStates.Active:

                    break;           
                default:

                    break;
            }
        }
    }

    public void CheckState()
    {
        switch (state)
        {
            case ActivatableStates.ShutDown:

                break;
            case ActivatableStates.Glow:

                break;
            case ActivatableStates.Active:

                break;
            default:

                break;
        }
    }
}
