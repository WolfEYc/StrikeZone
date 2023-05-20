using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Strikezone
{
    public class AudioSlider : MonoBehaviour
    {
        AudioMixer Mixer => AudioManager.Instance.Mixer;
        [SerializeField] Slider slider;
        [SerializeField] string parameterName;
        [SerializeField] AudioClip playOnChange;

        //it just gotta be in start 2 work -_-
        void Start()
        {
            Parameter = PlayerPrefs.GetFloat(parameterName);
            slider.value = Parameter;
        }

        public void OnValueChanged(float vol)
        {
            Parameter = vol;
            if (playOnChange != null)
            {
                AudioManager.Instance.PlaySound(playOnChange);
            }
        }

        protected float Parameter
        {
            get
            {
                Mixer.GetFloat(parameterName, out var parameter);
                return parameter;
            }
        
            set
            {
                Mixer.SetFloat(parameterName, value);
                PlayerPrefs.SetFloat(parameterName, value);
            }
        }
    }
}
