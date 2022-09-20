using HtmlAgilityPack;

namespace MusixLyric.Models
{
    public class LyricSender
    {
        public static Lyric getLyric(string Link)
        {
            var url = "https://www.musixmatch.com/" + Link;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var lyric_name = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div/div/main/div/div/div[2]/div/div/div/div[2]/div[1]/div[1]/h1/text()").InnerText;
            var lyric_header = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[1]/span/p").InnerText;
            var lyric_main = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[1]/span/div/p/span").InnerText;
            var lyric_updatetime = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div/div/main/div/div/div[2]/div/div/div/div[2]/div[1]/div[2]/span").InnerText;
            var lyric_groupname = doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div/div/main/div/div/div[2]/div/div/div/div[2]/div[1]/div[1]/h2/span/a").InnerText;

            Lyric res = new Lyric();
            res.Name = lyric_name;
            res.Header_Lyric = lyric_header;
            res.Main_Lyric = lyric_main;
            res.Update_time = lyric_updatetime;
            res.Group_name = lyric_groupname;
            
            return res;
        }
    }
}
