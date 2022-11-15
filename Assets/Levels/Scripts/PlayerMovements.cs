using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public interface IMovement 
{
    Vector2 MoveHorizontal();
    Vector2 JumpVertical(float Forces);
}

class MovementHandler : IMovement
{
    float Velocity_Speed;
    string Typed;
    private GameObject Comp;
    private Rigidbody2D This_Body;
    

    public MovementHandler(float Velocity_Speed,GameObject Componets,Rigidbody2D Object_Body, string Typed)
    {
        this.Velocity_Speed = Velocity_Speed;
        this.Comp = Componets;
        this.Typed = Typed;
        this.This_Body = Object_Body;
    }

    public Vector2 MoveHorizontal() /////Horizontal Moves
    {
        return new Vector2(Input.GetAxis("Horizontal") * Velocity_Speed,This_Body.velocity.y);
    }

    public Vector2 JumpVertical(float JumpForces) ////Jump 2DVector
    {
        return new Vector2(This_Body.velocity.x, JumpForces);
    }
}


public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D Body;
    public float Velocity;
    public float JumpForces;

    public GameObject Player; ///Player itself
    [SerializeField ] private Transform Position;
    private MovementHandler Movement;
    [SerializeField] private float TimeOnWait = 0;

    public void Awake()
    {
        Position = GetComponent<Transform>();
        Body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate() //Get Input
    {
        TimeOnWait += Time.deltaTime; ///Start Timer

        MovementHandler Movement = new MovementHandler(Velocity,Player,Body,"Normal");

        Body.velocity = Movement.MoveHorizontal();
        if (Input.GetKey(KeyCode.W) && TimeOnWait >= 0.5f)
        {
            
           Body.velocity = Movement.JumpVertical(JumpForces);
           Debug.Log(TimeOnWait);
           TimeOnWait = -1;
           
        }
    }
}

