using UnityEngine;

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;

    [Tooltip("The default volume")]
    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Tooltip("The default pitch")]
    [Range(0.5f, 1.5f)]
    public float pitch = 1.0f;

    [Tooltip("This will define how much variation you want to apply to your volume. 0 will result in no variation, 0.1 will result in the volume being between 0.5 higher or lower than you pitch selected")]
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;

    [Tooltip("This will define how much variation you want to apply to your pitch. 0 will result in no variation, 0.1 will result in the pitch being between 0.5 higher or lower than you pitch selected")]
    [Range(0f, 0.9f)]
    public float randomPitch = 0.1f;

    private AudioSource source;

    public void SetSource( AudioSource _source ) {
        source = _source;
        source.clip = clip;
    }

    public void Play() {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake() {
        if (instance != null) {
            Debug.LogError("Error: More than one audio manager");
        } else {
            instance = this;
        }
    }

    void Start() {
        for (int i = 0; i < sounds.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound( string _name ) {
        for (int i = 0; i < sounds.Length; i++) {
            if (sounds[i].name == _name) {
                sounds[i].Play();
                return;
            }
        }

        // No sound by that name
        Debug.LogError("AudioManager : Sound could not be found in list : " + _name);
    }
}
