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
    {
        title: "Google Online Assessment Questions",
        tags: ["google", "online assessment"],
        replies: "2.9K",
        views: "789.6K",
        created: "August 6, 2019",
        username: "JohnDoe",
        useravatar: "https://us-tuna-sounds-images.voicemod.net/03145e93-631a-4fc3-8d7f-8bf3f7c6276e-1699154623596.jpg" // Replace with actual path or URL
    },
    {
        title: "How to write an Interview Question post",
        tags: [],
        replies: "614",
        views: "174.5K",
        created: "April 28, 2018",
        username: "JaneSmith",
        useravatar: "https://media.tenor.com/Vlr5ep-dRXMAAAAM/ryan-gosling-blade-runner2049.gif" // Replace with actual path or URL
    },
    {
        title: "L5 Google | Interview Exp. | Rejected",
        tags: ["google", "interview", "l5"],
        replies: "156",
        views: "9.1K",
        created: "3 days ago",
        username: "MarkTech",
        useravatar: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReR6dQfi-hztvQ-tD3BnY6jXUv3n7xeALJ2g&s"
    },
    {
        title: "Facebook Online Assessment Questions",
        tags: ["facebook", "online assessment"],
        replies: "1.2K",
        views: "456.7K",
        created: "July 12",
        username: "JaneDoe",
        useravatar: "https://avatarfiles.alphacoders.com/942/94269.jpg" // Replace with actual path or URL
    },
    {
        title: "Amazon Online Assessment Questions",
        tags: ["amazon", "online assessment"],
        replies: "1.2K",
        views: "456.7K",
        created: "July 12",
        username: "JaneDoe",
        useravatar: "https://static.wixstatic.com/media/02296c_5c4d3d46c5b2490295cae71eba04cdc4~mv2.jpeg/v1/fill/w_320,h_400,fp_0.50_0.50,q_90/02296c_5c4d3d46c5b2490295cae71eba04cdc4~mv2.jpeg"
    },
    {
        title: "Facebook Online Assessment Questions",
        tags: ["facebook", "online assessment"],
        replies: "1.2K",
        views: "456.7K",
        created: "July 12",
        username: "JaneDoe",
        useravatar: "https://avatarfiles.alphacoders.com/942/94269.jpg" // Replace with actual path or URL
    },{
        title: "Facebook Online Assessment Questions",
        tags: ["facebook", "online assessment"],
        replies: "1.2K",
        views: "456.7K",
        created: "July 12",
        username: "JaneDoe",
        useravatar: "https://avatarfiles.alphacoders.com/942/94269.jpg" // Replace with actual path or URL
    },
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

    import Calendar from "svelte-radix/Calendar.svelte";
    import EnvelopeClosed from "svelte-radix/EnvelopeClosed.svelte";
    import Face from "svelte-radix/Face.svelte";
    import Gear from "svelte-radix/Gear.svelte";
    import Person from "svelte-radix/Person.svelte";
    import Rocket from "svelte-radix/Rocket.svelte";
    
    import * as Command from "$lib/components/ui/command/index.js";

</script>

