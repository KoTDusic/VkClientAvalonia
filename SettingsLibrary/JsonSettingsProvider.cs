using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SettingsLibrary
{
    public class JsonSettingsProvider<T> : ISettingsProvider<T>
        where T : class, new()
    {
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1);
        private static readonly string SettingsDirectory = Path.Combine(Environment.CurrentDirectory, "Configs");
        private readonly string _fullPath;

        public JsonSettingsProvider(string filename)
        {
            _fullPath = Path.Combine(SettingsDirectory, filename);
        }

        public async Task SaveSettings(T settings)
        {
            try
            {
                await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
                if (!Directory.Exists(SettingsDirectory))
                {
                    Directory.CreateDirectory(SettingsDirectory);
                }

                if (!File.Exists(_fullPath))
                {
                    File.Create(_fullPath).Close();
                }

                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                using (var writer = new StreamWriter(_fullPath, false))
                {
                    await writer.WriteAsync(json).ConfigureAwait(false);
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        public async Task<T> LoadSettings()
        {
            try
            {
                await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
                if (!Directory.Exists(SettingsDirectory))
                {
                    Directory.CreateDirectory(SettingsDirectory);
                }

                if (!File.Exists(_fullPath))
                {
                    File.Create(_fullPath).Close();
                }

                string json;
                using (var reader = new StreamReader(_fullPath))
                {
                    json = await reader.ReadToEndAsync().ConfigureAwait(false);
                }

                return JsonConvert.DeserializeObject<T>(json) ?? new T();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}