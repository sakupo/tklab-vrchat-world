using System;
using System.ComponentModel;
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PianoBoard : UdonSharpBehaviour
{
  private TextMeshPro board;
  [SerializeField] private PianoSound ps;
  void Start()
  {
    board = GetComponent<TextMeshPro>();
  }

  public void UpdateBoard(string text)
  {
    board.text = text;
  }
  
  void Update()
  {
    ps.nowPlaying = false;
    if (Input.GetKey("z"))
    {
      ps.Play(0);
    }

    if (Input.GetKey("s"))
    {
      ps.Play(1);
    }

    if (Input.GetKey("x"))
    {
      ps.Play(2);
    }

    if (Input.GetKey("d"))
    {
      ps.Play(3);
    }

    if (Input.GetKey("c"))
    {
      ps.Play(4);
    }

    if (Input.GetKey("v"))
    {
      ps.Play(5);
    }

    if (Input.GetKey("g"))
    {
      ps.Play(6);
    }

    if (Input.GetKey("b"))
    {
      ps.Play(7);
    }

    if (Input.GetKey("h"))
    {
      ps.Play(8);
    }

    if (Input.GetKey("n"))
    {
      ps.Play(9);
    }

    if (Input.GetKey("j"))
    {
      ps.Play(10);
    }

    if (Input.GetKey("m"))
    {
      ps.Play(11);
    }

    if (Input.GetKey(","))
    {
      ps.Play(12);
    }
  }
}