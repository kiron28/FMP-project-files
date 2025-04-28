using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public LayerMask Grass;
    public LayerMask WaterAndWalls;

    public event Action Encounter;

    public bool Moving;
    public bool Sprinting;
    private Vector2 Movement;

    public void Update()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            Sprinting = true;
        }

        if (Input.GetButtonUp("Sprint"))
        {
            Sprinting = false;
        }
    }
    public void HandleUpdate()
    {
        if (!Moving)
        {
            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");

            

            if (Movement != Vector2.zero)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    var targetPosition = transform.position;
                    targetPosition.x += Movement.x;
                    targetPosition.y += Movement.y;
                    StartCoroutine(Move(targetPosition));
                }
                else
                {
                    var targetPosition = transform.position;
                    targetPosition.x += Movement.x;
                    targetPosition.y += Movement.y;

                    if (IsWalkable(targetPosition))
                    {
                        StartCoroutine(Move(targetPosition));
                    }
                }
            }
        }       
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        Moving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            if (Sprinting == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, (MovementSpeed * 2) * Time.deltaTime);
                yield return null;
            }            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MovementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        Moving = false;

        EncounterCheck();
    }

    private bool IsWalkable(Vector3 targetPosition)
    {
        if (Physics2D.OverlapCircle(targetPosition, 0.1f, WaterAndWalls) != null)
        {
            return false;
        }
        return true;
    }


    private void EncounterCheck()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, Grass) != null)
        {
            if (UnityEngine.Random.Range(1, 51) <= 5)
            {
                Encounter();
                Debug.Log("Battle start");
            }
        }
    }
}
