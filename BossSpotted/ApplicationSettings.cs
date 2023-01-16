namespace BossSpotted
{
    public class ApplicationSettings
    {
        public BossSpottedOptions bossSpottedOptions { get; set; }
    }
    public class BossSpottedOptions
    {
        public string DbConnectionString { get; set; }
    }
}
