using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavManager : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        var path = agent.path;
        // color depends on status
        Color c = Color.white;
        switch (path.status)
        {
            case UnityEngine.AI.NavMeshPathStatus.PathComplete: c = Color.white; break;
            case UnityEngine.AI.NavMeshPathStatus.PathInvalid: c = Color.red; break;
            case UnityEngine.AI.NavMeshPathStatus.PathPartial: c = Color.yellow; break;
        }
        // draw the path
        for (int i = 1; i < path.corners.Length; ++i)
            Debug.DrawLine(path.corners[i - 1], path.corners[i], c);
    }
}
