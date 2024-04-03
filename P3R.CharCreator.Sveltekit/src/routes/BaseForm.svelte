<script lang="ts">
  import { Character } from '$lib/types/Character';
  import { skeletons, charConfig, faces, hairs } from './ConfigStore';

  const playerChars = (
    Object.values(Character).filter((x) => !isNaN(Number(x))) as Character[]
  ).filter((x) => x >= Character.Player && x <= Character.Shinjiro);
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
      <label for="protag-select" class="label title is-4">Protagonist</label>
      <div class="control">
        <div class="select">
          <select id="protag-select" bind:value={$charConfig.base.character}>
            {#each playerChars as char}
              <option value={char}>{Character[char]}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>

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
  </div>

  <div class="column">
    <div class="field">
      <label for="face-select" class="label title is-4">Face</label>
      <div class="control">
        <div class="select">
          <select id="face-select" bind:value={$charConfig.base.face}>
            <option value={null}>Default</option>
            {#each $faces as face}
              <option value={face.assetPath}
                >{`${Character[face.character]}'s ${face.name} Face`}</option
              >
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
              <option value={hair.assetPath}
                >{`${Character[hair.character]}'s ${hair.name} Hair`}</option
              >
            {/each}
          </select>
        </div>
      </div>
    </div>
  </div>
</form>
