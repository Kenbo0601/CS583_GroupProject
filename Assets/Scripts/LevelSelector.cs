using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelection : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Chillcore()
    {
        SceneManager.LoadScene(4);
    }
    public void KissMeAgain()
    {
        SceneManager.LoadScene(5);
    }
    public void RunningInThe90s()
    {
        SceneManager.LoadScene(6);
    }
    public void Sandstorm()
    {
        SceneManager.LoadScene(7);
    }
    public void Caramelldansen()
    {
        SceneManager.LoadScene(8);
    }
    public void DejaVu()
    {
        SceneManager.LoadScene(9);
    }
    public void Kamehameha()
    {
        SceneManager.LoadScene(10);
    }
    public void HarderBetterFasterStronger()
    {
        SceneManager.LoadScene(11);
    }
    public void SpaceBoy()
    {
        SceneManager.LoadScene(12);
    }
    public void NekoNationAnthem()
    {
        SceneManager.LoadScene(13);
    }
    public void OneMoreTime()
    {
        SceneManager.LoadScene(14);
    }
    public void Idol()
    {
        SceneManager.LoadScene(15);
    }
    public void SoundControl()
    {
        SceneManager.LoadScene(16);
    }
}
