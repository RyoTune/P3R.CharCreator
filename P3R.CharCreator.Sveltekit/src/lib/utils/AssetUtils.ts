import { AssetType } from '$lib/types/AssetType';
import type { Character } from '$lib/types/Character';

export function GetAssetFile(char: Character, costumeId: number, assetType: AssetType): string {
  switch (assetType) {
    case AssetType.Base_Mesh:
      return `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_BaseSkeleton.uasset`;
    case AssetType.Costume_Mesh:
      return `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_C${FormatCostumeId(costumeId)}.uasset`;
    case AssetType.Face_Mesh:
      return `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_F${FormatCostumeId(costumeId)}.uasset`;
    case AssetType.Hair_Mesh:
      return `/Game/Xrd777/Characters/Player/PC${FormatCharId(char)}/Models/SK_PC${FormatCharId(char)}_H${FormatCostumeId(costumeId)}.uasset`;
    default:
      return '';
  }
}

export function FormatCharId(char: Character) {
  return String(char).padStart(4, '0');
}

export function FormatCostumeId(costumeId: number) {
  return String(costumeId).padStart(3, '0');
}
