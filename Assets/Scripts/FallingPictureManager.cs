using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPictureManager : MonoBehaviour {

    public GameObject picturePrefab;

    //public float songLength = 100f;

    public float minPhotoSpawn = 0.1f;
    public float maxPhotoSpawn = 0.2f;

    float currentPhotoSpawnTime;
    float spawnTimer = 0f;

    public Texture[] photoTextures;
    List<Texture> availablePhotoTextures;

	void Start () {
        availablePhotoTextures = new List<Texture>(photoTextures);
        currentPhotoSpawnTime = Random.Range(minPhotoSpawn, maxPhotoSpawn);
	}
	
	void Update () {
        if (availablePhotoTextures.Count > 0)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > currentPhotoSpawnTime)
            {
                currentPhotoSpawnTime = Random.Range(minPhotoSpawn, maxPhotoSpawn);
                spawnTimer = 0f;
                SpawnPhoto();
            }
        } else {
            availablePhotoTextures = new List<Texture>(photoTextures);
        }
	}

    void SpawnPhoto() {
		Vector3 spawnPos = transform.position + transform.forward * Random.Range (-2.5f, 2.5f);
        int index = Random.Range(0, availablePhotoTextures.Count);
        Texture texture = availablePhotoTextures[index];
        availablePhotoTextures.RemoveAt(index);

        GameObject photo = Instantiate(picturePrefab, spawnPos, picturePrefab.transform.rotation);
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));
        photo.transform.Find("Photo").GetComponent<Renderer>().material.mainTexture = texture;
    }
}
