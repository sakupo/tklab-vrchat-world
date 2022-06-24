using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ElevatorButton : UdonSharpBehaviour

{
  [SerializeField] private GameObject light;
  [SerializeField] private ElevatorController evCtrl;
  void Start()
  {
  }

  public void OnTriggerExit(Collider other)
  {
    evCtrl.MoveElevator();
  }
  
  public void SetLight(bool isActive)
  {
    light.SetActive(isActive);
  }
}