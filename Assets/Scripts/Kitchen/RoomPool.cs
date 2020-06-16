using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPool : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private GameObject currentRoomInstance, NewRoomInstance;

    private bool isInstantiated;
    public float camOffset, roomWidth;

    private void Start()
    {
        currentRoomInstance = InstantiateRoom(roomPrefab);
        currentRoomInstance.name = "Kitchen";
        currentRoomInstance.transform.localPosition = Vector3.zero;
        camOffset = 24;
        roomWidth = 71.59f;
        Camera.main.GetComponent<Animator>().SetTrigger("Move");

        if (AudioManager.audioManager != null)
        {
            AudioManager.audioManager.StopMusic();
            AudioManager.audioManager.musicSource.clip = AudioManager.audioManager.musicClip.gamePlayMusic;
            AudioManager.audioManager.musicSource.loop = true;
            AudioManager.audioManager.musicSource.volume = 0.5f;
            AudioManager.audioManager.musicSource.Play();
        }
    }

    private void Update()
    {
        if (!isInstantiated && Mathf.Abs(Camera.main.transform.position.x - currentRoomInstance.transform.position.x) >= camOffset)
        {
            NewRoomInstance = InstantiateRoom(currentRoomInstance);

            if (GetCameraDirectionWithRoom() == 1)
                NewRoomInstance.transform.position = new Vector3(currentRoomInstance.transform.position.x + roomWidth, 0, 0);
            else
                NewRoomInstance.transform.position = new Vector3(currentRoomInstance.transform.position.x - roomWidth, 0, 0);

            NewRoomInstance.name = "Kitchen";
            isInstantiated = true;
        }

        if (isInstantiated)
        {
            if (Mathf.Abs(Camera.main.transform.position.x - currentRoomInstance.transform.position.x) >= camOffset + 25f)
            {
                DestroyRoom(currentRoomInstance);
                currentRoomInstance = NewRoomInstance;
                isInstantiated = false;
            }
            else if (Mathf.Abs(Camera.main.transform.position.x - NewRoomInstance.transform.position.x) >= camOffset + 25f)
            {
                DestroyRoom(NewRoomInstance);
                isInstantiated = false;
            }
        }
    }

    private float GetCameraDirectionWithRoom()
    {
        return Mathf.Sign((Camera.main.transform.position - currentRoomInstance.transform.position).normalized.x);
    }

    private GameObject InstantiateRoom(GameObject room)
    {
        return Instantiate(room, this.transform);
    }

    private void DestroyRoom(GameObject room)
    {
        Destroy(room);
    }
}