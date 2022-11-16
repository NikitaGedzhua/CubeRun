using System.Threading.Tasks;
using Gedjua.Runner.Interface;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Gedjua.Runner.Services
{
    public class LocalAssetProvider : IAssetLoadService
    {
        public async Task<AsyncOperationHandle<GameObject>> LoadAssetToCacheAsync(string path)
        {
            var opHandle = Addressables.LoadAssetAsync<GameObject>(path);
            await opHandle.Task;
            return opHandle;
        } 
        
        public  AsyncOperationHandle<GameObject> LoadAssetAsync(string path)
        {
            return  Addressables.LoadAssetAsync<GameObject>(path);
        }
        
        public void UnloadAsset(AsyncOperationHandle<GameObject> opHandle)
        {
            Addressables.Release(opHandle);
        }
    }
}