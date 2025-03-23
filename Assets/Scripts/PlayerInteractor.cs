using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float interactDistance = 4f;
    public KeyCode interactKey = KeyCode.E;
    public LayerMask interactLayer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if (Input.GetKeyDown(interactKey))
            {
                Lever lever = hit.collider.GetComponent<Lever>();
                if (lever != null)
                {
                    lever.Activate();
                }
            }
        }
    }
}
