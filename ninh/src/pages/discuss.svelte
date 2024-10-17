<script lang="ts">
    import { navigate } from "svelte-routing";
    import * as Drawer from "$lib/components/ui/drawer";
    import { Editor } from '@tiptap/core';
    import StarterKit from '@tiptap/starter-kit';
    import Bold from '@tiptap/extension-bold';
    import Italic from '@tiptap/extension-italic';

    import Code from '@tiptap/extension-code';
    import BulletList from '@tiptap/extension-bullet-list';
    import OrderedList from '@tiptap/extension-ordered-list';
    import Link from '@tiptap/extension-link';
    import Image from '@tiptap/extension-image';



    import { onMount } from 'svelte';
    import Header from "../components/Header.svelte";

    let questions = [
        { title: "Google Online Assessment Questions", tags: ["google", "online assessment"], replies: "2.9K", views: "789.6K", created: "August 6, 2019" },
        { title: "How to write an Interview Question post", tags: [], replies: "614", views: "174.5K", created: "April 28, 2018" },
        { title: "L5 Google | Interview Exp. | Rejected", tags: ["google", "interview", "l5"], replies: "156", views: "9.1K", created: "3 days ago" },
    ];

    let editor; // This will hold our TipTap editor instance
    let editorElement; // Reference to the editor DOM element

    function destroyEditor() {
        // Ensure we clean up any existing editor instance
        if (editor) {
            console.log('Destroying previous editor instance');
            editor.destroy();
            editor = null;
        }
    }

    function initializeEditor() {
        destroyEditor();

        // Log whether editorElement is found and initialize the editor
        console.log('Editor element:', editorElement);
        if (editorElement) {
            editor = new Editor({
                element: editorElement,
                extensions: [
                    StarterKit,
                    Bold,
                    Italic,
                    Code,
                    BulletList,
                    OrderedList,
                    Link,
                    Image,
                ],
                content: '<p style="border: none;" >Start writing here...</p>',
            });
            console.log('Editor initialized:', editor);
        } else {
            console.log('Editor element is not available');
        }
    }

    function handleDrawerOpen() {
        // Delay the initialization slightly to make sure the DOM is ready
        setTimeout(() => {
            console.log("Drawer opened, initializing editor...");
            initializeEditor();
        }, 100); // Adjust the delay as needed
    }

    function toggleBold() {
        editor.chain().focus().toggleBold().run();
    }

    function toggleItalic() {
        editor.chain().focus().toggleItalic().run();
    }

    function toggleCode() {
        editor.chain().focus().toggleCode().run();
    }

    function toggleHeader() {
        editor.chain().focus().toggleHeading({ level: 2 }).run();
    }

    function insertLink() {
        const url = prompt('Enter a link:');
        editor.chain().focus().setLink({ href: url }).run();
    }

    function insertImage() {
        const url = prompt('Enter an image URL:');
        editor.chain().focus().setImage({ src: url }).run();
    }



</script>

