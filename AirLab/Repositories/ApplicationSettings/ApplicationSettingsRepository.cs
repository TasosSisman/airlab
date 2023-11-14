using AirLab.Data;
using Microsoft.EntityFrameworkCore;

namespace AirLab.Repositories.ApplicationSettings
{
    public class ApplicationSettingsRepository : IApplicationSettingsRepository
    {
        private readonly DataContext _context;

        public ApplicationSettingsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<string> GetSettingValueByKey(string settingKey)
        {
            return await _context.ApplicationSettings.Where(x => x.Key == settingKey).Select(x => x.Value).FirstOrDefaultAsync();
        }
    }
}
