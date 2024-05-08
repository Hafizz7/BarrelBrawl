using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevel : MonoBehaviour
{
    public AudioSource SoundEffect;
    public AudioClip SpaceSound;

    // Update is called once per frame
    void Update()
    {
        // Jika tombol spasi ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Memainkan suara
            SoundEffect.PlayOneShot(SpaceSound);
        }
    }
}
