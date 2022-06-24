using System;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PianoKey : UdonSharpBehaviour
{
  [SerializeField] private PianoBoard board;
  private MeshRenderer meshRenderer;
  private bool init = false;
  private int keyNum;
  private bool isBlack;
  [SerializeField] private Material whiteKeyMat;
  [SerializeField] private Material blackKeyMat;
  [SerializeField] private Material greenKeyMat;
  [SerializeField] private PianoSound sound;

  void Start()
  {
    keyNum = Int32.Parse(name);
    meshRenderer = gameObject.GetComponent<MeshRenderer>();
    isBlack = IsBlackKey(keyNum);
  }

  public void OnTriggerEnter(Collider other)
  {
    if (!init)
    {
      // ワールド生成時は無視
      init = true;
      return;
    }
    board.UpdateBoard(name);
    sound.Play(keyNum);
    meshRenderer.material = greenKeyMat;
  }

  public void OnTriggerExit(Collider other)
  {
    meshRenderer.material = (isBlack) ? blackKeyMat : whiteKeyMat;
  }

  public override void OnPlayerTriggerEnter(VRCPlayerApi player)
  {
    board.UpdateBoard(name);
    meshRenderer.material = greenKeyMat;
  }

  public bool IsBlackKey(int keyNum)
  {
    switch ((keyNum + 1200) % 12)
    {
      case 0:
      case 2:
      case 4:
      case 5:
      case 7:
      case 9:
      case 11:
        // is white
        return false;
      default:
        // is black
        return true;
    }
  }
}