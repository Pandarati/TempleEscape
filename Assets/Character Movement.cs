public bool SetDestination(Vector3 target);
using UnityEngine;
using System.Collections;
 
public class NavmeshMovement: MonoBehaviour {
	public GameObject targets;
    public NavMeshAgent mNavMeshAgent;
    public    int i ;
    float dist;
 
    void Start(){
		mNavMeshAgent = GetComponent<NavMeshAgent>();
        mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position; 
    }
     
    //Update is called once per frame
    void Update(){
		if(mNavMeshAgent.enabled){
			dist = Vector3.Distance(targets.transform.GetChild(i).transform.position,transform.position);
            mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position;
         
            if (dist < 2){
				i++; //change next target
				if (i < targets.transform.childCount ){
					mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position; //go to next target by  setting it as the new destination
                }
                 
                 //check if at end of cycle, then reset to beginning of cycle
                if (i == targets.transform.childCount ){
					Debug.Log("NAVIGATION FINISHED. RESET.");
                    i = 0;
                    mNavMeshAgent.destination = targets.transform.GetChild(i).transform.position;
                }
            }
        }
     }
             
 }