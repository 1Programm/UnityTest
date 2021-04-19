using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float movementSpeed = 1;
    [SerializeField] float minDistanceToGoal = 1;
    //[SerializeField] Vector3 goal;

    private Vector3 goal;
    private Vector3 vel;
    private bool reachedGoal;


    // Update is called once per frame
    void Update() {
        if (!reachedGoal) {
            if (vel != null) {
                gameObject.transform.position += vel * Time.deltaTime;
            }

            if (goal != null) {
                float goalDist = Vector3.Distance(transform.position, goal);
                if (goalDist <= minDistanceToGoal) {
                    reachedGoal = true;
                }
            }
        }

        if (Input.GetMouseButton(0)) {                                  //Later maybe change it so it doesnt calculates everything for every update
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            string[] layerNames = {"Player"};
            int layerMask = LayerMask.GetMask(layerNames);
            layerMask = ~layerMask;


            if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask)) {
                Transform objectHit = hit.transform;
                
                goal = hit.point;

                vel = goal - transform.position;
                vel.Normalize();
                vel.x *= movementSpeed;
                vel.y = 0;
                vel.z *= movementSpeed;

                reachedGoal = false;
            }
        }
    }
}