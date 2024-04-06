using P3R.CharCreator.Reloaded.Configuration;
using P3R.CharCreator.Reloaded.Creator;
using P3R.CharCreator.Reloaded.Creator.Types;
using P3R.CharCreator.Reloaded.Utils;
using Reloaded.Mod.Interfaces;
using System.Text.Json;

namespace P3R.CharCreator.Reloaded.Template.Configuration;

/// <summary>
/// Creates the various different configurations used by the mod.
/// These configurations are available in the dropdown in Reloaded launcher. 
/// </summary>
public class ConfiguratorMixinBase
{
    /// <summary>
    /// Defines the configuration items to create.
    /// </summary>
    /// <param name="configFolder">Folder storing the configuration.</param>
    public virtual IUpdatableConfigurable[] MakeConfigurations(string configFolder)
    {
        var config = Configurable<Config>.FromFile(Path.Combine(configFolder, "Config.json"), "Default Config");

        try
        {
            config.ImportMods = GetImportModsData(configFolder);
        }
        catch (Exception)
        {
        }

        // You can add any Configurable here.
        return new IUpdatableConfigurable[]
        {
            //Configurable<Config>.FromFile(Path.Combine(configFolder, "Config.json"), "Default Config")
            config,
        };
    }

    /// <summary>
    /// Allows for custom launcher/configurator implementation.
    /// If you have your own configuration program/code, run that code here and return true, else return false.
    /// </summary>
    public virtual bool TryRunCustomConfiguration(Configurator configurator)
    {
        return false;
    }

