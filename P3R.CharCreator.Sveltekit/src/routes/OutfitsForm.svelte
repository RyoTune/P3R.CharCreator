<script lang="ts">
  import { Character } from '$lib/types/Character';
  import { FormatAssetName } from '$lib/utils/AssetUtils';
  import { charConfig, costumes, gameCostumes } from './ConfigStore';
  $: outfitEntries = gameCostumes.filter(
    (x) => x.character == $charConfig.base.character && x.outfit != undefined
  );
</script>

<h1 class="title">Outfits</h1>
<h2 class="subtitle">
  Pick and choose what outfits you want to use <strong>in-place</strong> of existing outfits.
</h2>

<div class="box">
  {#each outfitEntries as entry}
    <div class="field">
      <label for={`outfit-${entry.outfit}`} class="label title is-4">{entry.name}</label>
      <div class="control">
        <div class="select">
          <select id={`outfit-${entry.outfit}`} bind:value={$charConfig.outfits[entry.outfit ?? 0]}>
            <option value={null}>Default</option>
            {#each $costumes as costume}
              <option value={costume.assetPath}>{FormatAssetName(costume)}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>
  {/each}
</div>
