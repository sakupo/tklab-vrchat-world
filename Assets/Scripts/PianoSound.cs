using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PianoSound : UdonSharpBehaviour
{
  const float PI = Mathf.PI;

  public float gain = 1.5f;
  private float increment;
  private float sampling_frequency = 48000;
  private float time;
  private const int playerStateNone = 1200; 
  private volatile int playState = playerStateNone;
  public volatile bool nowPlaying = false;
  private float fadeScale;
  private readonly float semiTone = Mathf.Pow(2 ,1f/12f);
  [SerializeField] AudioSource[] audioSource;
  [SerializeField] AudioClip audioClip;

  private int nextAudioSOurceIndex = 0;
  /*
  void SineWave(float[] data, int channels, float frequency)
  {
    increment = frequency * 2 * PI / sampling_frequency;
    for (var i = 0; i < data.Length; i = i + channels)
    {
      time = time + increment;
      data[i] = gain * Mathf.Sin(time) * fadeScale;

      if (nowPlaying)
      {
        fadeScale *= 1.5f;
        if (fadeScale > 1.0f) fadeScale = 1.0f;
      }
      else
      {
        fadeScale -= .025f;
        if (fadeScale < 0.001f)
        {
          fadeScale = 0.0f;
          playState = playerStateNone;
        }
      }

      if (channels == 2)
        data[i + 1] = data[i];
      if (time > 2 * Mathf.PI)
        time = 0;
    }
  }
  
  void OnAudioFilterRead(float[] data, int channels)
  {
    if (!nowPlaying) return;
    float scale = 1;
    switch (playState)
    {
      case 0:
        SineWave(data, channels, 261.6255653005985f * scale);
        break;
      case 1:
        SineWave(data, channels, 277.18263097687196f * scale);
        break;
      case 2:
        SineWave(data, channels, 293.66476791740746f * scale);
        break;
      case 3:
        SineWave(data, channels, 311.1269837220808f * scale);
        break;
      case 4:
        SineWave(data, channels, 329.62755691286986f * scale);
        break;
      case 5:
        SineWave(data, channels, 349.2282314330038f * scale);
        break;
      case 6:
        SineWave(data, channels, 369.99442271163434f * scale);
        break;
      case 7:
        SineWave(data, channels, 391.99543598174927f * scale);
        break;
      case 8:
        SineWave(data, channels, 415.3046975799451f * scale);
        break;
      case 9:
        SineWave(data, channels, 440.0f * scale);
        break;
      case 10:
        SineWave(data, channels, 466.1637615180899f * scale);
        break;
      case 11:
        SineWave(data, channels, 493.8833012561241f * scale);
        break;
      case 12:
        SineWave(data, channels, 523.2511306011974f * scale);
        break;
    }
  }
  
  // UdonSharp doesn't support OnAudioFilterRead yet, so we expose it manually
  private float[] onAudioFilterReadData;
  private int onAudioFilterReadChannels;
  public void _onAudioFilterRead() {
    OnAudioFilterRead(onAudioFilterReadData, onAudioFilterReadChannels);
  }
  */

  public void Play(int playState)
  {
    if (this.playState == playerStateNone)
    {
      fadeScale = 0.1f;
      time = 0.0f;
    }

    PlaySound(playState);

    this.playState = playState;
    nowPlaying = true;
  }

  void PlaySound(int keyNum)
  {
    for (int i = 0; i < audioSource.Length; i++)
    {
      int id = (nextAudioSOurceIndex + i) % audioSource.Length;
      if (! audioSource[id].isPlaying)
      {
        audioSource[id].pitch = Mathf.Pow(semiTone, keyNum);
        audioSource[id].PlayOneShot(audioClip);
        nextAudioSOurceIndex = (id + 1) % audioSource.Length;
        break;
      } 
    }
  }

  /*
  void OnGUI()
  {
    int x = 10;
    const int dist = 50;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ド"))
    {
      Play(0);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ド#"))
    {
      Play(1);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "レ"))
    {
      Play(2);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "レ#"))
    {
      Play(3);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ミ"))
    {
      Play(4);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ﾌｧ"))
    {
      Play(5);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ﾌｧ#"))
    {
      Play(6);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ソ"))
    {
      Play(7);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ソ#"))
    {
      Play(8);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ラ"))
    {
      Play(9);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ラ#"))
    {
      Play(10);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "シ"))
    {
      Play(11);
    }

    x += dist;
    if (GUI.RepeatButton(new Rect(x, 10, 40, 30), "ド"))
    {
      Play(12);
    }
  }
  */
}