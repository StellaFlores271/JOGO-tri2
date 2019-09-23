using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_oo1 : MonoBehaviour
{

    bool wait = false;

    void OnTriggerEnter2D(Collider2D other){
       
        if (other.gameObject.CompareTag("Coin"))
        {
            SFXManager.instance.ShowCoinParticles(other.gameObject);
            AudioManager.instance.PlaySoundCoinPickup(other.gameObject);
            Destroy(other.gameObject);
            Level02Manager.instance.IncrementCoinCount();
        }
        else if (other.gameObject.CompareTag("Gift"))
        {
            StopMusicAndTape();
            Destroy(other.gameObject);
            AudioManager.instance.PlaySoundLevelComplete(gameObject);
            Destroy(gameObject);
            Level02Manager.instance.ShowLevelComplete();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("forbidden")){
            KillPlayer();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("enemies")){
            HurtPlayer();
        }
    }

    void StopMusicAndTape()
    {
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

    void HurtPlayer() {
        if (!wait) {
            Level02Manager.instance.DecrementLifeCount();
            ChangeAlpha(0.5f);
            if (Level02Manager.instance.GetLifeCount() == 0) {
                KillPlayer();
            }
            else {                
                wait = true;
                StartCoroutine(DisableWait(2.0f));
            }
        }
    }

    private IEnumerator DisableWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ChangeAlpha(1f);        
        wait = false;
    }

    private void ChangeAlpha(float alpha) {
        Debug.Log("Dec " + alpha);
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
