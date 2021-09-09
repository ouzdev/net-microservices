using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo{
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
        IEnumerable<Platform> GetAllPlatforms();
        bool SaveChanges();
        
    }
}