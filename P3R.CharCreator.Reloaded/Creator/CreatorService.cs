using P3R.CharCreator.Reloaded.Configuration;
using P3R.CharCreator.Reloaded.Creator.Types;
using P3R.CharCreator.Reloaded.Utils;
using System.Text.Json;
using Unreal.ObjectsEmitter.Interfaces;
using static P3R.CharCreator.Reloaded.Utils.Common;

namespace P3R.CharCreator.Reloaded.Creator;

internal class CreatorService
{
    private readonly IUnreal unreal;

    public CreatorService(IUnreal unreal)
    {
        this.unreal = unreal;
    }

    public void Apply(Config config)
    {
        foreach (var charData in config.GetCharacterData())
        {
            if (string.IsNullOrEmpty(charData.Value) == false
                && DecodeCharConfig(charData.Value) is CharacterConfig charConfig)
            {
                this.ApplyCharConfig(charConfig);
            }
        }
    }

    private void ApplyCharConfig(CharacterConfig charConfig)
    {
        // Base.
        DoIfString(charConfig.Base.BaseSkeleton, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.BaseMesh), path));
        DoIfString(charConfig.Base.Hair, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.HairMesh), path));
        DoIfString(charConfig.Base.Face, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.FaceMesh), path));

        // Animations.
        DoIfString(charConfig.Animations.Common, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.CommonAnim), path));
        DoIfString(charConfig.Animations.Face, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.FaceAnim), path));
        DoIfString(charConfig.Animations.Combine, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.CombineAnim), path));
        DoIfString(charConfig.Animations.Event, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.EventAnim), path));

        // Outfits.
        foreach (var outfit in charConfig.Outfits)
        {
            DoIfString(outfit.Value, path => this.RedirectAsset(AssetUtils.GetAssetPath(charConfig.Base.Character, AssetType.CostumeMesh, (int)outfit.Key), path));
        }

        Log.Information($"{charConfig.Base.Character}: Applied character data.");
    }

    private void RedirectAsset(string ogAssetPath, string newAssetPath)
    {
        var ogFnames = new AssetFNames(ogAssetPath);
        var newFnames = new AssetFNames(newAssetPath);

        this.unreal.AssignFName(Mod.NAME, ogFnames.AssetName, newFnames.AssetName);
        this.unreal.AssignFName(Mod.NAME, ogFnames.AssetPath, newFnames.AssetPath);
    }

    private static CharacterConfig? DecodeCharConfig(string charData)
    {
        try
        {
            var json = Base64.Decode(charData);
            var charConfig = JsonSerializer.Deserialize<CharacterConfig>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? throw new Exception();
            return charConfig;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to decode character data.");
            return null;
        }
    }

    private record AssetFNames(string AssetFile)
    {
        public string AssetName { get; } = Path.GetFileNameWithoutExtension(AssetFile);

        public string AssetPath { get; } = AssetUtils.GetAssetPath(AssetFile);
    };
}
