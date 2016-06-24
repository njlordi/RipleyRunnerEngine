using UnityEngine;
using System.Collections;

public class PickUpSpawner : MonoBehaviour {

	public float laneValue;
	// outsource this variable to static method later?
	public float pickupSpacing;

    #region Object-pooling variables
    public GameObject pickUpPrefab;
    public int poolSize;
    public GameObject[] pickUpArray;
    bool alreadyPopulated;
    #endregion

    void Awake() {
        pickupSpacing = 0.04f;
    }

    void OnEnable () {
        if (!alreadyPopulated) {
            InitializeAndPopulatePool();
            alreadyPopulated = true;
        }

        Random.seed = System.DateTime.Now.Millisecond;
		laneValue = pickupSpacing * Random.Range(-1, 2);
		
		for (int i = 0; i < poolSize; i++) {
			float currentZLocation = 0.45f - (i * 0.1f);
            pickUpArray[i].transform.localPosition = new Vector3(laneValue, 2.0f, currentZLocation);
            pickUpArray[i].SetActive(true);
        }
	}

    void InitializeAndPopulatePool() {
        poolSize = 10;
        pickUpArray = new GameObject[poolSize];
        if (pickUpPrefab != null)
        {
            for (int i = 0; i < poolSize; i++)
            {
                pickUpArray[i] = (GameObject)Instantiate(pickUpPrefab);
                pickUpArray[i].SetActive(false);
                pickUpArray[i].transform.parent = this.transform;
                //pickUpArray[i].transform.position = this.transform.position;
            }
        }
        else
            Debug.Log("No pick-up prefab to pool!");
    }
}
