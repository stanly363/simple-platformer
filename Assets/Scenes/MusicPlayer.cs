using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; // Finds the number of objects with the music script attached
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject); // Removes objects with the music script attached if there is more than one
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Ensures the object isnt attached to a removable object
        }
    }
    public void VolumeUp()
    {
        AudioListener.volume += 1;
    }
    public void VolumeDown()
    {
        AudioListener.volume -= 1;
    }
}





