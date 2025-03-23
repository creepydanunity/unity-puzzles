using System.Collections;
using UnityEngine;
using UnityEngine.WSA;

public class Lever : MonoBehaviour
{
    public int leverID;
    public Animator leverStickAnimator;
    public Animator lightAnimator;

    private bool isActivated = false;


    public void Activate()
    {
        if (isActivated) return;

        isActivated = true;

        Debug.Log("Lever " + leverID + " activated");

        if (leverStickAnimator != null)
            leverStickAnimator.SetTrigger("Pull");

        if (lightAnimator != null)
            lightAnimator.SetTrigger("On");

        LeverPuzzleManager.Instance.LeverActivated(leverID);
    }

    public void ResetLever()
    {
        isActivated = false;

        if (leverStickAnimator != null)
            leverStickAnimator.SetTrigger("Reset");

        if (lightAnimator != null)
            lightAnimator.SetTrigger("Off");
    }
}
