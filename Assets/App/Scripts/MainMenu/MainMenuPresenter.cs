using App.TaskLoader;
using UniRx;

namespace App.MainMenu
{
    public class MainMenuPresenter
    {
        private readonly ITaskLoaderService _taskLoaderService;

        public MainMenuPresenter(ITaskLoaderService taskLoaderService)
        {
            _taskLoaderService = taskLoaderService;
        }

        public void BindView(MainMenuView view)
        {
            view.OnTaskBtnClick.Subscribe(OnTaskBtnClick);
        }

        private void OnTaskBtnClick(int taskIndex)
        {
            LoadTask(taskIndex);
        }

        private void LoadTask(int taskIndex)
        {
            _taskLoaderService.LoadTask(taskIndex);
        }
    }
}