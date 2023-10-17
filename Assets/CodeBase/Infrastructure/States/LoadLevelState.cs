using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.Hero;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Services.StaticData;
using Assets.CodeBase.StaticData;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly EnemySpawnPoint.Factory _spawnerFactory;
        private readonly HeroMove.Factory _heroFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService,  EnemySpawnPoint.Factory spawnerFactory, HeroMove.Factory heroFactory)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _spawnerFactory = spawnerFactory;
            _heroFactory = heroFactory;
        }

        public void Enter()
        {
            if(_spawnerFactory == null)
            {
                Debug.Log("spawn factory null");
                return;
            }
            InitializeGameWorld();
        }

        public void Exit()
        {

        }
        
        private void InitializeGameWorld()
        {
            LevelStaticData levelData = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);

            InitializeHero();
            InitializeSpawners(levelData);
        }

        private void InitializeHero()
        {
            _heroFactory.Create();
            Debug.Log("created");
        }

        private void InitializeSpawners(LevelStaticData levelData)
        {
            foreach (EnemySpawnerStaticData spawnerData in levelData.EnemySpawners)
            {
                EnemySpawnPoint enemySpawnPoint = _spawnerFactory.Create();
                enemySpawnPoint.Id = spawnerData.Id;
                enemySpawnPoint.EnemyTypeId = spawnerData.EnemyTypeId;
                enemySpawnPoint.transform.position = spawnerData.Position;

                enemySpawnPoint.SpawnEnemy();
                Debug.Log("Created spawn point");
            }
        }
    }
}
