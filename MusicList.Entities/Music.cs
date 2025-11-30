using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
// ReSharper disable ExplicitCallerInfoArgument
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace MusicList.Entities;

[Table("music")]
public class Music : BaseModel
{
    [PrimaryKey("id")]
    public string Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("artist")]
    public string Artist { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("file_name")]
    public string FileName { get; set; }

    [Column("duration")]
    public double Duration { get; set; }
}
