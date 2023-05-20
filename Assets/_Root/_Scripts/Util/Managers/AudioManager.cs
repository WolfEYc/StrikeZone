using UnityEngine;
using UnityEngine.Audio;

namespace Strikezone
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioMixer mixer;
        public AudioMixer Mixer => mixer;

        [SerializeField] AudioSource music, sounds;

        Transform _soundsTransform;
        Vector3 _defaultSoundpos;

        protected override void Awake()
        {
            base.Awake();
            _soundsTransform = sounds.transform;
            _defaultSoundpos = _soundsTransform.position;
        }

        public void PlayMusic(AudioClip clip)
        {
            music.clip = clip;
            music.Play();
        }

        public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1f)
        {
            _soundsTransform.position = pos;
            PlayOneShot(clip, vol);
        }

        public void PlaySound(AudioClip clip, float vol = 1f)
        {
            _soundsTransform.position = _defaultSoundpos;
            PlayOneShot(clip, vol);
        }
    
        void PlayOneShot(AudioClip clip, float vol)
        {
            sounds.PlayOneShot(clip, vol);
        }
    }
}
