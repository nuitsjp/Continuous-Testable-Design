namespace HatPepper
{
    /// <summary>
    /// 端末の位置情報を取得する
    /// </summary>
    public interface IGeoCoordinator
    {
        /// <summary>
        /// 現在地を取得する
        /// </summary>
        Location GetCurrent();
    }
}