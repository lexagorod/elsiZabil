using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    Drive ds;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        ds = target.GetComponent<Drive>();
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

    void Pursue()
    {
        Vector3 targetDir = this.transform.position - target.transform.position ;

        float relativeHeading = Vector3.Angle(this.transform.TransformVector(target.transform.forward), this.transform.forward );

        float toTarget = Vector3.Angle(this.transform.TransformVector(targetDir), this.transform.forward);

        if ((toTarget > 90 && relativeHeading < 20) || ds.currentSpeed > 0.01f)
        {
            Flee(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude / (agent.speed + ds.currentSpeed);
        Flee(target.transform.position + target.transform.forward * lookAhead);
    }

    // Update is called once per frame
    void Update()
    {
        Pursue();
    }
}
