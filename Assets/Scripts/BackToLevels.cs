using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSongs : MonoBehaviour
{
    public void BackToSong()
    {
        SceneManager.LoadScene(3);
    }
}
