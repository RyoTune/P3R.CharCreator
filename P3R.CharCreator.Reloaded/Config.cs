using P3R.CharCreator.Reloaded.Creator.Types;
using P3R.CharCreator.Reloaded.Template.Configuration;
using System.ComponentModel;

namespace P3R.CharCreator.Reloaded.Configuration;

public class Config : Configurable<Config>
{
    [DisplayName("Log Level")]
    [DefaultValue(LogLevel.Information)]
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    [DisplayName("Protagonist")]
    [DefaultValue(Protag.MC)]
    public Protag Protagonist { get; set; } = Protag.MC;

    [DisplayName("Base Skeleton")]
    [Category("Base")]
    [DefaultValue(Character.Player)]
    public Character BaseSkeleton { get; set; } = Character.Player;

    [DisplayName("Hair")]
    [Category("Base")]
    [DefaultValue(Character.Player)]
    public Character HairMesh { get; set; } = Character.Player;

    [DisplayName("Face")]
    [Category("Base")]
    [DefaultValue(Character.Player)]
    public Character FaceMesh { get; set; } = Character.Player;

    [DisplayName("Summer Uniform")]
    [Category("Outfits")]
    [DefaultValue(Character.Player)]
    public Character SummerUniform { get; set; } = Character.Player;

    [DisplayName("Winter Uniform")]
    [Category("Outfits")]
    [DefaultValue(Character.Player)]
    public Character WinterUniform { get; set; } = Character.Player;

    [DisplayName("Summer Casual")]
    [Category("Outfits")]
    [DefaultValue(Character.Player)]
    public Character SummerCasual { get; set; } = Character.Player;

    [DisplayName("Winter Casual")]
    [Category("Outfits")]
    [DefaultValue(Character.Player)]
    public Character WinterCasual { get; set; } = Character.Player;

    [DisplayName("Common Animations")]
    [Category("Animation")]
    [DefaultValue(Character.Player)]
    public Character CommonAnim { get; set; } = Character.Player;

    [DisplayName("Combine Animations")]
    [Category("Animation")]
    [DefaultValue(Character.Player)]
    public Character CombineAnim { get; set; } = Character.Player;

    [DisplayName("Event Animations")]
    [Category("Animation")]
    [DefaultValue(Character.Player)]
    public Character EventAnim { get; set; } = Character.Player;

    [DisplayName("Face Animations")]
    [Category("Animation")]
    [DefaultValue(Character.Player)]
    public Character FaceAnim { get; set; } = Character.Player;
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}
