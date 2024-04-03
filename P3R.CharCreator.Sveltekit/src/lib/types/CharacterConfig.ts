import { Character } from './Character';
import { Outfit } from './Outfit';

export class CharacterConfig {
  constructor() {
    for (const outfit in Outfit) {
      if (!isNaN(Number(outfit))) {
        this.outfits[Number(outfit)] = null;
      }
    }
  }

  base: CharacterBase = new CharacterBase();
  animations: CharacterAnims = new CharacterAnims();
  outfits: { [id: number]: string | null } = new Object() as { [id: number]: string | null };
}

class CharacterBase {
  character: Character = Character.Player;
  baseSkeleton: string | null = null;
  hair: string | null = null;
  face: string | null = null;
}

class CharacterAnims {
  common: string | null = null;
  combine: string | null = null;
  event: string | null = null;
  face: string | null = null;
}
