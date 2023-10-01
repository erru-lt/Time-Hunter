using Assets.CodeBase.Infrastructure.AssetManagement;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class EnemyFactory
    {
        private readonly IAssetProvider _assetProvider;

        public EnemyFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Create()
        {
            _assetProvider.Instantiate(AssetPath.EnemyPath);
        }
    }
}