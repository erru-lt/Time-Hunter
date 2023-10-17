using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject LoadPrefab(string path);
    }
}