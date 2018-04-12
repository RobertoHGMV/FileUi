using WMPLib;

namespace FileUi.Domain.Helpers
{
    public class SoundHelper
    {
        public static void StartMusic()
        {
            const string defaultMusicPath = @"C:\Windows\Media\Alarm02.wav";

            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = defaultMusicPath;
            player.controls.play();
        }
    }
}
