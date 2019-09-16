using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("enemies")){
               KillPlayer();
        } 
    }

    void StopMusicAndTape(){
            Camera.main.GetComponentInChildren<AudioSource>().mute = true;
            Level02Manager.instance.SetTapeSpeed(0);
    }

    void KillPlayer() {
        StopMusicAndTape();
        AudioManager.instance.PlaySoundFail(gameObject);
        SFXManager.instance.ShowDieParticles(gameObject);
        Destroy(gameObject);
        Level02Manager.instance.ShowGameOverPanel();
    }

}
