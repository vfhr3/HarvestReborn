using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Infrastructure.Terrain
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Tile[] availableTiles;
        [SerializeField] private UnityEngine.Camera mainCamera;
        [SerializeField] private int bufferSize = 2; // буфер за пределами экрана

        private readonly Dictionary<Vector3Int, TileBase> _tiles = new();

        private void Start()
        {
            tilemap = GetComponent<Tilemap>();
            mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            GenerateTilesInCameraView();
        }

        private void GenerateTilesInCameraView()
        {
            // Проверки на null
            if (availableTiles == null || availableTiles.Length == 0)
            {
                Debug.LogError("availableTiles is empty!");
                return;
            }

            if (mainCamera == null)
            {
                Debug.LogError("mainCamera is null!");
                return;
            }

            var bottomLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
            var topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            var bottomLeftCell = tilemap.WorldToCell(bottomLeft);
            var topRightCell = tilemap.WorldToCell(topRight);

            // временно пометим, какие тайлы мы хотим оставить
            var visibleTiles = new HashSet<Vector3Int>();

            // Генерируем с буфером
            for (var x = bottomLeftCell.x - bufferSize; x <= topRightCell.x + bufferSize; x++)
            for (var y = bottomLeftCell.y - bufferSize; y <= topRightCell.y + bufferSize; y++)
            {
                var pos = new Vector3Int(x, y, 0);
                visibleTiles.Add(pos);

                if (!_tiles.ContainsKey(pos))
                {
                    var tile = GetTileForPosition(pos);
                    _tiles[pos] = tile;
                    tilemap.SetTile(pos, tile); // устанавливаем ТОЛЬКО новые тайлы
                }
            }

            // убираем тайлы, которые больше не видимы
            var tilesToRemove = new List<Vector3Int>();
            foreach (var kvp in _tiles)
                if (!visibleTiles.Contains(kvp.Key))
                {
                    tilemap.SetTile(kvp.Key, null);
                    tilesToRemove.Add(kvp.Key);
                }

            foreach (var pos in tilesToRemove) _tiles.Remove(pos);
        }

        // Детерминированная генерация тайла по позиции
        private TileBase GetTileForPosition(Vector3Int pos)
        {
            var hash = (pos.x * 73856093) ^ (pos.y * 19349663);
            var index = (hash % availableTiles.Length + availableTiles.Length) % availableTiles.Length;
            return availableTiles[index];
        }
    }
}