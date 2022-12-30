﻿using Consts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("ゲームを終了するキー")]
    [SerializeField] private KeyCode _closeKey;
    [Tooltip("フェード処理を実行するオブジェクト")]
    [SerializeField] private Fade _fadeObject;

    private static float _timer = 0f;

    public static float Timer { get => _timer; set => _timer = value; }

    private void Start()
    {
        _timer = Define.GAME_TIME;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            //TODO：制限時間が0になった時に勝利判定をしてリザルトに遷移
            _fadeObject.StartFadeOut(
                () => SceneLoaders.SceneLoad(Fade.MoveSceneName));
        }

        //指定したキーを入力し、ゲームの実行を終了する
        if (Input.GetKeyDown(_closeKey))
        {
            GameClose();
        }
    }

    /// <summary>
    /// ゲームを終了する
    /// </summary>
    private void GameClose()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
