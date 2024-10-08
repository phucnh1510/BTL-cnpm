<script>
  export let selectedLanguage;
  export let languages = [];

  // Function to notify the parent component about the language change
  function onChange(event) {
    selectedLanguage = event.target.value;
  }
</script>

<style>
  select {
    padding: 5px;
    font-size: 14px;
    border-radius: 5px;
    background-color: #333;
    color: white;
    border: 1px solid gray;
  }

  .language-selector {
    display: flex;
    align-items: center;
    padding-right: 10px;
  }

  label {
    color: white;
    margin-right: 10px;
  }
</style>

<div class="language-selector">
  <label for="language">Language:</label>
  <select id="language" bind:value={selectedLanguage} on:change={onChange}>
    {#each languages as { value, label }}
      <option value={value}>{label}</option>
    {/each}
  </select>
</div>