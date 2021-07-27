using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;

public class SwitchToggle : MonoBehaviour {
   [SerializeField] RectTransform uiHandleRectTransform ;
   [SerializeField] Color backgroundActiveColor ;
   [SerializeField] Color handleActiveColor ;

   Image backgroundImage, handleImage ;

   Color backgroundDefaultColor, handleDefaultColor ;

   Toggle toggle ;

   Vector2 handlePosition ;

    public enum Type
    {
        Sound,
        Vibration
    }

    public Type type;

   void Awake ( ) {
      toggle = GetComponent <Toggle> ( ) ;

        if(type == Type.Sound)
        {
            if (PlayerPrefs.GetInt("MutePreference", 1) == 0)
            {
                toggle.isOn = false;
            }
            else
            {
                toggle.isOn = true;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Vibration", 1) == 0)
            {
                toggle.isOn = false;
            }
            else
            {
                toggle.isOn = true;
            }
        }


        handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;

      backgroundDefaultColor = backgroundImage.color ;
      handleDefaultColor = handleImage.color ;

      if (toggle.isOn)
         OnSwitch (true);
   }

   void OnSwitch (bool on) {
      uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack) ;

      backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f) ;

      handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f) ;

   }

    public void ToggleMute()
    {
        SoundManager.Instance.ToggleMute();
        SoundManager.Instance.ToggleMusic();
        if (PlayerPrefs.GetInt("MutePreference", 1) == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        OnSwitch(toggle.isOn);
            
    }

    public void ToggleVibration()
    {
        GameManager.instance.ToggleVibrate();
        if (PlayerPrefs.GetInt("Vibration", 1) == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        OnSwitch(toggle.isOn);
    }
}
