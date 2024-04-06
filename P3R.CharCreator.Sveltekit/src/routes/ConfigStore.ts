import { AssetType } from '$lib/types/AssetType';
import { Character } from '$lib/types/Character';
import type { CharacterAsset } from '$lib/types/CharacterAsset';
import { CharacterConfig } from '$lib/types/CharacterConfig';
import { GetAssetFile } from '$lib/utils/AssetUtils';
import { derived, writable } from 'svelte/store';
import gameCostumesJson from '$lib/data/costumes.json';
import { addExtraAssets } from '$lib/utils/ExtraAssets';

const gameChars = Object.values(Character).filter(
  (x) => !isNaN(x as Character) && x != Character.NONE
) as Character[];

export const gameCostumes = (
  Object.values(gameCostumesJson).flat() as unknown as {
    Character: number;
    CostumeId: number;
    Name: string;
  }[]
)
  .filter((x) => {
    if (
      x.CostumeId == 154 ||
      x.CostumeId == 104 ||
      x.CostumeId == 501 ||
      x.CostumeId == 502 ||
      x.CostumeId == 503 ||
      x.Character == 8 ||
      x.Character == 9 ||
      x.Character == 51
    ) {
      return false;
    }

    return true;
  })
  .map((x): CharacterAsset => {
    return {
      character: x.Character,
      name: x.Name,
      outfit: x.CostumeId,
      assetPath: GetAssetFile(x.Character, AssetType.CostumeMesh, x.CostumeId),
      assetType: AssetType.CostumeMesh
    };
  });

// Assets from existing characters.
const gameSkeletons = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.BaseMesh),
    name: 'Default',
    character: x,
    assetType: AssetType.BaseMesh
  };
});

const gameHairs = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.HairMesh),
    name: 'Default',
    character: x,
    assetType: AssetType.HairMesh
  };
});

const gameFaces = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.FaceMesh),
    name: 'Default',
    character: x,
    assetType: AssetType.FaceMesh
  };
});

const gameCommonAnims = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.CommonAnim),
    name: 'Default',
    character: x,
    assetType: AssetType.CommonAnim
  };
});

const gameFaceAnims = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.FaceAnim),
    name: 'Default',
    character: x,
    assetType: AssetType.FaceAnim
  };
});

const gameCombineAnims = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.CombineAnim),
    name: 'Default',
    character: x,
    assetType: AssetType.CombineAnim
  };
});

const gameEventAnims = gameChars.map<CharacterAsset>((x) => {
  return {
    assetPath: GetAssetFile(x, AssetType.EventAnim),
    name: 'Default',
    character: x,
    assetType: AssetType.EventAnim
  };
});

const gameAssets = gameSkeletons.concat(
  gameHairs,
  gameFaces,
  gameCommonAnims,
  gameFaceAnims,
  gameCombineAnims,
  gameEventAnims,
  gameCostumes
);

// Add extra assets from game.
addExtraAssets(gameAssets);
sortAssets(gameAssets);

const charAssets = writable(gameAssets);

export const skeletons = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.BaseMesh)
);

export const hairs = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.HairMesh)
);

export const faces = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.FaceMesh)
);

export const commonAnims = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.CommonAnim)
);

export const faceAnims = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.FaceAnim)
);

export const combineAnims = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.CombineAnim)
);

export const eventAnims = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.EventAnim)
);

export const costumes = derived(charAssets, ($charAssets) =>
  $charAssets.filter((x) => x.assetType == AssetType.CostumeMesh)
);

export const charConfig = writable(new CharacterConfig());

export function AddAssets(assets: CharacterAsset[]) {
  charAssets.update((value) =>
    value
      .concat(assets)
      .filter((x) => Character[x.character] != undefined)
      .sort((a, b) => a.character - b.character)
  );
}

function sortAssets(assets: CharacterAsset[]) {
  assets.sort((a, b) => a.character - b.character);
}
