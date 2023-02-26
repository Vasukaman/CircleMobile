using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] float minRotationToStart = 10;
    [SerializeField] Spawner spawner;
    [SerializeField] RotationController rotationController;
     IRotationInput rotationInput;
    // Update is called once per frame

    private void Start()
    {
        rotationInput = rotationController.gameObject.GetComponent<IRotationInput>();

        if (rotationInput == null)
         Debug.Log("No Rotation Input Found");

        StartCoroutine(StartGame());
    }
    void Update()
    {
        if ((Input.touchCount > 0) || (Input.GetKey(KeyCode.A)))
        {
            StartSpawner();

        }
    }

    void StartSpawner()
    {
        spawner.StartSpawner();
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
    
    IEnumerator StartGame()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
        float baseRotation = rotationInput.GetRotation();
        yield return new WaitForSecondsRealtime(0.3f);
  


        while (Mathf.Abs(rotationInput.GetRotation() - baseRotation)<minRotationToStart)
        {
            yield return new WaitForEndOfFrame();
      
        }
        StartSpawner();
    }
}
