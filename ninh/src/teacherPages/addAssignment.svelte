<script>
    import { marked } from 'marked'; // Markdown to HTML converter
    import Header from '../components/Header.svelte';
    import { onMount } from 'svelte';
    import * as monaco from 'monaco-editor';
    


    let title = '';
    let content = `Some words are *italic*, some are **bold**\n\n- lists\n- are\n- cool`; // Markdown content

        let tags = [
        { id: 1, name: "Tag 1" },
        { id: 2, name: "Tag 2" },
        { id: 3, name: "Tag 3" }
    ];

    let topics = [
        { id: 1, name: "Topic 1" },
        { id: 2, name: "Topic 2" },
        { id: 3, name: "Topic 3" }
    ];

    let categories = [
        { id: 1, name: "Category 1" },
        { id: 2, name: "Category 2" },
        { id: 3, name: "Category 3" }
    ];

    let selectedTag = '';       // Stores the selected tag
    let selectedTopic = '';     // Stores the selected topic
    let selectedCategory = '';  // Stores the selected category

    let addAssignment2Title = '';
    let addAssignment2Content = '';
    let addAssignment2SelectedOption = ''; // For your dropdown

    let addAssignment2TestCaseEditor;  // Monaco editor for the Test Case
    let addAssignment2TemplateEditor;  // Monaco editor for the Template
    

    // Markdown conversion function
    const getMarkdown = () => {
        return marked(content);   
    };

    onMount(() => {
        addAssignment2TestCaseEditor = monaco.editor.create(document.getElementById('addAssignment2-testcase-editor'), {
            value: '// Add test cases here...',
            language: 'javascript',
            theme: 'vs-dark'
        });

        addAssignment2TemplateEditor = monaco.editor.create(document.getElementById('addAssignment2-template-editor'), {
            value: '// Add templates here...',
            language: 'javascript',
            theme: 'vs-dark'
        });
    });

    // Handle form submit (e.g., when "Submit" button is clicked)
    const addAssignment2HandleSubmit = () => {
        const testCaseCode = addAssignment2TestCaseEditor.getValue();
        const templateCode = addAssignment2TemplateEditor.getValue();
        console.log('Test Case Code:', testCaseCode); // Process test case code
        console.log('Template Code:', templateCode);  // Process template code
    };


</script>

<style>
    .add1{
        border-bottom: 1px solid #555;
        
    }

    .addAssignment-container {
        margin-top: 20px;
    }

    .addAssignment-editor-container {
        display: flex;
        flex-direction: row;
        height: 80vh;
        background-color: #1c1e21;
        padding: 20px;
        gap: 20px;
    }

    .addAssignment-editor-box, .addAssignment-preview-box {
        flex: 1;
        background-color: #2e3236;
        border: 1px solid #555;
        padding: 20px;
        border-radius: 6px;
        overflow-y: auto;
    }

    .addAssignment-input-field {
        background-color: #2e3236;
        border: none;
        color: white;
        padding: 10px;
        border-radius: 4px;
        width: 700px;
        margin-bottom: 10px;
        margin-left: 20px;
    }

    .addAssignment-textarea {
        width: 100%;
        height: 80%;
        background-color: #2e3236;
        color: white;
        border: none;
        padding: 10px;
        font-family: inherit;
        font-size: 14px;
        outline: none;
        resize: none;
        box-sizing: border-box;
    }

    .addAssignment-preview-box div {
        background-color: #2e3236;
        color: white;
        padding: 10px;
        font-size: 14px;
        white-space: pre-wrap;
    }

    .addAssignment-p {
        font-size: 20px;
        color: white;
        font-weight: bold;
    }

    .addAssignment-select {
        margin-left: 20px;
        background-color: #2e3236;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 4px;
        margin-bottom: 10px;
        width: 200px;
    }

    .addAssignment2-container {
        margin-top: 20px;
    }

    .addAssignment2-editor-container {
        display: flex;
        gap: 20px;
        height: 60vh;
        background-color: #1c1e21;
        padding: 20px;
    }

    .addAssignment2-editor-box {
        flex: 1;
        background-color: #2e3236;
        border: 1px solid #555;
        padding: 20px;
        border-radius: 6px;
        overflow-y: auto;
    }

    

    .addAssignment2-select {
        margin-left: 20px;
        background-color: #2e3236;
        color: white;
        padding: 10px;
        border: none;
        border-radius: 4px;
        margin-bottom: 10px;
        width: 200px;
    }

    .addAssignment2-submit-button {
        background-color: #3a4c54;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        margin-left: 30px;
        
    }

    .addAssignment2-submit-button:hover {
        background-color: #d3d0cf;
    }

    #addAssignment2-testcase-editor,
    #addAssignment2-template-editor {
        width: 100%;
        height: 300px;
        border: 1px solid #555;
        margin-top: 10px;
    }

    .addAssignment2-editor-container h3, .addAssignment2-editor-box h3{
        color: white;
        font-size: 20px;
        font-weight: bold;
    }

</style>

<main class="add1">
    <Header />
    <div class="addAssignment-container">
        <!-- Title Input -->
        <input class="addAssignment-input-field" type="text" bind:value={title} placeholder="Enter topic title..." />

        <div class="addAssignment-editor-container">
            <!-- Markdown Editor -->
            <div class="addAssignment-editor-box">
                <h1 class="addAssignment-p">Editor</h1>
                <!-- Markdown Input Area -->
                <textarea class="addAssignment-textarea" bind:value={content}></textarea>
            </div>

            <!-- Markdown Preview -->
            <div class="addAssignment-preview-box">
                <h1 class="addAssignment-p">Preview</h1>
                <div>{@html getMarkdown(content)}</div> <!-- Render Markdown as HTML -->
            </div>
        </div>

         <select class="addAssignment-select" bind:value={selectedTag}>
            <option value="">Select a tag</option>
            {#each tags as tag}
                <option value={tag.id}>{tag.name}</option>
            {/each}
            </select>

            <select class="addAssignment-select" bind:value={selectedTopic}>
                <option value="">Select a topic</option>
                {#each topics as topic}
                    <option value={topic.id}>{topic.name}</option>
                {/each}
            </select>
    </div>
</main>

<main>
    <div class="addAssignment2-container">
        <!-- Dropdown -->
        <select class="addAssignment2-select" bind:value={addAssignment2SelectedOption}>
            <option value="">Select language</option>
            <option value="javascript">JavaScript</option>
            <option value="python">Python</option>
            <option value="cpp">C++</option>
        </select>

        <!-- Editor Container (Two Side-by-Side Boxes) -->
        <div class="addAssignment2-editor-container">
            <!-- Test Case Editor Box -->
            <div class="addAssignment2-editor-box">
                <h3>Test Case</h3>
                <div id="addAssignment2-testcase-editor"></div>
            </div>

            <!-- Template Editor Box -->
            <div class="addAssignment2-editor-box">
                <h3>Template</h3>
                <div id="addAssignment2-template-editor"></div>
            </div>
        </div>

        <!-- Submit Button -->
        <button class="addAssignment2-submit-button" on:click={addAssignment2HandleSubmit}>Submit</button>
    </div>
</main>



