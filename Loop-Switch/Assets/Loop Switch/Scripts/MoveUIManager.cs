using UnityEngine;
using DG.Tweening;

public class MoveUIManager : MonoBehaviour
{
    public static MoveUIManager instance;

    public MoveUI[] moveUI;

    public enum StartOrEnd
    {
        start,
        end
    }

    private void Awake() {
        instance = this;
    }
        


    public void MoveX(string _name , RectTransform _gameObject , StartOrEnd startOrEnd)
    {
        if(startOrEnd == StartOrEnd.end)
        {
            for(int i = 0 ; i < moveUI.Length ; i++)
            {
                if(_name == moveUI[i].name)
                {
                    _gameObject.DOAnchorPosX(moveUI[i].end,moveUI[i].duration).SetEase(moveUI[i].easeType);
                }
                
            }
        }

        else if(startOrEnd == StartOrEnd.start)
        {
            for(int i = 0 ; i < moveUI.Length ; i++)
            {
                if(_name == moveUI[i].name)
                {
                    _gameObject.DOAnchorPosX(moveUI[i].start,moveUI[i].duration).SetEase(moveUI[i].easeType);
                }
                
            }
        }

        else
        {
            Debug.LogError("Name Not Found !");
        }
        
    }

    public void MoveY(string _name , RectTransform _gameObject , StartOrEnd startOrEnd)
    {
        if(startOrEnd == StartOrEnd.end)
        {
            for(int i = 0 ; i < moveUI.Length ; i++)
            {
                if(_name == moveUI[i].name)
                {
                    _gameObject.DOAnchorPosY(moveUI[i].end,moveUI[i].duration).SetEase(moveUI[i].easeType);
                }
                
            }
        }

        else if(startOrEnd == StartOrEnd.start)
        {
            for(int i = 0 ; i < moveUI.Length ; i++)
            {
                if(_name == moveUI[i].name)
                {
                    _gameObject.DOAnchorPosY(moveUI[i].start,moveUI[i].duration).SetEase(moveUI[i].easeType);
                }
                
            }
        }

        else
        {
            Debug.LogError("Name Not Found !");
        }
        
    }
}
