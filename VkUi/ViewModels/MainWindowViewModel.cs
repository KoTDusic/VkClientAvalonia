using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using SettingsLibrary;
using VkApi;

namespace VkUi.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly VkRequestSender _api;
        private readonly ISettingsProvider<ProgramSettings> _settingsProvider;

        public string Login { get; set; }
        public string Password { get; set; }
        public ReactiveCommand<Unit, Unit> Auth { get; }
        public ObservableCollection<DialogViewModel> Dialogs { get; } = new ObservableCollection<DialogViewModel>();

        public MainWindowViewModel(VkRequestSender api, ISettingsProvider<ProgramSettings> settingsProvider)
        {
            _api = api ?? throw new ArgumentException();
            _settingsProvider = settingsProvider ?? throw new ArgumentException();
            var settings = _settingsProvider.LoadSettings().Result;
            Login = settings.Login;
            Password = settings.Password;
            Auth = ReactiveCommand.CreateFromTask(AuthExecute);
        }

        private async Task AuthExecute()
        {
            try
            {
                if (Login == null || Password == null)
                {
                    return;
                }

                if (!await _api.Auth(Login, Password))
                {
                    return;
                }

                await _settingsProvider.SaveSettings(
                    new ProgramSettings
                    {
                        Login = Login,
                        Password = Password
                    });
                var result = (await _api.GetDialogs()).Response.Items
                    .Select(conversation => new DialogViewModel(conversation))
                    .ToList();

                Dialogs.Clear();
                Dialogs.AddRange(result);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}