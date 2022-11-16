using System.Threading.Tasks;
using Gedjua.Runner.Game.Config;

namespace Gedjua.Runner.Interface
{
    public interface IConfigService
    {
        public Task<DataConfig> GetDataConfigAsync();
        public  Task<PlayerConfig> GetPlayerConfigAsync();
        public  Task<GameConfig> GetGameConfigAsync();
        public  Task<RoadObjConfig> GetRoadObjConfigAsync();
        public  Task<CameraConfig> GetCameraConfigAsync();
    }
}