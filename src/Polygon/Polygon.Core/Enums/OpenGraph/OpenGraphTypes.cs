using System.ComponentModel;

namespace Polygon.Core.Enums.OpenGraph
{
    public enum OpenGraphTypes
    {
        [Description("music.song")]
        MusicSong,
        [Description("music.album")]
        MusicAlbum,
        [Description("music.playlist")]
        MusicPlaylist,
        [Description("music.radio_station")]
        MusicRadioStation,
        [Description("video.movie")]
        VideoMovie,
        [Description("video.episode")]
        VideoEpisode,
        [Description("video.tv_show")]
        VideoTvShow,
        [Description("video.other")]
        VideoOther,
        [Description("article")]
        Article,
        [Description("book")]
        Book,
        [Description("profile")]
        Profile,
        [Description("website")]
        Website
    }
}
