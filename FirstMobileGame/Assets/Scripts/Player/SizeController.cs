using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{

    [SerializeField] Vector3 state1;
    [SerializeField] Vector3 state2;
    [SerializeField] float changeStateSpeed;
    Vector3 targetSize;

    private void Start()
    {
        targetSize = state1;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateSize();
    }

    void UpdateSize() => transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, changeStateSpeed*Time.deltaTime);

    public void ChangeToState1() => targetSize = state1;
    public void ChangeToState2() => targetSize = state2;
}
