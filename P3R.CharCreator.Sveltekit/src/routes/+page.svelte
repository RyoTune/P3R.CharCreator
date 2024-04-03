<script lang="ts">
  import BaseForm from './BaseForm.svelte';
  import AnimationsForm from './AnimationsForm.svelte';
  import OutfitsForm from './OutfitsForm.svelte';
  import MainForm from './MainForm.svelte';
  import { charConfig } from './ConfigStore';

  let tab: string = 'main';
  let charTab: string = 'data';
  $: charConfigStr = JSON.stringify($charConfig, null, 2);
  $: charConfigData = btoa(charConfigStr);

  function setTab(name: string) {
    tab = name;
  }

  function copyCharData() {
    navigator.clipboard.writeText(charConfigData);
  }
</script>

<svelte:head>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@1.0.0/css/bulma.min.css" />
  <title>P3R Character Creator</title>
</svelte:head>

<section class="hero is-primary is-small">
  <div class="hero-body">
    <p class="title">P3R Character Creator</p>
    <p class="subtitle">Easily customize <strong>any</strong> character!</p>
  </div>
</section>

<section class="section">
  <div class="container">
    <div class="tabs">
      <ul>
        <li class:is-active={tab === 'main'}>
          <a href="#!" on:click={() => setTab('main')}>Main</a>
        </li>
        <li class:is-active={tab === 'base'}>
          <a href="#!" on:click={() => setTab('base')}>Base</a>
        </li>
        <li class:is-active={tab === 'animations'}>
          <a href="#!" on:click={() => setTab('animations')}>Animations</a>
        </li>
        <li class:is-active={tab === 'outfits'}>
          <a href="#!" on:click={() => setTab('outfits')}>Outfits</a>
        </li>
      </ul>
    </div>
    <div class="columns">
      <div class="column is-two-thirds">
        {#if tab == 'base'}
          <BaseForm />
        {:else if tab == 'animations'}
          <AnimationsForm />
        {:else if tab == 'outfits'}
          <OutfitsForm />
        {:else if tab == 'main'}
          <MainForm />
        {/if}
      </div>
      <div class="column">
        <h1 id="char-config-title" class="title">Your Character</h1>
        <div class="tabs">
          <ul>
            <li class:is-active={charTab === 'data'}>
              <a href="#!" on:click={() => (charTab = 'data')}>Data</a>
            </li>
            <li class:is-active={charTab === 'original'}>
              <a href="#!" on:click={() => (charTab = 'original')}>JSON</a>
            </li>
          </ul>
        </div>
        <div class="control">
          {#if charTab === 'data'}
            <p class="block">
              Copy into <strong>P3R Character Creator's</strong> config to apply.
            </p>
            <textarea class="textarea is-small" readonly bind:value={charConfigData} rows="10"
            ></textarea>
            <button id="copy-button" class="button is-primary" on:click={() => copyCharData()}
              >Copy</button
            >
          {:else}
            <p class="block">
              Read-only JSON original. Use <strong>Data</strong> with
              <strong>P3R Character Creator</strong>.
            </p>
            <textarea
              class="textarea is-small char-json"
              readonly
              bind:value={charConfigStr}
              rows="10"
            ></textarea>
          {/if}
        </div>
      </div>
    </div>
  </div>
</section>

<style>
  :global(.select, select) {
    width: 100%;
  }

  .char-json {
    text-wrap: nowrap;
  }

  #copy-button {
    width: 100%;
  }

  #char-config-title {
    margin-bottom: 0;
  }
</style>
