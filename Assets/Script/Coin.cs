using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public AudioClip getSound;
   
    public void PlayGetSoundAndDestroy()
    {
        AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
   // audioSource.PlayOneShot(CoinSound);
              //  その後、オブジェクトを破棄する
             //   Destroy(collider.gameObject);
}
