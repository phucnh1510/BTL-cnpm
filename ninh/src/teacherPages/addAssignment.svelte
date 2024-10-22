<script>
    import { marked } from 'marked'; // Markdown to HTML converter
    import Header from '../components/Header.svelte';
    import { onMount } from 'svelte';
    import * as monaco from 'monaco-editor';
    import AdminHeader from '../components/AdminHeader.svelte';
    import MultiSelect from "svelte-multiselect";

    // Markdown content
    let title = '';
    let content = `Some words are *italic*, some are **bold**\n\n- lists\n- are\n- cool`;

    let problemId = '';
    
    // Dropdown data
    // let tags = [
    //     { id: 1, name: "Tag 1" },
    //     { id: 2, name: "Tag 2" },
    //     { id: 3, name: "Tag 3" }
    // ];

    let topics = [];

    let addAssignmentDifficulties = [
        { id: 1, name: "Easy" },
        { id: 2, name: "Medium" },
        { id: 3, name: "Hard" }
    ];

    let addAssignmentClasses = [
        { id: 1, name: "Class 1" },
        { id: 2, name: "Class 2" },
        { id: 3, name: "Class 3" },
    ];

    let selectedTag = ''; // Stores the selected tag
    let selectedTopic = ''; // Stores the selected topic
    let addAssignmentSelectedDifficulty = ''; // Stores the selected difficulty
    let addAssignmentSelectedClasses = []; // Stores the selected classes

    // Select all checkboxes
    let addAssignmentSelectAll = false;

    // Handle select all classes
    // const addAssignmentToggleSelectAll = () => {
    //     addAssignmentSelectAll = !addAssignmentSelectAll;
    //     addAssignmentSelectedClasses = addAssignmentSelectAll ? addAssignmentClasses.map(cls => cls.id) : [];
    // };
    //
    // // Function to toggle a single class selection
    // const addAssignmentToggleClassSelection = (classId) => {
    //     if (addAssignmentSelectedClasses.includes(classId)) {
    //         addAssignmentSelectedClasses = addAssignmentSelectedClasses.filter(id => id !== classId);
    //     } else {
    //         addAssignmentSelectedClasses.push(classId);
    //     }
    // };

    // Monaco editor variables
    let addAssignment2TestCaseEditor;
    let addAssignment2TemplateEditor;
    let addAssignment2SelectedOption = ''; // For the language dropdown

    // List of submitted assignments
    let assignments = [ ];
    let nextAssignmentId = 1;

    // Markdown conversion function
    const getMarkdown = () => {
        return marked(content);
    };

    // Initialize Monaco editors on mount
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

        const getalluserproblem = 'http://localhost:5292/api/admin/get/all-problems';
        fetch(getalluserproblem)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                assignments = data;
            });
        const get_all_topics = "http://localhost:5292/api/admin/get/all-topics";
        fetch(get_all_topics)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                topics = data;
            });

        const get_all_class = "http://localhost:5292/api/admin/get/all-class";
        fetch(get_all_class)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                addAssignmentClasses = data;
            })
    });

    // Handle form submit (e.g., when "Submit" button is clicked)
    const addAssignment2HandleSubmit = () => {
        const testCaseCode = addAssignment2TestCaseEditor.getValue();
        const templateCode = addAssignment2TemplateEditor.getValue();
        console.log('Test Case Code:', testCaseCode); // Process test case code
        console.log('Template Code:', templateCode);  // Process template code

        assignments = [
            ...assignments, 
            {
                id: nextAssignmentId++,
                title: title,
                testCase: testCaseCode,
                template: templateCode
            }
        ];
    };

    // Delete an assignment by ID
    const deleteAssignment = (problemId) => {
        assignments = assignments.filter(assignment => assignment.problemId !== problemId);
    };


</script>

