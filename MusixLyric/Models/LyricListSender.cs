using HtmlAgilityPack;

namespace MusixLyric.Models
{
    public class LyricListSender
    {
        public static List<LyricList> getLyricList(string Name)
        {
            
            var url = "https://www.musixmatch.com/search/" + Name + "/tracks";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            List<LyricList> lyrics = new List<LyricList>();

            var item_names = doc.DocumentNode.SelectNodes("/html/body/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/ul/li/div/div[2]/div/h2/a/span");
            var item_group_name = doc.DocumentNode.SelectNodes("/html/body/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/ul/li/div/div[2]/div/h3/span/span/a");
            var item_img = doc.DocumentNode.SelectNodes("/html/body/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/ul/li/div/div[1]/img");
            var item_link = doc.DocumentNode.SelectNodes("/html/body/div[2]/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/div[1]/ul/li/div/div[2]/div/h2/a");
            for (int i = 0; i < item_names.Count; i++)
            {
                LyricList lyric = new LyricList();
                lyric.Name = item_names[i].InnerText;
                lyric.Group_Name = item_group_name[i].InnerText;
                lyric.img_link = item_img[i].GetAttributeValue("srcset", "");
                lyric.link = item_link[i].GetAttributeValue("href", "");
                lyrics.Add(lyric);
            }
            
            return lyrics;
        }
    }
}
