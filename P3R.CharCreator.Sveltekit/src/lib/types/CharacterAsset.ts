import type { AssetType } from './AssetType';
import type { Character } from './Character';
import type { Outfit } from './Outfit';

export interface CharacterAsset {
  character: Character;
  outfit?: Outfit;
  name: string;
  assetPath: string;
  assetType: AssetType;
}