<main class="discuss-main">
    <Header /> 

    <div class="disc-content">
        <div class="left-disc">
            <header>
                <div class="discuss-nav">
                    <button class="discuss-nav-button active">All Interview Questions</button>
                    <button class="discuss-nav-button">System Design</button>
                    <button class="discuss-nav-button">Operating System</button>
                    <button class="discuss-nav-button">Object-Oriented Design</button>
                </div>
                <div class="discuss-sort-options">
                    <div class="left-sort">
                        <button class="left-sort-button active">Hot</button>
                        <button class="left-sort-button">Newest to Oldest</button>
                        <button class="left-sort-button">Most Votes</button>
                    </div>
                    <div>
                        <input type="text" placeholder="Search topics or comments..."/>
                    

                        <Drawer.Root>
                            <!-- Trigger the drawer and set up the editor when it opens -->
                        
                                <Drawer.Trigger on:click={handleDrawerOpen}><p class="drawer-trigger">New +</p></Drawer.Trigger>
                                
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
                        <div class="discuss-post-details">
                            <img src={question.useravatar} alt="User Avatar" class="user-avatar">
                            <div class="discuss-title-and-tags">
                                <div class="discuss-title-container">
                                    <button class="discuss-post-title" on:click={() => navigate("/discussComment")}>
                                        <h2>{question.title}</h2>
                                        <p class="discuss-created-info">Created by {question.username} on {question.created}</p>
                                    </button>
                                    <!-- Tags moved to the right side of the title -->
                                    <div class="discuss-tags">
                                        {#each question.tags as tag}
                                            <span class="discuss-tag">{tag}</span>
                                        {/each}
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="discuss-metadata">
                            <span class="discuss-replies">⬆ {question.replies}</span>
                            <span class="discuss-views">👁 {question.views}</span>
                        </div>
                    </article>

                {/each}
            </section>
        </div>

        <div class="right-disc">
            <h2>Tags</h2>
            <div class="tag-search-container">
                <input type="text" placeholder="Search for tags..." class="tag-search-input" />
                
            </div>
            <div class="tag-list">
                <!-- Example tags, replace with actual dynamic data -->
                <div class="tag-item">
                    <span class="tag-name">google</span>
                    <span class="tag-count">2369</span>
                </div>
                <div class="tag-item">
                    <span class="tag-name">amazon</span>
                    <span class="tag-count">2122</span>
                </div>
                <div class="tag-item">
                    <span class="tag-name">facebook</span>
                    <span class="tag-count">1201</span>
                </div>

                <div class="tag-item">
                    <span class="tag-name">interview</span>
                    <span class="tag-count">2369</span>
                </div>
                <div class="tag-item">
                    <span class="tag-name">microsoft</span>
                    <span class="tag-count">2122</span>
                </div>
                <div class="tag-item">
                    <span class="tag-name">meta</span>
                    <span class="tag-count">1201</span>
                </div>
                
                <!-- Add more tags as needed -->
            </div>
        </div>


    </div>    
</main>



<style>
    .discuss-main {
        background-color: #1e2021;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 1rem;
        height: 200vh;
    }


    header {
        display: flex;
        flex-direction: column;
        margin-bottom: 1rem;
        
    }

    .discuss-nav {
        display: flex;
        gap: 1rem;
        margin-top: 5vh;
        border-bottom: 1px solid gray;
        background-color: #181a1b;
        padding: 5px;
        height: 50px;
    }

    .discuss-nav-button {
        background: none;
        color: #a49d94;
        border: none;
        cursor: pointer;
        font-size: 18px;
        font-weight: 550;
        margin-bottom: 0px;
        
    }

    .discuss-nav-button:nth-child(1) {
        margin-left: 30px;
    }

    .discuss-nav-button.active {
        color: white;
    }


    .discuss-sort-options {
        display: flex;
        align-items: center;
        gap: 1rem;
        
        justify-content: space-between;
        padding: 15px 0 0px 0;
        background-color: #201c1c;
    }

    .discuss-sort-options input {
        background-color: black;
        border: none;
        padding: 7px;
        color: #524f4a;
        border-radius: 5px;
        font-size: 12px;
        width: 190px;
    }

    .left-sort {
        display: flex;
        gap: 1rem;
    }

    .left-sort-button{
        font-size: 12px;
        color: #535250;
    }

    .left-sort-button:nth-child(1) {
        margin-left: 30px;
    }

    .left-sort-button.active{
        color: #beb8b0;
    }


    .discuss-question-list {
        display: flex;
        flex-direction: column;
        gap: 2px;
        background-color: #1e2021;
    }
    .discuss-question-item {
        background-color: #181a1b;
        padding: 1rem;
        border-radius: 8px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
    .discuss-post-title h2 {
        margin: 0;
        font-size: 18px;
        color: white;
        
    }
    .discuss-post-title .discuss-created-info {
        font-size: 0.8rem;
        color: #9aa0a6;
    }
    .discuss-tags .discuss-tag {
        background-color: #1b1d1e;
        padding: 0.2rem 0.5rem;
        border-radius: 3px;
        margin-right: 0.5rem;
        font-size: 0.85rem;
        color: #b4b2a3;
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

.discuss-title-and-tags {
    display: flex;
    justify-content: space-between; /* Pushes title left and tags right */
    align-items: center;
    width: 100%;
}

/* Container for question title and metadata (left side) */
.discuss-title-container {
    flex: 1;
    display: flex;
    justify-content: space-between;
    
}

/* Styling for the tags to appear on the right side */
.discuss-tags {
    margin-left: 12px; /* Pushes the tags to the far right */
    display: flex;
    
    margin-bottom: 15px;
}

/* Adjust button styling to avoid overflow */
.discuss-post-title {
    text-align: left;
    flex: 1;
    
}

/* Styling for the post container */
.discuss-post-details {
    display: flex;
    align-items: center;
}

.user-avatar {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    margin-right: 10px;
    object-fit: cover;
}

.drawer-trigger{
    color: #e8eaed;
    font-size: 14px;
    cursor: pointer;
    background-color: #3c4e57;
    padding: 5px;
    border-radius: 5px;
    padding-right: 10px;
}

.disc-content {
    display: flex;
    justify-content: center;
    height: 100vh;
}

.left-disc {
    height: 100vh;
    flex: 50%;
}

.right-disc {
    width: 20%;
    background-color: #181a1b;
    padding: 1rem;
    border-radius: 8px;
    color: #e8eaed;
    height: fit-content;
    margin-top: 50px;
}

.right-disc h2 {
    font-size: 16px;
    margin-bottom: 1rem;
    background-color: #181a1b;
    border-bottom: 1px solid gray;
}

.tag-search-container {
    display: flex;
    align-items: center;
    margin-bottom: 1rem;
}

.tag-search-input {
    flex: 1;
    padding: 5px;
    background-color: black;
    border: 1px solid #5f6368;
    border-radius: 4px;
    color: #e8eaed;
}

.tag-search-input::placeholder {
    color: gray;
}

.tag-list {
    display: flex;
    flex-wrap: wrap;
    gap: 0.5rem;
}

.tag-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background-color: #303134;
    padding: 5px;
    border-radius: 4px;
    align-items: center;
    
}

.tag-name {
    color: white;
    font-size: 12px;
    padding-right: 10px;
}

.tag-count {
    color: #b4b2a3;
    font-size: 12px; 
}


</style>