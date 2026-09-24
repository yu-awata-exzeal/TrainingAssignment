using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Manager
{
    public class InGameManager
    {
        /// <summary>
        /// 指定されたステージの設定
        /// </summary>
        private StageSettings _currentStageSetting;
        /// <summary>
        /// プレイヤーの操作キャラクター
        /// </summary>
        private PlayerCharacter _playerCharactor;
        /// <summary>
        /// 拠点オブジェクト
        /// </summary>
        private BasePoint _basePoint;
        /// <summary>
        /// インゲーム内経過時間を計測するタイマー
        /// </summary>
        private float _inGameTimer;
        /// <summary>
        /// インゲーム終了フラグ
        /// </summary>
        private bool _isEndInGame = false;

        /// <summary>
        /// インゲームセットアップ
        /// </summary>
        public void Setup()
        {
            _playerCharactor = Object.Instantiate<PlayerCharacter>(new());
            _basePoint = Object.Instantiate<BasePoint>(new());
            CountTimer().Forget();
        }

        /// <summary>
        /// インゲーム内の各タイマー計測
        /// </summary>
        /// <returns></returns>
        private UniTask CountTimer()
        {
            _inGameTimer += Time.deltaTime;

            if (_inGameTimer > _currentStageSetting.SurvivalTimeLimit)
            {
                Clear();
                _isEndInGame = true;
            }

            if (_basePoint.CurrentEnelgyContent < 0)
            {
                GameOver();
                _isEndInGame = true;
            }

            return UniTask.WaitUntil(() => _isEndInGame);
        }

        /// <summary>
        /// クリア判定時の処理
        /// </summary>
        private void Clear()
        {

        }

        /// <summary>
        /// ゲームオーバー判定時の処理
        /// </summary>
        private void GameOver()
        {

        }
    }
}
