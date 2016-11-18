using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {


    public static AudioController instance;
    private AudioSource audioSource;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
