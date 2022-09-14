using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

public class TestInput : MonoBehaviour
{
    public MoveMechanic moveMech;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            this.moveMech.Move(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            this.moveMech.Move(Vector2.right);
        }
    }
}
