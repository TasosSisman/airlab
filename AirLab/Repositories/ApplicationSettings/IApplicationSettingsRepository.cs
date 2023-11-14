namespace AirLab.Repositories.ApplicationSettings
{
    public interface IApplicationSettingsRepository
    {
        Task<string> GetSettingValueByKey(string settingKey);
    }
}
