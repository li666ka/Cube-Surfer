using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ScreensController : MonoBehaviour
{ 
    [SerializeField] private Screen _screenStart;
    [SerializeField] private Screen _screenScore;
    [SerializeField] private Screen _screenFinish;
    [SerializeField] private Screen _screenGameOver;

    [SerializeField] private PlayerDeath _playerDeath;
    [SerializeField] private OnTouchListener _onTouchListener;

    private void Start()
    {
        _screenStart.Show();

        _screenScore.Hide(false);
        _screenFinish.Hide(false);
        _screenGameOver.Hide(false);

        _onTouchListener.OnTouch += _screenScore.Show;
        _onTouchListener.OnTouch += _screenStart.Hide;

        _onTouchListener.OnTouch += UnsubscribeFromEvent;
        
        _playerDeath.PlayerDied += _screenGameOver.Show;
    }

    private void UnsubscribeFromEvent()
    {
        _onTouchListener.OnTouch -= _screenScore.Show;
        _onTouchListener.OnTouch -= _screenStart.Hide;
        _onTouchListener.OnTouch -= UnsubscribeFromEvent;
    }
}
