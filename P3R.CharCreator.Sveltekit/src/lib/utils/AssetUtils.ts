import { AssetType } from '$lib/types/AssetType';
import { Character } from '$lib/types/Character';

export function GetAssetFile(char: Character, assetType: AssetType, costumeId: number = 0): string {
  switch (assetType) {
    case AssetType.BaseMesh:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_BaseSkelton`,
        char
      );
    case AssetType.CostumeMesh:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_C${FormatCostumeId(costumeId)}`,
        char
      );
    case AssetType.FaceMesh:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_F${FormatCostumeId(costumeId)}`,
        char
      );
    case AssetType.HairMesh:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_H${FormatCostumeId(costumeId)}`,
        char
      );
    case AssetType.CommonAnim:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Data/DataAsset/Player/PC${FormatCharId(char)}/DA_PC${FormatCharId(char)}_CommonAnim`,
        char
      );
    case AssetType.CombineAnim:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Data/DataAsset/Player/PC${FormatCharId(char)}/DA_PC${FormatCharId(char)}_CombineAnim`,
        char
      );
    case AssetType.EventAnim:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Data/DataAsset/Player/PC${FormatCharId(char)}/DA_PC${FormatCharId(char)}_EventAnim`,
        char
      );
    case AssetType.FaceAnim:
      return FormatAssetPath(
        `/Game/Xrd777/Characters/Data/DataAsset/Player/PC${FormatCharId(char)}/DA_PC${FormatCharId(char)}_FaceAnim`,
        char
      );
    default:
      return '';
  }
}

function FormatAssetPath(path: string, char: Character) {
  if (char >= Character.Player && char <= Character.Shinjiro) {
    return path;
  }

  return path.replaceAll('PC', 'SC').replaceAll('Player', 'Sub');
}

export function FormatCharId(char: Character) {
  return String(char).padStart(4, '0');
}

export function FormatCostumeId(costumeId: number) {
  return String(costumeId).padStart(3, '0');
}
