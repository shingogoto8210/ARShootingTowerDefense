/// <summary>
/// ARStateの状態
/// </summary>
public enum ARState
{
    Debug,         // Editor でのデバッグ用
    Tracking,     // 平面感知中
    Wait,         // 待機。どこのステートにも属さない状態
    Ready,        // ゲーム準備中
    Play,         // ゲーム中
    GameUp,       // ゲーム終了
}

