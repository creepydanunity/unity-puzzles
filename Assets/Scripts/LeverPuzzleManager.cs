using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzleManager : MonoBehaviour
{
    public static LeverPuzzleManager Instance;

    public List<int> correctOrder = new List<int> { 1, 2, 3 };
    private List<int> playerOrder = new List<int>();

    public Animator doorAnimator;

    public int timeBeforeReset;

    private Lever[] levers;

    private bool isTimerUp = false;

    private void Awake()
    {
        Instance = this;
    }

    [System.Obsolete]
    private void Start()
    {
        levers = FindObjectsOfType<Lever>();
    }

    public void LeverActivated(int id)
    {
        playerOrder.Add(id);

        for (int i = 0; i < playerOrder.Count; i++)
        {
            if (playerOrder[i] != correctOrder[i] && i > 0)
            {
                isTimerUp = false;
                Debug.Log("Wrong order");
                playerOrder.Clear();

                foreach (Lever lever in levers)
                {
                    lever.ResetLever();
                }
                return;
            }
        }

        if (playerOrder.Count == correctOrder.Count)
        {
            Debug.Log("Correct order");
            doorAnimator?.SetTrigger("Open");
        }
        else
        {
            if (!isTimerUp)
            {
                isTimerUp = true;
                Debug.Log("Timer started: " + timeBeforeReset + " sec until reset");
                StartCoroutine(ResetAfterDelay(timeBeforeReset));
            }
        }
    }

    IEnumerator ResetAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay * 1.0f);
        for (int i = 0; i < levers.Length; i++)
        {
            if (playerOrder.Contains(levers[i].leverID))
            {
                Debug.Log("Resetting lever: " + levers[i].leverID);
                levers[i].ResetLever();
            }
        }
        playerOrder.Clear();
        isTimerUp = false;
    }
}
