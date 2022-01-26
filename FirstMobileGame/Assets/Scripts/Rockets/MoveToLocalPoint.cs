using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocalPoint : MonoBehaviour
{
	[SerializeField] Vector3 pointToMove;
	[SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, pointToMove, speed*Time.deltaTime);
    }
}
