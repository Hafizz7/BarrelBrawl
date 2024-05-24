using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject ladder;
    public GameObject villain;
    private bool isVillainDestroyed = false;

    private void Update()
    {
        // Check if the villain is destroyed
        if (villain == null && !isVillainDestroyed)
        {
            // Villain is destroyed, set the ladder tag
            ladder.layer = 7;
            isVillainDestroyed = true;
        }
        else if (villain != null && isVillainDestroyed)
        {
            // Villain is not destroyed, remove the ladder tag
            ladder.layer = 0;
            isVillainDestroyed = false;
        }
    }
}