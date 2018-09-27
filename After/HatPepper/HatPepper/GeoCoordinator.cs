using System.Device.Location;
using System.Threading;

namespace HatPepper
{
    /// <summary>
    /// 端末の位置情報を取得する
    /// </summary>
    public class GeoCoordinator : IGeoCoordinator
    {
        /// <summary>
        /// 現在地を取得する
        /// </summary>
        public Location GetCurrent()
        {
            // GeoCoordinateWatcherを利用して位置情報を取得する  
            // GeoCoordinateWatcherではStart直後は位置情報が取得できないため
            // 最初のPositionChangedイベントの発生を待つ必要がある
            Location current;
            using (var watcher = new GeoCoordinateWatcher())
            {
                // PositionChangedイベントを監視し、イベント発生時に待機中のスレッドを再開する
                watcher.PositionChanged += (sender, eventArgs) =>
                {
                    Monitor.Enter(this);
                    try
                    {
                        Monitor.PulseAll(this);
                    }
                    finally
                    {
                        Monitor.Exit(this);
                    }
                };

                Monitor.Enter(this);
                try
                {
                    // GeoCoordinateWatcherを起動し、PositionChangedイベントが発生するまで待機する
                    watcher.Start();
                    Monitor.Wait(this);
                }
                finally
                {
                    Monitor.Exit(this);
                }

                if (watcher.Position?.Location != null
                    && !double.IsNaN(watcher.Position.Location.Latitude)
                    && !double.IsNaN(watcher.Position.Location.Longitude))
                {
                    current = new Location
                    {
                        Latitude = watcher.Position.Location.Latitude,
                        Longitude = watcher.Position.Location.Longitude
                    };
                }
                else
                {
                    current = null;
                }
                watcher.Stop();
            }
            return current;
        }
    }
}
