using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMoveScript : MonoBehaviour
{
    /// <summary>
    /// Basic move script for the particle trail effects
    /// </summary>

    [SerializeField] private float speed;
    [SerializeField] private float moveTime; 
    [SerializeField] private float moveTimeMax;
   
    [SerializeField] private Vector3 startPosition;


    [SerializeField] private bool isMoving;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }


    // Start is called before the first frame update
    void Start()
    {
        moveTime = 0f;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsMoving) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            moveTime += Time.deltaTime;
            if (moveTime > moveTimeMax) {
                IsMoving = false;
                moveTime = 0f;
                transform.position = startPosition;
            
            }
        
        }


    }
}
