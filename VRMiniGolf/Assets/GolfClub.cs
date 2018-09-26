using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClub : MonoBehaviour {

    public Hand Parent;
    public AudioSource Audio;

    private bool _isWaitingForNextActualHit = false;

    public IEnumerator NextHitCoolDown()
    {
        _isWaitingForNextActualHit = true;
        yield return new WaitForSeconds(.1f);
        _isWaitingForNextActualHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Parent)
        {
            Parent.HitWhileHolding(collision.relativeVelocity);
        }

        if(collision.gameObject.GetComponent<Ball>() && !_isWaitingForNextActualHit)
        {
            GameManager.Instance.NumHits++;
            Audio.Play(0);
            StartCoroutine(NextHitCoolDown());
        }
    }
}
