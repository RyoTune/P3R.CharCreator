<script lang="ts">
  import { Character } from '$lib/types/Character';
  import { charConfig, combineAnims, commonAnims, eventAnims, faceAnims } from './ConfigStore';
</script>

<h1 class="title">Animations</h1>
<h2 class="subtitle">The animations to use, such as walking and idles.</h2>
<form class="box columns">
  <div class="column">
    <div class="field">
      <label for="common-anim" class="label title is-4">Common</label>
      <div class="control">
        <div class="select">
          <select id="common-anim" bind:value={$charConfig.animations.common}>
            <option value={null}>Default</option>
            {#each $commonAnims as anim}
              <option value={anim.assetPath}>{Character[anim.character]}</option>
            {/each}
          </select>
        </div>
      </div>
    </div>

    <div class="field">
      <label for="combine-anim" class="label title is-4">Combine</label>
      <div class="control">
        <div class="select">
          <select id="combine-anim" bind:value={$charConfig.animations.combine}>
            <option value={null}>Default</option>
            {#each $combineAnims as anim}
              <option value={anim.assetPath}>{Character[anim.character]}</option>
            {/each}</select
          >
        </div>
      </div>
    </div>
  </div>

  <div class="column">
    <div class="field">
      <label for="face-anim" class="label title is-4">Face</label>
      <div class="control">
        <div class="select">
          <select id="face-anim" bind:value={$charConfig.animations.face}>
            <option value={null}>Default</option>
            {#each $faceAnims as anim}
              <option value={anim.assetPath}>{Character[anim.character]}</option>
            {/each}</select
          >
        </div>
      </div>
    </div>

    <div class="field">
      <label for="event-anim" class="label title is-4">Event</label>
      <div class="control">
        <div class="select">
          <select id="event-anim" bind:value={$charConfig.animations.event}>
            <option value={null}>Default</option>
            {#each $eventAnims as anim}
              <option value={anim.assetPath}>{Character[anim.character]}</option>
            {/each}</select
          >
        </div>
      </div>
    </div>
  </div>
</form>
