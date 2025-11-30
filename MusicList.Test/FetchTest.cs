using MusicList.Entities;
using Supabase;

namespace MusicList.Test;

[TestClass]
public sealed class FetchTest
{
    [TestMethod]
    public async Task FetchMusicList()
    {
        const string publishedKey = "sb_publishable_fBKjSpOOMz7zx0Vpqz_CUw_sHbBVUg2";
        const string url = "https://xsnqymjedaysxqrweylv.supabase.co";

        var client = new Client(url, publishedKey);
        await client.InitializeAsync();
        var response = await client.From<Music>().Get();
        var musicList = response.Models;
        
        Assert.IsNotNull(musicList);
        Assert.IsTrue(musicList.Count > 0);
        
        var music = musicList.FirstOrDefault();
        Assert.IsNotNull(music);
    }

}