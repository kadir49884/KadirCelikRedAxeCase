using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
	[SerializeField] private Camera orthoCamera;

    public Camera OrthoCamera { get => orthoCamera; set => orthoCamera = value; }
}