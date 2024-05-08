using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public void ButtonClick()
    {
        SoundManager.Instance.ButtonSound();
    }
}
