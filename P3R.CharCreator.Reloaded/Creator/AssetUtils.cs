using P3R.CharCreator.Reloaded.Creator.Types;

namespace P3R.CharCreator.Reloaded.Creator;

internal static class AssetUtils
{
    /// <summary>
    /// Gets the expected asset file for the given character's costume ID and asset type.
    /// </summary>
    /// <param name="character">Character.</param>
    /// <param name="costumeId">Costume ID.</param>
    /// <param name="type">Asset type.</param>
    /// <returns></returns>
    public static string GetAssetPath(Character character, AssetType type, int costumeId = 0)
        => type switch
        {
            AssetType.BaseMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_BaseSkelton", character),
            AssetType.CostumeMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_C{costumeId:000}", character),
            AssetType.HairMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_H{costumeId:000}", character),
            AssetType.FaceMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_F{costumeId:000}", character),
            AssetType.CommonAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CommonAnim", character),
            AssetType.CombineAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CombineAnim", character),
            AssetType.EventAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_EventAnim", character),
            AssetType.FaceAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_FaceAnim", character),
            _ => throw new Exception(),
        };

    public static string GetFemcAssetPath(AssetType type, int costumeId)
        => type switch
        {
            AssetType.BaseMesh => "/Game/Xrd777/Characters/Player/FemC/Femc_Skeleton",
            AssetType.CostumeMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(Character.Player)}/Models/SK_PC{FormatCharId(Character.Player)}_C{costumeId:000}", Character.Player),
            AssetType.HairMesh => "/Game/Xrd777/Characters/Player/FemC/Femc_Hair",
            AssetType.FaceMesh => "/Game/Xrd777/Characters/Player/FemC/Femc_Face",
            AssetType.CommonAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(Character.Player)}/DA_PC{FormatCharId(Character.Player)}_CommonAnim",
            AssetType.CombineAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(Character.Player)}/DA_PC{FormatCharId(Character.Player)}_CombineAnim",
            AssetType.EventAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(Character.Player)}/DA_PC{FormatCharId(Character.Player)}_EventAnim",
            AssetType.FaceAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(Character.Player)}/DA_PC{FormatCharId(Character.Player)}_FaceAnim",
            _ => throw new Exception(),
        };

    private static string GetFemcCostumePath(Outfit outfit)
        => outfit switch
        {
            Outfit.Missing => throw new NotImplementedException(),
            Outfit.Summer_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_Summer_School",
            Outfit.Winter_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School",
            Outfit.Summer_Casual => "/Game/Xrd777/Characters/Player/FemC/Femc_Summer_Casual",
            Outfit.Winter_Casual => "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_Casual",
            Outfit.Uniform_Armband => "/Game/Xrd777/Characters/Player/FemC/Femc_BattleArmor",
            Outfit.SEES_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School_Battle",
            Outfit.Gekkoukan_Jersey => "/Game/Xrd777/Characters/Player/FemC/Femc_Tracksuit",
            Outfit.Swimsuit => "/Game/Xrd777/Characters/Player/FemC/Femc_Swimsuit",
            Outfit.Nightwear => "/Game/Xrd777/Characters/Player/FemC/Femc_Nightwear",
            Outfit.Battle_Armor => throw new NotImplementedException(),
            Outfit.Butler_Suit => GetAssetPath(Character.Mitsuru, AssetType.CostumeMesh, (int)Outfit.Butler_Suit),
            Outfit.Track_Team_Shirt => "/Game/Xrd777/Characters/Player/FemC/Femc_Tracksuit",
            Outfit.Hot_Springs_Towel => GetAssetPath(Character.Mitsuru, AssetType.CostumeMesh, (int)Outfit.Hot_Springs_Towel),
            Outfit.Hotel_Yukata => GetAssetPath(Character.Yukari, AssetType.CostumeMesh, (int)Outfit.Hotel_Yukata),
            Outfit.Shrine_Festival_Yukata => throw new NotImplementedException(),
            Outfit.New_Years_Kimono => throw new NotImplementedException(),
            Outfit.Wilduck_Burger_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_WildDuck",
            Outfit.Dorm_Apron => "/Game/Xrd777/Characters/Player/FemC/Femc_Apron",
            Outfit.Cafe_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_Cafe",
            Outfit.Be_Blue_V_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_BeBlue",
            Outfit.Screen_Shot_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_ScreenshotUniform",
            Outfit.SEES_Outfit => "/Game/Xrd777/Characters/Player/FemC/Femc_BattleArmor",
            Outfit.SEES_Uniform_2 => throw new NotImplementedException(),
            Outfit.Damaged_Ribbon => throw new NotImplementedException(),
            Outfit.Ocean_Sundress => throw new NotImplementedException(),
            Outfit.Ocean_Sundress_2 => throw new NotImplementedException(),
            Outfit.Firearms => throw new NotImplementedException(),
            Outfit.Phantom_Suit => "/Game/Xrd777/Characters/Player/FemC/Femc_PhantomThief",
            Outfit.Shujin_Uniform => GetAssetPath(Character.Mitsuru, AssetType.CostumeMesh, (int)Outfit.Shujin_Uniform),
            Outfit.Yasogami_Uniform => "/Game/Xrd777/Characters/Player/FemC/Femc_P4_Uniform",
            _ => throw new NotImplementedException(),
        };

    public static string GetAssetFile(Character character, AssetType type, Outfit outfit)
        => GetAssetPath(character, type, (int)outfit);

    /// <summary>
    /// Gets the expected asset path from asset file path.
    /// Simply removes the .uasset extension and/or adds the game content path.
    /// </summary>
    /// <param name="assetFile">Asset .uasset file path.</param>
    /// <returns>Asset path.</returns>
    public static string GetAssetPath(string assetFile)
    {
        var adjustedPath = assetFile.Replace('\\', '/').Replace(".uasset", string.Empty);

        if (adjustedPath.IndexOf("Content") is int contentIndex && contentIndex > -1)
        {
            adjustedPath = adjustedPath.Substring(contentIndex + 8);
        }

        if (!adjustedPath.StartsWith("/Game/"))
        {
            adjustedPath = $"/Game/{adjustedPath}";
        }

        return adjustedPath;
    }

    public static string FormatCharId(Character character)
        => ((int)character).ToString("0000");

    private static string FormatAssetPath(string path, Character character)
    {
        if (character >= Character.Player && character <= Character.Shinjiro)
        {
            return path;
        }
        else
        {
            return path.Replace("PC", "SC").Replace("Player", "Sub");
        }
    }
}
