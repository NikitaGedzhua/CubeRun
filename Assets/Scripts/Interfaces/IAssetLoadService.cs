using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Gedjua.Runner.Interface
{
    public interface IAssetLoadService
    {
        public Task<AsyncOperationHandle<GameObject>> LoadAssetToCacheAsync(string path);
        
        public AsyncOperationHandle<GameObject> LoadAssetAsync(string path);
        
        public void UnloadAsset(AsyncOperationHandle<GameObject> opHandle);
    }
}