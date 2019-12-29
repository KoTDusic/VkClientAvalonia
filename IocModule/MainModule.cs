using Autofac;
using RestSharp;
using SettingsLibrary;
using VkApi;
using VkUi;
using VkUi.ViewModels;
using VkUi.Views;

namespace IocModule
{
    public class MainModule : Module
    {
        const string AuthPage = "https://oauth.vk.com";
        private const string WorkPage = "https://api.vk.com/method";
        const string ProgramSettingsPath = "program_settings.json";

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ISettingsProvider<ProgramSettings>>(context =>
                    new JsonSettingsProvider<ProgramSettings>(ProgramSettingsPath))
                .As<ISettingsProvider<ProgramSettings>>().SingleInstance();
            builder.Register(context =>
                    new VkRequestSender(new RestClient(AuthPage)
                            .UseSerializer(() => new JsonNetSerializer()),
                        new RestClient(WorkPage)
                            .UseSerializer(() => new JsonNetSerializer())))
                .AsSelf();
            builder.Register(context => new MainWindowViewModel(context.Resolve<VkRequestSender>(),
                context.Resolve<ISettingsProvider<ProgramSettings>>()));
            builder.Register(context => new MainWindow(context.Resolve<MainWindowViewModel>()));
        }
    }
}