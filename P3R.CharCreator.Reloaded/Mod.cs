using P3R.CharCreator.Reloaded.Configuration;
using P3R.CharCreator.Reloaded.Creator;
using P3R.CharCreator.Reloaded.Creator.Types;
using P3R.CharCreator.Reloaded.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Diagnostics;
using System.Drawing;
using Unreal.ObjectsEmitter.Interfaces;

namespace P3R.CharCreator.Reloaded;

public class Mod : ModBase
{
    public const string NAME = "P3R.CharCreator";

    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly CreatorService creator;
    private readonly Dictionary<Character, string> charData = new();

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        Log.Initialize(NAME, this.log, Color.White);
        Log.LogLevel = this.config.LogLevel;

#if DEBUG
        Debugger.Launch();
#endif

        this.modLoader.GetController<IUnreal>().TryGetTarget(out var unreal);
        this.creator = new(unreal!);

        if (this.config.EnableModChars)
        {
            this.modLoader.ModLoading += this.OnModLoading;
        }

        this.modLoader.OnModLoaderInitialized += this.OnModLoaderInitialized;
    }

    private void OnModLoaderInitialized()
    {
        var configCharData = this.config.GetCharacterData();
        foreach (var data in configCharData)
        {
            if (string.IsNullOrEmpty(data.Value))
            {
                continue;
            }

            this.charData[data.Key] = data.Value;
        }

        this.creator.Apply(this.charData);
    }

    private void OnModLoading(IModV1 mod, IModConfigV1 config)
    {
        if (!config.ModDependencies.Contains(this.modConfig.ModId))
        {
            return;
        }

        var modDir = this.modLoader.GetDirectoryForModId(config.ModId);

        var charPresetsDir = Path.Join(modDir, "char-creator", "presets");
        if (Directory.Exists(charPresetsDir))
        {
            foreach (var character in Enum.GetValues<Character>())
            {
                if (character == Character.NONE) continue;

                var charPresetFile = Path.Join(charPresetsDir, $"{character}.txt");
                try
                {
                    if (!File.Exists(charPresetFile))
                    {
                        continue;
                    }

                    var charPresetData = File.ReadAllText(charPresetFile);
                    this.charData[character] = charPresetData;
                    Log.Information($"Loaded character preset. Mod: {config.ModId} || Character: {character}");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Failed to load character preset file.\nFile: {charPresetFile}");
                }
            }
        }
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        config = configuration;
        log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
    }
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}