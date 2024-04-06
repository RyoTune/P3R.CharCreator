import { AssetType } from '$lib/types/AssetType';
import { Character } from '$lib/types/Character';
import type { CharacterAsset } from '$lib/types/CharacterAsset';
import { GetAssetFile } from './AssetUtils';

export function addExtraAssets(charAssets: CharacterAsset[]) {
  // Player
  charAssets.push({
    name: 'Wilduck Burger Cap',
    character: Character.Player,
    assetPath: GetAssetFile(Character.Player, AssetType.HairMesh, 158),
    assetType: AssetType.HairMesh
  });

  // Yukari
  charAssets.push({
    name: 'Bikini Sunglasses',
    character: Character.Yukari,
    assetPath: GetAssetFile(Character.Yukari, AssetType.HairMesh, 102),
    assetType: AssetType.HairMesh
  });

  charAssets.push({
    name: 'Maid Headband',
    character: Character.Yukari,
    assetPath: GetAssetFile(Character.Yukari, AssetType.HairMesh, 106),
    assetType: AssetType.HairMesh
  });

  // Stupei
  charAssets.push({
    name: 'Backwards Cap',
    character: Character.Stupei,
    assetPath: GetAssetFile(Character.Stupei, AssetType.HairMesh, 102),
    assetType: AssetType.HairMesh
  });

  charAssets.push({
    name: 'Tuxedo Hat',
    character: Character.Stupei,
    assetPath: GetAssetFile(Character.Stupei, AssetType.HairMesh, 106),
    assetType: AssetType.HairMesh
  });

  // Mitsuru
  charAssets.push({
    name: 'Back Hair',
    character: Character.Mitsuru,
    assetPath: GetAssetFile(Character.Mitsuru, AssetType.HairMesh, 102),
    assetType: AssetType.HairMesh
  });

  charAssets.push({
    name: 'Ponytail',
    character: Character.Mitsuru,
    assetPath: GetAssetFile(Character.Mitsuru, AssetType.HairMesh, 104),
    assetType: AssetType.HairMesh
  });

  charAssets.push({
    name: 'Bun',
    character: Character.Mitsuru,
    assetPath: GetAssetFile(Character.Mitsuru, AssetType.HairMesh, 157),
    assetType: AssetType.HairMesh
  });

  // Fuuka
  charAssets.push({
    name: 'SEES Headphones',
    character: Character.Fuuka,
    assetPath: GetAssetFile(Character.Fuuka, AssetType.HairMesh, 52),
    assetType: AssetType.HairMesh
  });

  // Aigis
  charAssets.push({
    name: 'Damaged',
    character: Character.Aigis,
    assetPath: GetAssetFile(Character.Aigis, AssetType.HairMesh, 203),
    assetType: AssetType.HairMesh
  });

  // Shinjiro
  charAssets.push({
    name: 'Ponytail',
    character: Character.Shinjiro,
    assetPath: GetAssetFile(Character.Shinjiro, AssetType.HairMesh, 102),
    assetType: AssetType.HairMesh
  });
}