<main class="discuss-main">
    <Header /> 

    <div class="left-disc">
        <header>
            <div class="discuss-nav">
                <button>All Interview Questions</button>
                <button>System Design</button>
                <button>Operating System</button>
                <button>Object-Oriented Design</button>
            </div>
            <div class="discuss-sort-options">
                <div class="left-sort">
                    <button>Hot</button>
                    <button>Newest to Oldest</button>
                    <button>Most Votes</button>
                </div>
                <div>
                    <input type="text" placeholder="Search topics or comments..."/>
                  

                    <Drawer.Root>
                        <!-- Trigger the drawer and set up the editor when it opens -->
                        <Drawer.Trigger on:click={handleDrawerOpen}>New +</Drawer.Trigger>

                        <Drawer.Content>
                            <div class="drawer-discuss">
                                <div class="discuss-title-container">  
                                    <div>
                                        <input type="text" class="discuss-title" placeholder="Enter topic here...">
                                    </div> 
                                    
                                    <div>
                                        <Drawer.Close> <button class="title-close">Close</button> </Drawer.Close>
                                        <button class="discuss-new-btn1">Post ✈</button>
                                    </div>
                                    
                                </div>

                                <div class="toolbar">
                                    <button on:click={toggleBold}><b>B</b></button>
                                    <button on:click={toggleItalic}><i>I</i></button>
                                    <button on:click={toggleHeader}>H</button>
                                    <div class="toolbar-separator"></div>
                                    <button on:click={toggleCode}><code>&lt;/&gt;</code></button>
                                    <button on:click={toggleBold}><p class="fa fa-list-ul"></p></button>
                                    <button on:click={toggleBold}><p class="fa fa-list-ol"></p></button>
                                    <div class="toolbar-separator"></div>
                                    <button on:click={insertLink}>🔗</button>
                                    <button on:click={insertImage}>🖼️</button>
                                </div>

                                <!-- TipTap Editor Inside Drawer -->
                                <div bind:this={editorElement} id="editor" class="tiptap-editor"></div>
                            </div>
                        </Drawer.Content>
                    </Drawer.Root>
                </div>
            </div>
        </header>

        <section class="discuss-question-list">
            {#each questions as question}
                <article class="discuss-question-item">
                    <button class="discuss-post-title" on:click={() => navigate("/discussComment")}>
                        <h2>{question.title}</h2>
                        <p class="discuss-created-info">Created: {question.created}</p>
                    </button>
                    <div class="discuss-tags">
                        {#each question.tags as tag}
                            <span class="discuss-tag">{tag}</span>
                        {/each}
                    </div>
                    <div class="discuss-metadata">
                        <span class="discuss-replies">⬆ {question.replies}</span>
                        <span class="discuss-views">👁 {question.views}</span>
                    </div>
                </article>
            {/each}
        </section>
    </div>
</main>



<style>
    .discuss-main {
        background-color: #1e2021;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 1rem;
        height: 100vh;
    }

    .left-disc {
        width: 60%;
        margin: 0 auto;
    }

    header {
        display: flex;
        flex-direction: column;
        margin-bottom: 1rem;
        
    }
    .discuss-nav {
        display: flex;
        gap: 1rem;
        padding-top: 5vh;
    }
    .discuss-nav button {
        background: none;
        color: #bdc1c6;
        border: none;
        cursor: pointer;
        font-size: 1rem;
    }

    .discuss-sort-options {
        display: flex;
        align-items: center;
        gap: 1rem;
        margin-top: 1rem;
        justify-content: space-between;
    }
    .discuss-sort-options input {
        background-color: #303134;
        border: none;
        padding: 0.5rem;
        color: white;
        border-radius: 5px;
    }

    .discuss-question-list {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }
    .discuss-question-item {
        background-color: #303134;
        padding: 1rem;
        border-radius: 8px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .discuss-post-title h2 {
        margin: 0;
        font-size: 1.25rem;
        color: #8ab4f8;
    }
    .discuss-post-title .discuss-created-info {
        font-size: 0.8rem;
        color: #9aa0a6;
    }
    .discuss-tags .discuss-tag {
        background-color: #5f6368;
        padding: 0.2rem 0.5rem;
        border-radius: 3px;
        margin-right: 0.5rem;
        font-size: 0.85rem;
    }
    .discuss-metadata {
        display: flex;
        gap: 1rem;
    }
    .discuss-metadata span {
        font-size: 0.9rem;
    }

    .drawer-discuss {
        color: white;
        background-color: black;
    }

  /* Container for the whole editor (toolbar + text area) */

    /* Toolbar styling */
    .toolbar {
        display: flex;
        padding-top: 10px;
        padding-bottom: 10px;
        border-bottom: 1px solid #444;
        margin-bottom: 10px;
        margin-left: 20px;
        margin-right: 20px;
    }

/* Buttons in the toolbar */
.toolbar button {
    background: none;
    border: none;
    color: #ccc;
    font-size: 17px;
    cursor: pointer;
    padding: 5px 10px 5px 5px; 
}

.toolbar button:hover {
    color: #fff;
}

/* Separator in the toolbar */
.toolbar-separator {
    border-left: 1px solid #444;
    height: 24px;
    margin: 0 8px;
}

/* Text editor area */
#editor {
    background-color: black;
    color: #ddd;
    padding: 15px;
    height: 300px;
    overflow-y: auto;
    font-family: 'Courier New', Courier, monospace;
    font-size: 14px;
    line-height: 1.5;
    border-radius: 4px;
    border: 1px solid #444;
    outline: none;
    margin-left: 20px;
    margin-right: 20px;
    margin-bottom: 20px;
}

#editor:focus {
    border: none;
    outline: none; /* Remove border when the editor is focused */
}


/* Styling for buttons/icons in the toolbar */
button i, .toolbar button {
    color: #aaa;
}

button i:hover, .toolbar button:hover {
    color: #fff;
}

.discuss-title {
    background-color: black; 
    color: #e8eaed; 
    border: 1px solid #5f6368;
    padding: 10px 15px; 
    font-size: 13px; 
    width: 500px; 
    border-radius: 4px; 
    outline: none; 
    box-sizing: border-box; 
    
}

/* Placeholder text styling */
.discuss-title::placeholder {
    color: #9aa0a6; /* Light gray placeholder text */
}

/* Focus state styling */
.discuss-title:focus {
    border: 1px solid #8ab4f8; /* Change border color when focused */
    outline: none; /* No additional outline on focus */
   
}

.discuss-title-container{
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-left: 20px;
    margin-right: 20px;
}

.title-close {
    background-color: black;
    color: #e8eaed;
    padding: 0.5rem 1rem;
    border-radius: 5px;
    cursor: pointer;
    margin-right: 20px;
    border: 1px solid #5f6368;
}

.title-close:hover {
    background-color: #5f6368;
}

.discuss-new-btn1{
    background-color: #3b4d56;
    color: #e8eaed;
    padding: 0.5rem 10px;
    border-radius: 5px;
    cursor: pointer;
    margin-right: 20px;
    border: 1px solid #5f6368;
    width: 80px;
    font-weight: 600;
}

.discuss-new-btn1:hover {
    background-color: #5f6368;
}

</style>