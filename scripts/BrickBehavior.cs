using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private bool isClone = false;
    public AudioClip coinSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = coinSound;
        audioSource.playOnAwake = false;
    }


    public void SetIsClone(bool value)
    {
        isClone = value;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor") && isClone)
        {
            PlayCoinSound();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isClone && gameObject.name.Contains("(Clone)"))
        {
            string letter = gameObject.name.Replace("(Clone)", string.Empty);
            if (Input.GetKey(letter))
            {
                PlayCoinSound();
                Destroy(gameObject);
            }
        }
    }

    void PlayCoinSound()
    {
        if (coinSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }
}