<style>
    .add1 {
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

    .addAssignment2-editor-container h3, .addAssignment2-editor-box h3 {
        color: white;
        font-size: 20px;
        font-weight: bold;
    }

    .addAssignment-checkbox-container {
        margin-left: 20px;
        margin-top: 10px;
    }

    .addAssignment-checkbox-label {
        color: white;
        display: flex;
        align-items: center;
        margin-bottom: 5px;
    }

    .addAssignment-checkbox-label input {
        margin-right: 10px;
    }

    .addAssignment2-select { margin-left: 20px; background-color: #2e3236; color: white; padding: 10px; border: none; border-radius: 4px; margin-bottom: 10px; width: 200px; }

    .assign-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .assign-table-header {
        background-color: #333;
    }

    .assign-table-header-cell {
        color: white;
        padding: 10px;
        border: 1px solid #555;
        text-align: left;
    }

    .assign-table-body {
        background-color: #2e3236;
    }

    .assign-table-row {
        border: 1px solid #555;
    }

    .assign-table-cell {
        padding: 10px;
        color: white;
        border: 1px solid #555;
    }

    .assign-table-delete-button {
        background-color: red;
        color: white;
        padding: 5px 10px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

</style>

<main class="add1">
    <AdminHeader />
    <div class="addAssignment-container">
        <!-- Title Input -->
        <input style="margin-left: 20px; padding: 10px; background: #2e3236; border-radius: 4px; width: 100px" type="text" placeholder="Id" bind:value={problemId}>
        <input class="addAssignment-input-field" type="text" bind:value={title} placeholder="Enter problem title..." />

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

        <!-- Dropdowns for Tags and Topics -->
<!--        <select class="addAssignment-select" bind:value={selectedTag}>-->
<!--            <option value="">Select a tag</option>-->
<!--            {#each tags as tag}-->
<!--                <option value={tag.id}>{tag.name}</option>-->
<!--            {/each}-->
<!--        </select>-->

        <!-- Dropdown for Difficulty -->
        <select class="addAssignment-select" bind:value={addAssignmentSelectedDifficulty}>
            <option value="">Select Difficulty</option>
            {#each addAssignmentDifficulties as difficulty}
                <option value={difficulty.id}>{difficulty.name}</option>
            {/each}
        </select>

        <br>

<!--        <select class="addAssignment-select" bind:value={selectedTopic}>-->
<!--            <option value="">Select a topic</option>-->
<!--            {#each topics as topic}-->
<!--                <option value={topic.id}>{topic.name}</option>-->
<!--            {/each}-->
<!--        </select>-->
        <MultiSelect
            --sms-options-bg="#1e1e1e"
            --sms-text-color="white"
            --sms-margin="20px 0 10px 20px"
            --sms-width="400pt"
            --sms-padding="10px"
            bind:value={selectedTopic}
            options={topics.map(t => t.topicName)}
            placeholder="Select topics"
            required
        />

        <br>

        <MultiSelect
                --sms-options-bg="#1e1e1e"
                --sms-text-color="white"
                --sms-margin="0 0 30px 20px"
                --sms-width="400pt"
                --sms-padding="10px"
                bind:value={addAssignmentSelectedClasses}
                options={addAssignmentClasses.map(c => c.className)}
                placeholder="Select classes"
                required
        />

        <!-- Class Selection with Checkboxes -->
<!--        <div class="addAssignment-checkbox-container">-->
<!--            <label class="addAssignment-checkbox-label">-->
<!--                <input type="checkbox" bind:checked={addAssignmentSelectAll} on:change={addAssignmentToggleSelectAll} />-->
<!--                Select All Classes-->
<!--            </label>-->
<!--            {#each addAssignmentClasses as cls}-->
<!--                <label class="addAssignment-checkbox-label">-->
<!--                    <input -->
<!--                        type="checkbox" -->
<!--                        on:change={() => addAssignmentToggleClassSelection(cls.id)}-->
<!--                        checked={addAssignmentSelectedClasses.includes(cls.id)} -->
<!--                    />-->
<!--                    {cls.name}-->
<!--                </label>-->
<!--            {/each}-->
<!--        </div>-->
    </div>
</main>

<main>
    <div class="addAssignment2-container">
        <!-- Dropdown for Language -->
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

         <!-- Table of Submitted Assignments -->
        {#if assignments.length > 0}
            <table class="assign-table">
                <thead class="assign-table-header">
                    <tr>
                        <th class="assign-table-header-cell">Assignment ID</th>
                        <th class="assign-table-header-cell">Title</th>
                        <th class="assign-table-header-cell">Actions</th>
                    </tr>
                </thead>
                <tbody class="assign-table-body">
                    {#each assignments as assignment}
                        <tr class="assign-table-row">
                            <td class="assign-table-cell">{assignment.problemId}</td>
                            <td class="assign-table-cell">{assignment.title}</td>
                            <td class="assign-table-cell">
                                <button class="assign-table-delete-button" on:click={() => deleteAssignment(assignment.problemId)}>Delete</button>
                            </td>
                        </tr>
                    {/each}
                </tbody>
            </table>
        {/if}
    </div>
</main>
