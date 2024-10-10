<script>
  import { onMount, onDestroy } from 'svelte';
  import LanguageSelector from './LanguageSelector.svelte';

  let editor;
  let monaco;  // Declare monaco at the top level so it can be used everywhere
  let selectedLanguage = 'cpp';  // Default language
  let editorValue = '';  // Variable to hold the code for the selected language

  // List of languages to pass to the LanguageSelector component
  const languages = [
    { value: 'cpp', label: 'C++', template: `class Solution {\npublic:\n    vector<int> twoSum(vector<int>& nums, int target) {\n        // Your code here\n    }\n};` },
    { value: 'javascript', label: 'Java', template: `function twoSum(nums, target) {\n  // Your code here\n}` },
    { value: 'python', label: 'Python', template: `class Solution:\n    def twoSum(self, nums: List[int], target: int) -> List[int]:\n        # Your code here\n        pass` },
    { value: 'java', label: 'Java', template: `class Solution {\n    public int[] twoSum(int[] nums, int target) {\n        // Your code here\n    }\n}` },
    { value: 'typescript', label: 'TypeScript', template: `function twoSum(nums: number[], target: number): number[] {\n  // Your code here\n}` }
  ];

  // Function to update the Monaco editor's language and value
  function updateLanguage() {
    if (monaco && editor) {
      const languageData = languages.find(lang => lang.value === selectedLanguage);
      if (languageData) {
        editorValue = languageData.template;  // Set the template for the selected language
        editor.setValue(editorValue);  // Update the editor with the new value
        monaco.editor.setModelLanguage(editor.getModel(), selectedLanguage); // Set the new language
      }
    }
  }

  onMount(async () => {
    monaco = await import('monaco-editor');  // Import Monaco asynchronously

    // Default language and value on initial load
    const initialLanguage = languages.find(lang => lang.value === selectedLanguage);
    editorValue = initialLanguage.template;

    editor = monaco.editor.create(document.getElementById('editor-container'), {
      value: editorValue,
      language: selectedLanguage,
      theme: 'vs-dark',
      automaticLayout: true,
      minimap: {
        enabled: false
      },
      scrollBeyondLastLine: false,
      fontSize: 14,
      lineNumbers: 'on'
    });



  });

  

  onDestroy(() => {
    if (editor) {
      editor.dispose();
    }
  });

  // Whenever the language changes, update the editor
  $: if (monaco && editor && selectedLanguage) {
    updateLanguage();
  }
</script>

<style>
    #editor-container {
        width: 100%;
        background-color: #1c1f20;
        border-top: transparent;
        border-radius: 10px;
        border: 1px solid ;
        height: 100%;
      
    }

    .editor-container-logo {
        width: 18px;
        height: auto;
        color: #52ed73;
    }

    .editor-container-header{
        display: flex;
        padding: 5px 0px 5px 10px;
        background-color: #1d1f20;
        border-radius: 6px;
        border: 1px solid transparent;
        margin-top: 5px;
        
    }


    .editor-container-text{
        font-weight: bold;
        padding-left: 5px;
        color: white;
        font-size: 13px;
    }

   

</style>



<div id="editor-container">
  <div class="editor-container-header">
    <p>
      <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="code" class="editor-container-logo" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512"><path fill="currentColor" d="M399.1 1.1c-12.7-3.9-26.1 3.1-30 15.8l-144 464c-3.9 12.7 3.1 26.1 15.8 30s26.1-3.1 30-15.8l144-464c3.9-12.7-3.1-26.1-15.8-30zm71.4 118.5c-9.1 9.7-8.6 24.9 1.1 33.9L580.9 256 471.6 358.5c-9.7 9.1-10.2 24.3-1.1 33.9s24.3 10.2 33.9 1.1l128-120c4.8-4.5 7.6-10.9 7.6-17.5s-2.7-13-7.6-17.5l-128-120c-9.7-9.1-24.9-8.6-33.9 1.1zm-301 0c-9.1-9.7-24.3-10.2-33.9-1.1l-128 120C2.7 243 0 249.4 0 256s2.7 13 7.6 17.5l128 120c9.7 9.1 24.9 8.6 33.9-1.1s8.6-24.9-1.1-33.9L59.1 256 168.4 153.5c9.7-9.1 10.2-24.3 1.1-33.9z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path></svg>
    </p>
    <p class="editor-container-text">Code</p>
    

</div>

<LanguageSelector bind:selectedLanguage={selectedLanguage} {languages} />

</div>



<!-- <div id="editor-container">

    <div class="editor-container-header">
        <p>
            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="code" class="editor-container-logo" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512"><path fill="currentColor" d="M399.1 1.1c-12.7-3.9-26.1 3.1-30 15.8l-144 464c-3.9 12.7 3.1 26.1 15.8 30s26.1-3.1 30-15.8l144-464c3.9-12.7-3.1-26.1-15.8-30zm71.4 118.5c-9.1 9.7-8.6 24.9 1.1 33.9L580.9 256 471.6 358.5c-9.7 9.1-10.2 24.3-1.1 33.9s24.3 10.2 33.9 1.1l128-120c4.8-4.5 7.6-10.9 7.6-17.5s-2.7-13-7.6-17.5l-128-120c-9.7-9.1-24.9-8.6-33.9 1.1zm-301 0c-9.1-9.7-24.3-10.2-33.9-1.1l-128 120C2.7 243 0 249.4 0 256s2.7 13 7.6 17.5l128 120c9.7 9.1 24.9 8.6 33.9-1.1s8.6-24.9-1.1-33.9L59.1 256 168.4 153.5c9.7-9.1 10.2-24.3 1.1-33.9z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path></svg>
        </p>
        <p class="editor-container-text">Code</p>
    </div>
   
</div> -->
