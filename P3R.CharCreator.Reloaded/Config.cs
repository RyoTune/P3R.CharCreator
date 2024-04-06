using P3R.CharCreator.Reloaded.Creator.Types;
using P3R.CharCreator.Reloaded.Template.Configuration;
using System.ComponentModel;

namespace P3R.CharCreator.Reloaded.Configuration;

public class Config : Configurable<Config>
{
    [DisplayName("Log Level")]
    [DefaultValue(LogLevel.Information)]
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    [DisplayName("Import Mods")]
    [DefaultValue("")]
    public string ImportMods { get; set; } = string.Empty;

    [DisplayName("Enable Mod Characters")]
    [Description("Allow for character data to be loaded from mods,\nsuch as character preset mods.")]
    [DefaultValue(true)]
    public bool EnableModChars { get; set; } = true;

    [Category("Character Data")]
    [DisplayName("Player")]
    [DefaultValue("")]
    public string PlayerData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Yukari")]
    [DefaultValue("")]
    public string YukariData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Stupei")]
    [DefaultValue("")]
    public string StupeiData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Akihiko")]
    [DefaultValue("")]
    public string AkihikoData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Mitsuru")]
    [DefaultValue("")]
    public string MitsuruData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Fuuka")]
    [DefaultValue("")]
    public string FuukaData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Aigis")]
    [DefaultValue("")]
    public string AigisData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Ken")]
    [DefaultValue("")]
    public string KenData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Koromaru")]
    [DefaultValue("")]
    public string KoromaruData { get; set; } = string.Empty;

    [Category("Character Data")]
    [DisplayName("Shinjiro")]
    [DefaultValue("")]
    public string ShinjiroData { get; set; } = string.Empty;

    public Dictionary<Character, string> GetCharacterData()
    {
        return new()
        {
            [Character.Player] = this.PlayerData,
            [Character.Yukari] = this.YukariData,
            [Character.Stupei] = this.StupeiData,
            [Character.Akihiko] = this.AkihikoData,
            [Character.Mitsuru] = this.MitsuruData,
            [Character.Fuuka] = this.FuukaData,
            [Character.Aigis] = this.AigisData,
            [Character.Ken] = this.KenData,
            [Character.Koromaru] = this.KoromaruData,
            [Character.Shinjiro] = this.ShinjiroData,
        };
    }
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}
