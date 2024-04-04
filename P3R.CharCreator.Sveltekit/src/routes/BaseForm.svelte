<script lang="ts">
  import { Character } from '$lib/types/Character';
  import { FormatAssetName } from '$lib/utils/AssetUtils';
  import { skeletons, charConfig, faces, hairs } from './ConfigStore';
</script>

<h1 class="title">Base</h1>
<h2 class="subtitle">Base character stuff, like face and hair.</h2>
<p class="block">
  For the <b>best</b> results, use the <strong>same</strong> character for the
  <strong>Base Skeleton</strong>
  and <strong>Face</strong>, along with <strong>Face animations</strong>.
</p>
<form class="box columns">
  <div class="column">
    <div class="field">
      <label for="skeleton-select" class="label title is-4">Base Skeleton</label>
      <div class="control">
        <div class="select">
          <select id="skeleton-select" bind:value={$charConfig.base.baseSkeleton}>
            <option value={null}>Default</option>
            {#each $skeletons as skeleton}
              <option value={skeleton.assetPath}>{Character[skeleton.character]}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>

    <div class="field">
      <label for="hair-select" class="label title is-4">Hair</label>
      <div class="control">
        <div class="select">
          <select id="hair-select" bind:value={$charConfig.base.hair}>
            <option value={null}>Default</option>
            {#each $hairs as hair}
              <option value={hair.assetPath}>{FormatAssetName(hair)}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>
  </div>

  <div class="column">
    <div class="field">
      <label for="face-select" class="label title is-4">Face</label>
      <div class="control">
        <div class="select">
          <select id="face-select" bind:value={$charConfig.base.face}>
            <option value={null}>Default</option>
            {#each $faces as face}
              <option value={face.assetPath}>{FormatAssetName(face)}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>
  </div>
</form>
