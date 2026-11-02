using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class IntroVideo : MonoBehaviour
{
    public string nextScene = "SampleScene";
    public float maxTime = 5f; // load the game after this many seconds no matter what

    float timer;
    bool loading;

    void Start()
    {
        var vp = GetComponent<VideoPlayer>();
        if (vp != null)
            vp.loopPointReached += _ => Load();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime) Load();

        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
            Load();
    }

    void Load()
    {
        if (loading) return;
        loading = true;
        SceneManager.LoadScene(nextScene);
    }
}