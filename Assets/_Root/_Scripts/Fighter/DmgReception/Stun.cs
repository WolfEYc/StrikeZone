using System.Collections;
using UnityEngine;

namespace Strikezone
{
    public class Stun : MonoBehaviour
    {
        float _endtime;
        WaitUntil _waitUntilTimeUp;
        FighterControls _fighterControls;

        void Awake()
        {
            _waitUntilTimeUp = new(TimeUp);
            _fighterControls = GetComponent<FighterControls>();
        }

        bool TimeUp()
        {
            return _endtime < Time.time;
        }

        public void PerformStun(float duration)
        {
            _endtime = Time.time + duration;
            if(_fighterControls.Stunned) return;
            StartCoroutine(StunRoutine());
        }

        IEnumerator StunRoutine()
        {
            _fighterControls.SetStunned(true);
            yield return _waitUntilTimeUp;
            _fighterControls.SetStunned(false);
        }
    }
}
