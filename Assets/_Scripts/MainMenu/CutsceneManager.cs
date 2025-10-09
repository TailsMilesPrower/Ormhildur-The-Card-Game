using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayAudioAndLoadScene());
        Debug.Log("Playing audio...");
        //playAudio();
        //SceneManager.LoadScene("Lyubo"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayAudioAndLoadScene()
    {
        yield return new WaitForSeconds(0.5f);

        AudioSource source = GetComponent<AudioSource>();

        if (source == null) source = GetComponent<AudioSource>();

        source.clip = clip;
        source.Play();

        yield return new WaitForSeconds(clip.length);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Lyubo");

    }

}
