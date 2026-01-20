using App.Tools;
using VContainer.Unity;

namespace App.PhoenixFlame
{
    public class FlameService : BaseDisposable, IInitializable
    {
        private readonly FlameFactory _flameFactory;
        private FlameView _view;
        
        public FlameService(FlameFactory flameFactory)
        {
            _flameFactory = flameFactory;
        }
        
        public void Initialize()
        {
            _view = _flameFactory.Create();
            LinkDisposable(new GameObjectDisposer(_view.gameObject));
        }

        public void StartAnimation()
        {
            _view.StartAnimation();
        }
    }
}