    private static string GetImportModsData(string configFolder)
    {
        var appConfigFile = Path.GetFullPath($"{configFolder}/../../../apps/p3r.exe/appconfig.json");
        var appConfig = ReloadedParser.ParseAppConfig(appConfigFile);

        var charAssets = new List<CharacterAssets>();
        var modsDir = Path.GetFullPath($"{configFolder}/../../../mods");
        foreach (var modDir in Directory.EnumerateDirectories(modsDir))
        {
            var modConfig = ReloadedParser.ParseModConfig(Path.Join(modDir, "ModConfig.json"));
            if (!appConfig.EnabledMods.Contains(modConfig.ModId))
            {
                continue;
            }

            try
            {
                AssetsFromCostumeFramework(charAssets, modDir);
                AssetsFromPack(charAssets, modDir);

                if (modConfig.ModId == "p3rpc.femc")
                {
                    AssetsFromFemc(charAssets);
                }
            }
            catch (Exception)
            {
            }
        }

        return Base64.Encode(JsonSerializer.Serialize(charAssets, new JsonSerializerOptions() { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    }

    private static void AssetsFromPack(List<CharacterAssets> charAssets, string modDir)
    {
        var assetsDir = Path.Join(modDir, "UnrealEssentials", "P3R", "Content", "char-assets");
        if (!Directory.Exists(assetsDir))
        {
            return;
        }

        var faceAssetsDir = Path.Join(assetsDir, "face");
        if (Directory.Exists(faceAssetsDir))
        {
            AssetsFromFolder(charAssets, faceAssetsDir, AssetType.FaceMesh);
        }

        var hairAssetsDir = Path.Join(assetsDir, "hair");
        if (Directory.Exists(hairAssetsDir))
        {
            AssetsFromFolder(charAssets, hairAssetsDir, AssetType.HairMesh);
        }

        var outfitsAssetsDir = Path.Join(assetsDir, "outfits");
        if (Directory.Exists(outfitsAssetsDir))
        {
            AssetsFromFolder(charAssets, outfitsAssetsDir, AssetType.CostumeMesh);
        }
    }

    private static void AssetsFromFolder(List<CharacterAssets> charAssets, string assetsDir, AssetType assetType)
    {
        foreach (var file in Directory.EnumerateFiles(assetsDir, "*.uasset", SearchOption.AllDirectories))
        {
            charAssets.Add(new(Path.GetFileNameWithoutExtension(file), Character.NONE, AssetUtils.GetAssetPath(file), assetType));
        }
    }

    private static void AssetsFromCostumeFramework(List<CharacterAssets> charAssets, string modDir)
    {
        var costumesDir = Path.Join(modDir, "UnrealEssentials", "P3R", "Content", "Costumes");
        if (!Directory.Exists(costumesDir))
        {
            return;
        }

        foreach (var file in Directory.EnumerateFiles(costumesDir, "*.uasset", SearchOption.AllDirectories))
        {
            var costumeName = Path.GetFileName(Path.GetDirectoryName(file))!;
            var character = Enum.Parse<Character>(Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(file)))!);
            var fileName = Path.GetFileName(file).ToLower();
            var assetFile = AssetUtils.GetAssetPath(file);

            switch (fileName)
            {
                case "costume-mesh.uasset":
                    charAssets.Add(new(costumeName, character, assetFile, AssetType.CostumeMesh));
                    break;
                case "hair-mesh.uasset":
                    charAssets.Add(new(costumeName, character, assetFile, AssetType.HairMesh));
                    break;
                case "face-mesh.uasset":
                    charAssets.Add(new(costumeName, character, assetFile, AssetType.FaceMesh));
                    break;
                default: break;
            }
        }
    }

    private static void AssetsFromFemc(List<CharacterAssets> charAssets)
    {
        charAssets.Add(new("FEMC Summer Uniform", Character.NONE, GetFemcCostume(991), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Winter Uniform", Character.NONE, GetFemcCostume(992), AssetType.CostumeMesh));

        // Not added yet?
        charAssets.Add(new("FEMC Summer Garb", Character.NONE, GetFemcCostume(991), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Winter Garb", Character.NONE, GetFemcCostume(992), AssetType.CostumeMesh));

        charAssets.Add(new("FEMC Uniform & Armband", Character.NONE, GetFemcCostume(998), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC SEES Uniform", Character.NONE, GetFemcCostume(999), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Gekkoukan Jersey", Character.NONE, GetFemcCostume(985), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Swimsuit", Character.NONE, AssetUtils.GetAssetPath(Character.Mitsuru, AssetType.CostumeMesh, 102), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Nightwear", Character.NONE, GetFemcCostume(982), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Maid Outfit", Character.NONE, AssetUtils.GetAssetPath(Character.Mitsuru, AssetType.CostumeMesh, 106), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Track Team Shirt", Character.NONE, GetFemcCostume(985), AssetType.CostumeMesh));
        //charAssets.Add(new("FEMC Hotel Yukata", Character.NONE, /* Not implemented */, AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Wilduck Burger Uniform", Character.NONE, GetFemcCostume(983), AssetType.CostumeMesh));
        //charAssets.Add(new("FEMC Dorm Apron", Character.NONE, /* Not implemented */, AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Chagall Cafe Uniform", Character.NONE, GetFemcCostume(984), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Be Blue V Uniform", Character.NONE, GetFemcCostume(980), AssetType.CostumeMesh));
        charAssets.Add(new("FEMC Screen Shot Uniform", Character.NONE, GetFemcCostume(981), AssetType.CostumeMesh));

        charAssets.Add(new("FEMC", Character.NONE, "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999", AssetType.HairMesh));
        charAssets.Add(new("FEMC", Character.NONE, "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_F999", AssetType.FaceMesh));
    }

    private static string GetFemcCostume(int costumeId)
        => AssetUtils.GetAssetPath(Character.Yukari, Creator.AssetType.CostumeMesh, 0).Replace("_C000", $"_C{costumeId:000}");

    #region Config Migration (Must implement if coming from old mod template with config in mod folder)
    /// <summary>
    /// Migrates from the old config location (usually mod folder) to the newer config location (separate folder).
    /// </summary>
    /// <param name="oldDirectory">Old directory containing the mod configs.</param>
    /// <param name="newDirectory">New directory pointing to user config folder.</param>
    public virtual void Migrate(string oldDirectory, string newDirectory)
    {
        // Uncomment to move files from older to newer config directory.
        // TryMoveFile("Config.json");

#pragma warning disable CS8321
        void TryMoveFile(string fileName)
        {
            try { File.Move(Path.Combine(oldDirectory, fileName), Path.Combine(newDirectory, fileName)); }
            catch (Exception) { /* Ignored */ }
        }
#pragma warning restore CS8321
    }
    #endregion
}

internal static class ReloadedParser
{
    public static ReloadedModConfig ParseModConfig(string file)
    {
        try
        {
            return JsonSerializer.Deserialize<ReloadedModConfig>(File.ReadAllText(file)) ?? throw new Exception();
        }
        catch (Exception)
        {
            return new();
        }
    }

    public static ReloadedAppConfig ParseAppConfig(string file)
    {
        try
        {
            return JsonSerializer.Deserialize<ReloadedAppConfig>(File.ReadAllText(file)) ?? throw new Exception();
        }
        catch (Exception)
        {
            return new();
        }
    }
}

internal class ReloadedModConfig
{
    public string ModId { get; set; } = string.Empty;

    public string ModName { get; set; } = string.Empty;
}

internal class ReloadedAppConfig
{
    public string[] EnabledMods { get; set; } = Array.Empty<string>();
}

internal record CharacterAssets(string Name, Character Character, string AssetPath, AssetType AssetType);
