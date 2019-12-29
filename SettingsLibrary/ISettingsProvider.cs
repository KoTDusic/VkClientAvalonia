using System.Threading.Tasks;

namespace SettingsLibrary
{
    public interface ISettingsProvider<T>
    {
        Task SaveSettings(T settings);
        Task<T> LoadSettings();
    }
}