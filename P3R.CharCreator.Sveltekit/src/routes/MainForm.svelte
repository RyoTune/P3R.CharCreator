<script lang="ts">
  import { AddAssets, charConfig } from './ConfigStore';

  interface ImportDialog {
    name: string;
  }

  let dialog: ImportDialog | null;
  let dialogContent: string = '';

  function openImportDialog(newDialog: ImportDialog) {
    dialog = newDialog;
    dialogContent = '';
  }

  function closeImportDialog() {
    dialog = null;
    dialogContent = '';
  }

  function confirmImportDialog() {
    if (!dialogContent) {
      return;
    }

    try {
      const importData = JSON.parse(atob(dialogContent));
      if (dialog?.name === 'Import Character') {
        $charConfig = importData;
      } else if (dialog?.name == 'Import Mods') {
        AddAssets(importData);
      }

      closeImportDialog();
    } catch (error) {
      console.error(error);
    }
  }
</script>

<div class="modal" class:is-active={dialog != null}>
  <div class="modal-background"></div>
  <div class="modal-content">
    <h1 class="title">{dialog?.name}</h1>
    <textarea class="textarea block" bind:value={dialogContent} />
    <field class="field is-grouped is-pulled-right">
      <button class="button" on:click={() => closeImportDialog()}>Cancel</button>
      <button class="button is-primary" on:click={() => confirmImportDialog()}>Confirm</button>
    </field>
  </div>
  <button class="modal-close is-large" aria-label="close" on:click={() => closeImportDialog()} />
</div>
<section class="block">
  <div class="level">
    <div class="level-left">
      <div>
        <h1 class="title is-4">Import Mods</h1>
        <h1 class="subtitle is-6">Add new character assets from your mods.</h1>
      </div>
    </div>
    <div class="level-right">
      <button class="button is-info" on:click={() => openImportDialog({ name: 'Import Mods' })}
        >Import Mods</button
      >
    </div>
  </div>
  <div class="level">
    <div class="level-left">
      <div>
        <h1 class="title is-4">Import Character</h1>
        <h1 class="subtitle is-6">Import an existing character for editing.</h1>
      </div>
    </div>
    <div class="level-right">
      <button class="button is-info" on:click={() => openImportDialog({ name: 'Import Character' })}
        >Import Character</button
      >
    </div>
  </div>
</section>
<section class="content">
  <h1 class="title">Getting Started</h1>
  <ol>
    <li>In <strong>Reloaded</strong>, click on <strong>P3R Character Creator</strong>.</li>
    <li>Next, click on <strong>Open Config</strong>.</li>
    <h1 class="title is-5">Using Your Character</h1>
    <ol>
      <li>
        Customize a <strong>character</strong> by going through the various
        <strong>tabs above</strong>.
      </li>
      <li>
        Once finished, click the <strong>Copy button</strong> on the right. This will copy the character's
        data.
      </li>
      <li>
        Click on the <strong>textbox</strong> of the character's <strong>Character Data</strong>.
      </li>
      <li>Press <strong>Ctrl + A</strong> to select any existing text.</li>
      <li>Press <strong>Ctrl + V</strong> to paste your new character data.</li>
    </ol>
    <h1 class="title is-5">Importing Characters</h1>
    <ol>
      <li>
        Click on the <strong>textbox</strong> of any character's <strong>Character Data</strong> that
        you would like to edit.
      </li>
      <li>Press <strong>Ctrl + A</strong> to select all the text.</li>
      <li>Press <strong>Ctrl + C</strong> to copy the text.</li>
      <li>
        Click on <strong
          ><a
            class="has-text-info"
            href="#!"
            on:click={() => openImportDialog({ name: 'Import Character' })}>Import Character</a
          ></strong
        > and paste the text.
      </li>
    </ol>
    <h1 class="title is-5">Importing Mods</h1>
    <ol>
      <li>
        <strong>Enable</strong> any mods whose assets you want available beforehand.
        <br /><b>Supported mods:</b>
      </li>
      <ul>
        <li>P3R Character Creator <strong>asset packs</strong>.</li>
        <li>Mods using <strong>Costume Framework</strong>.</li>
        <li>The <strong>FEMC Reloaded Project</strong> (v1.0.8 last tested).</li>
      </ul>
      <li>
        Click on the <strong>textbox</strong> for <strong>Import Mods</strong>.
      </li>
      <li>Press <strong>Ctrl + A</strong> to select all the text.</li>
      <li>Press <strong>Ctrl + C</strong> to copy the text.</li>
      <li>
        Click on <strong
          ><a
            class="has-text-info"
            href="#!"
            on:click={() => openImportDialog({ name: 'Import Mods' })}>Import Mods</a
          ></strong
        > and paste the text.
      </li>
    </ol>
  </ol>
</section>
