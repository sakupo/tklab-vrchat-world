using System;
using DG.Tweening;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ElevatorController : UdonSharpBehaviour
{
  public int CurrentFloor { get; private set; }
  private readonly float basePos = 0f;
  [SerializeField] private ElevatorButton button;
  public bool IsMoving { get; private set; }
  private int from, to;
  private float velocity;

  [SerializeField]
  private GameObject box;

  void Start()
  {
    IsMoving = false;
  }

  void Update()
  {
    if (IsMoving)
    {
      var boxPos = new Vector3(0, box.transform.localPosition.y + velocity * Time.deltaTime);
      box.transform.localPosition = boxPos;
      if (to > from && boxPos.y > (to - 1) * 3)
      {
        OnMoveComplete();
      }
      if (to < from && boxPos.y < (to - 1) * 3)
      {
        OnMoveComplete();
      }
    }
  }

  public void MoveElevator()
  {
    if (IsMoving) return;
    if (CurrentFloor == 1)
    {
      from = 1;
      to = 36;
      velocity = 10f; 
    }
    else
    {
      from = 36;
      to = 1;
      velocity = -10f;
    }
    button.SetLight(true);
    IsMoving = true;
  }

  public void CallElevator(int floor)
  {
    if (IsMoving) return;
    if (CurrentFloor == floor) return;
    MoveElevator();
  } 

  public void OnMoveComplete()
  {
    box.transform.localPosition = new Vector3(0, (to - 1) * 3 + basePos);
    IsMoving = false;
    button.SetLight(false);
    CurrentFloor = to;
  }
}