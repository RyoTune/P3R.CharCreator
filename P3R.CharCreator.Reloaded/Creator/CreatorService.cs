using P3R.CharCreator.Reloaded.Configuration;
using P3R.CharCreator.Reloaded.Creator.Types;
using Unreal.ObjectsEmitter.Interfaces;

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
        // Base.
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_BaseSkelton.uasset", config.BaseSkeleton);
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_F000.uasset", config.FaceMesh);
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000.uasset", config.HairMesh);

        // Animations.
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CommonAnim.uasset", config.CommonAnim);
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CombineAnim.uasset", config.CombineAnim);
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_EventAnim.uasset", config.EventAnim);
        this.RedirectToCharAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_FaceAnim.uasset", config.FaceAnim);

        // Outfits.
        this.RedirectPlayerOutfit(Outfit.Summer_Uniform, config.SummerUniform);
        this.RedirectPlayerOutfit(Outfit.Winter_Uniform, config.WinterUniform);
        this.RedirectPlayerOutfit(Outfit.Summer_Casual, config.SummerCasual);
        this.RedirectPlayerOutfit(Outfit.Winter_Casual, config.WinterCasual);
    }

    private void RedirectToCharAsset(string assetFile, Character redirectChar)
    {
        // No need to redirect player assets back to player.
        if (redirectChar == Character.Player)
        {
            return;
        }

        var fnames = new AssetFNames(assetFile);

        if (redirectChar >= Character.Player && redirectChar <= Character.Shinjiro)
        {
            this.unreal.AssignFName(Mod.NAME, fnames.AssetName, fnames.AssetName.Replace("0001", $"{(int)redirectChar:0000}"));
            this.unreal.AssignFName(Mod.NAME, fnames.AssetPath, fnames.AssetPath.Replace("0001", $"{(int)redirectChar:0000}"));
        }
        else if (redirectChar == Character.FEMC)
        {
            this.unreal.AssignFName(Mod.NAME, fnames.AssetName, fnames.AssetName.Replace("0001", "0002").Replace("F000", "F999").Replace("H000", "H999"));
            this.unreal.AssignFName(Mod.NAME, fnames.AssetPath, fnames.AssetPath.Replace("0001", "0002").Replace("F000", "F999").Replace("H000", "H999"));
        }
        else
        {
            this.unreal.AssignFName(Mod.NAME, fnames.AssetName, fnames.AssetName.Replace("PC0001", $"SC{(int)redirectChar:0000}"));
            this.unreal.AssignFName(Mod.NAME, fnames.AssetPath, fnames.AssetPath.Replace("PC0001", $"SC{(int)redirectChar:0000}").Replace("Player", "Sub", StringComparison.OrdinalIgnoreCase));
        }
    }

    private void RedirectPlayerOutfit(Outfit outfit, Character redirectChar)
    {
        var assetFile = AssetUtils.GetAssetFile(Character.Player, outfit, CostumeAssetType.Costume_Mesh)!;

        var fnames = new AssetFNames(assetFile);

        if (redirectChar >= Character.Player && redirectChar <= Character.Shinjiro)
        {
            this.unreal.AssignFName(Mod.NAME, fnames.AssetName, fnames.AssetName.Replace("0001", $"{(int)redirectChar:0000}"));
            this.unreal.AssignFName(Mod.NAME, fnames.AssetPath, fnames.AssetPath.Replace("0001", $"{(int)redirectChar:0000}"));
        }
        else
        {
            this.unreal.AssignFName(Mod.NAME, fnames.AssetName, fnames.AssetName.Replace("PC0001", $"SC{(int)redirectChar:0000}"));
            this.unreal.AssignFName(Mod.NAME, fnames.AssetPath, fnames.AssetPath.Replace("PC0001", $"SC{(int)redirectChar:0000}").Replace("Player", "Sub", StringComparison.OrdinalIgnoreCase));
        }
    }

    private record AssetFNames(string AssetFile)
    {
        public string AssetName { get; } = Path.GetFileNameWithoutExtension(AssetFile);

        public string AssetPath { get; } = AssetUtils.GetAssetPath(AssetFile);
    };
}
