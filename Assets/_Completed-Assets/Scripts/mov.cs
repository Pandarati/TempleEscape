
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class mov: MonoBehaviour {
	// public GameObject targets;
  //   public UnityEngine.AI.NavMeshAgent mNavMeshAgent;
  //   public    int i ;
  //   float dist;
	// 	public bool SetDestination(Vector3 target);
	//
  //   void Start(){
	// 	mNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
  //       mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position;
  //   }
	//
  //   //Update is called once per frame
  //   void Update(){
	// 	if(mNavMeshAgent.enabled){
	// 		dist = Vector3.Distance(targets.transform.GetChild(i).transform.position,transform.position);
  //           mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position;
	//
  //           if (dist < 2){
	// 			i++; //change next target
	// 			if (i < targets.transform.childCount ){
	// 				mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position; //go to next target by  setting it as the new destination
  //               }
	//
  //                //check if at end of cycle, then reset to beginning of cycle
  //               if (i == targets.transform.childCount ){
	// 				Debug.Log("NAVIGATION FINISHED. RESET.");
  //                   i = 0;
  //                   mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position;
  //               }
  //           }
  //       }
  //    }
	public Transform target;
	Vector3 destination;
	NavMeshAgent agent;

	void Start()
	{
			// Cache agent component and destination
			agent = GetComponent<NavMeshAgent>();
			destination = agent.destination;
	}

	void Update()
	{
			// Update destination if the target moves one unit
			// if (Vector3.Distance(destination, target.position) > 1.0f)
			// {
			// 		destination = target.position;
			// 		agent.destination = destination;
			// }

			if (Input.GetKeyDown(KeyCode.Return))
        {
					destination = target.position;
					agent.destination = destination;
        }
	}

 }
