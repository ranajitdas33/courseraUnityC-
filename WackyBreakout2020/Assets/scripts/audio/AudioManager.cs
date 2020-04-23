using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Freeze, 
            Resources.Load<AudioClip>("freeze_sfx"));
        audioClips.Add(AudioClipName.SpeedUp,
            Resources.Load<AudioClip>("speedUp_sfx"));
        audioClips.Add(AudioClipName.BlockHit,
            Resources.Load<AudioClip>("ballHit_sfx"));
        audioClips.Add(AudioClipName.PaddleHit,
            Resources.Load<AudioClip>("ballHitOnPaddle_sfx"));
        audioClips.Add(AudioClipName.MenuButtonClick,
             Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.GameOver,
             Resources.Load<AudioClip>("gameover_sfx"));
        audioClips.Add(AudioClipName.Win,
            Resources.Load<AudioClip>("win_sfx"));
        audioClips.Add(AudioClipName.BallFalling,
            Resources.Load<AudioClip>("ballFallDown_sfx"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
