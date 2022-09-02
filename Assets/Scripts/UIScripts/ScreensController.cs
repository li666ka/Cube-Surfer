using UnityEngine;
using UnityEngine.Serialization;

namespace UIScripts
{
    public class ScreensController : MonoBehaviour
    { 
        [SerializeField] private Screen _screenStart;
        [SerializeField] private Screen _screenScore;
        [SerializeField] private Screen _screenFinish;
        [SerializeField] private Screen _screenGameOver;

        [SerializeField] private Death death;
        [SerializeField] private OnTouchListener _onTouchListener;

        private void Start()
        {
            _screenStart.Show();

            _screenScore.Hide(false);
            _screenFinish.Hide(false);
            _screenGameOver.Hide(false);

            _onTouchListener.Touched += _screenScore.Show;
            _onTouchListener.Touched += _screenStart.Hide;

            _onTouchListener.Touched += UnsubscribeFromEvent;
        
            death.PlayerDied += _screenGameOver.Show;
        }

        private void UnsubscribeFromEvent()
        {
            _onTouchListener.Touched -= _screenScore.Show;
            _onTouchListener.Touched -= _screenStart.Hide;
            _onTouchListener.Touched -= UnsubscribeFromEvent;
        }
    }
}
