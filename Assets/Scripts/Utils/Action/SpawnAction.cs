using FireBall.Core.Managers;
using UnityEngine;

namespace FireBall.Core
{
    public class SpawnAction : ActionBase
    {
        public override void Execute(object data = null)
        {
            if (data is SpawnManager.SpawnInformation _spawnInformation)
            {
                var count = _spawnInformation._countSpawn;
                var step = _spawnInformation._stepSpawn;
                var currentPointSpawn = _spawnInformation._startPosition;
                var parent = _spawnInformation._parentObject;
                var prefab = _spawnInformation._prefabToSpawn;
                var rotation = _spawnInformation._prefabToSpawn.transform.rotation;
                var chestPrefab = _spawnInformation._prefabChest;

                for (int i = 0; i < count; i++)
                {
                    if(parent != null)
                        Instantiate(prefab, currentPointSpawn, rotation, parent.transform);
                    if(parent == null)
                        Instantiate(prefab, currentPointSpawn, rotation);

                    currentPointSpawn = new Vector3(currentPointSpawn.x, 
                        currentPointSpawn.y + step, 
                        currentPointSpawn.z);

                    rotation = new Quaternion(rotation.x, rotation.y + 0.1f, rotation.z, rotation.w);
                }

                if (parent != null)
                    Instantiate(chestPrefab, currentPointSpawn, chestPrefab.transform.rotation, parent.transform);
                if (parent == null)
                    Instantiate(chestPrefab, currentPointSpawn, rotation);
            }
        }
    }
}