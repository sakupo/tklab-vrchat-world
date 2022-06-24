
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ElevatorCallButton : UdonSharpBehaviour
{
    [SerializeField] private int floor;
    [SerializeField] private GameObject light;
    [SerializeField] private ElevatorController evCtrl;
    void Start()
    {
    }

    public void OnTriggerExit(Collider other)
    {
        evCtrl.CallElevator(floor);
    }
  
    public void SetLight(bool isActive)
    {
        light.SetActive(isActive);
    }
}
