using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polygon.Core.Enums.OpenGraph
{
    public enum OpenGraphTypes
    {
        [Display(Name = "Music - Song")]
        [Description("music.song")]
        MusicSong,
        [Display(Name = "Music - Album")]
        [Description("music.album")]
        MusicAlbum,
        [Display(Name = "Music - Playlist")]
        [Description("music.playlist")]
        MusicPlaylist,
        [Display(Name = "Music - Radio Station")]
        [Description("music.radio_station")]
        MusicRadioStation,
        [Display(Name = "Video - Movie")]
        [Description("video.movie")]
        VideoMovie,
        [Display(Name = "Video - Episode")]
        [Description("video.episode")]
        VideoEpisode,
        [Display(Name = "Video - TV Show")]
        [Description("video.tv_show")]
        VideoTvShow,
        [Display(Name = "Video - Other")]
        [Description("video.other")]
        VideoOther,
        [Display(Name = "Article")]
        [Description("article")]
        Article,
        [Display(Name = "Book")]
        [Description("book")]
        Book,
        [Display(Name = "Profile")]
        [Description("profile")]
        Profile,
        [Display(Name = "Website")]
        [Description("website")]
        Website
    }
}
