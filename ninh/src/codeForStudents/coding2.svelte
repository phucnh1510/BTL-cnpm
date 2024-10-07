<script>
    import { onMount } from 'svelte';
    import { onDestroy } from 'svelte';

  let editor;

  onMount(async () => {
    const monaco = await import('monaco-editor');
    
    editor = monaco.editor.create(document.getElementById('editor-container'), {
      value: `class Solution {\npublic:\n    vector<int> twoSum(vector<int>& nums, int target) {\n        // Your code here\n    }\n};`,
      language: 'cpp',
      theme: 'vs-dark',  // dark theme like in the image
      automaticLayout: true,  // This makes the editor responsive to the container size
      minimap: {
        enabled: false  // Disable minimap for a cleaner interface, you can enable it if needed
      },
      scrollBeyondLastLine: false,  // Avoids extra space at the end of the code
      fontSize: 16,  // Adjust font size as needed
      lineNumbers: 'on'  // Display line numbers
    });
  });

  // Clean up when the component is destroyed
  onDestroy(() => {
    if (editor) {
      editor.dispose();
    }
  });
</script>

<style>
    #editor-container {
        width: 100%;
        background-color: #1c1f20;
        border-top: transparent;
        border-radius: 10px;
        border: 1px solid gray;
        height: 100%;
    }

    .editor-container-logo {
        width: 20px;
        height: 22px;
        color: #52ed73;
    }

    .editor-container-header{
        display: flex;
        padding: 5px 0px 5px 10px;
    }


    .editor-container-text{
        font-weight: bold;
        padding-left: 10px;
        color: white;
    }

</style>

<div id="editor-container">
    <div class="editor-container-header">
        <p>
            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="code" class="editor-container-logo" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512"><path fill="currentColor" d="M399.1 1.1c-12.7-3.9-26.1 3.1-30 15.8l-144 464c-3.9 12.7 3.1 26.1 15.8 30s26.1-3.1 30-15.8l144-464c3.9-12.7-3.1-26.1-15.8-30zm71.4 118.5c-9.1 9.7-8.6 24.9 1.1 33.9L580.9 256 471.6 358.5c-9.7 9.1-10.2 24.3-1.1 33.9s24.3 10.2 33.9 1.1l128-120c4.8-4.5 7.6-10.9 7.6-17.5s-2.7-13-7.6-17.5l-128-120c-9.7-9.1-24.9-8.6-33.9 1.1zm-301 0c-9.1-9.7-24.3-10.2-33.9-1.1l-128 120C2.7 243 0 249.4 0 256s2.7 13 7.6 17.5l128 120c9.7 9.1 24.9 8.6 33.9-1.1s8.6-24.9-1.1-33.9L59.1 256 168.4 153.5c9.7-9.1 10.2-24.3 1.1-33.9z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path></svg>
        </p>
        <p class="editor-container-text">Code</p>
    </div>
</div>
