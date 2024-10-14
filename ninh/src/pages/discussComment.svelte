<script>
    import Header from "../components/Header.svelte";

    let post = {
        title: "Google Online Assessment Questions",
        author: "Sithis",
        created: "February 6, 2021",
        replies: "2.9K",
        views: "789.6K",
        content: {
            "US/EU": {
                "New Grad": ["Min Amplitude", "Ways to Split String", "Maximum Time"],
                "Intern": ["Min Abs Difference of Server Loads", "Most Booked Hotel Room", "Minimum Domino Rotations"],
                "General": ["License Key Formatting", "Unique Email Addresses"]
            },
            "Singapore": {
                "Intern": ["Greatest Common Divisor", "Relative Sort"],
                "New Grad": ["Delayed Projects"]
            },
            "Tokyo": {
                "Intern": ["Pizza Shop", "Min Distance To The Farthest Node"]
            }
        }
    };

    let newComment = ""; // Holds the text from the textarea
    let comments = [
        { text: "This is the first comment.", author: "User1", created: "2 hours ago" },
        { text: "Another comment here.", author: "User2", created: "1 hour ago" }
    ]; // Existing comments

    let showComments = false;

    // Add the comment to the list of comments
    function postComment() {
        if (newComment.trim() !== "") {
            // Add the new comment to the comments array
            comments = [...comments, { text: newComment, author: "Anonymous", created: "Just now" }];
            // Clear the textarea
            newComment = "";
        }
    }

    function toggleComments() {
        showComments = !showComments;
    }

    // Function to handle textarea input
    function handleInput(event) {
        newComment = event.target.value;
    }
</script>

<main class="discuss-main">
    <Header />

    <header class="discuss-header">
        <div class="discuss-post-info">
            <h1 class="discuss-title">{post.title}</h1>
            <p class="discuss-author">Posted by {post.author}</p>
            <p class="discuss-created">Last Edit: {post.created}</p>
            <p class="discuss-meta">Replies: {post.replies} | Views: {post.views}</p>
        </div>
    </header>

    <section class="discuss-content">
        {#each Object.entries(post.content) as [region, categories]}
            <h2 class="discuss-region">{region}</h2>
            {#each Object.entries(categories) as [category, topics]}
                <h3 class="discuss-category">{category}</h3>
                <ul class="discuss-topic-list">
                    {#each topics as topic}
                        <li class="discuss-topic">{topic}</li>
                    {/each}
                </ul>
            {/each}
        {/each}
    </section>

    <!-- Comment Input Box -->
    <div class="discuss-comment-box">
        <textarea
            on:change={handleInput}
            placeholder="Type comment here... (Markdown is supported)">
            {newComment}
        </textarea>
        <button class="discuss-post-btn" on:click={postComment} disabled={newComment.trim() === ""}>Post</button>
    </div>

    <!-- Toggle Comments Button -->
    <button class="discuss-show-comments-btn" on:click={toggleComments}>
        {#if showComments}
            Hide Comments
        {:else}
            Show Comments
        {/if}
    </button>

    <!-- Comments Section -->
    {#if showComments}
        <section class="discuss-comments">
            {#each comments as comment}
                <div class="discuss-comment">
                    <p><strong>{comment.author}</strong> - {comment.created}</p>
                    <p>{comment.text}</p>
                </div>
            {/each}
        </section>
    {/if}
</main>

<style>
    .discuss-main {
        background-color: #202124;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 1rem;
    }
    .discuss-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 1rem;
    }
    .discuss-title {
        font-size: 1.5rem;
        color: #8ab4f8;
    }
    .discuss-author,
    .discuss-created,
    .discuss-meta {
        font-size: 0.9rem;
        color: #9aa0a6;
    }
    .discuss-content {
        margin-top: 1rem;
    }
    .discuss-region {
        font-size: 1.2rem;
        margin-top: 1.5rem;
        color: #e8eaed;
    }
    .discuss-category {
        font-size: 1.1rem;
        margin-top: 1rem;
        color: #bdc1c6;
    }
    .discuss-topic-list {
        list-style: none;
        padding-left: 1rem;
    }
    .discuss-topic {
        color: #9aa0a6;
        margin-bottom: 0.5rem;
    }

    /* Comment Box Styling */
    .discuss-comment-box {
        display: flex;
        flex-direction: column;
        margin-top: 1.5rem;
        background-color: #303134;
        padding: 1rem;
        border-radius: 8px;
    }
    .discuss-comment-box textarea {
        background-color: #303134;
        color: #e8eaed;
        border: 1px solid #5f6368;
        padding: 0.5rem;
        resize: none;
        border-radius: 5px;
        height: 100px;
        margin-bottom: 0.5rem;
    }
    .discuss-post-btn {
        background-color: #3c4043;
        color: white;
        padding: 0.5rem 1rem;
        border-radius: 5px;
        cursor: pointer;
        align-self: flex-end;
        border: none;
        opacity: 0.8;
        transition: opacity 0.2s ease;
    }
    .discuss-post-btn:disabled {
        opacity: 0.5;
        cursor: not-allowed;
    }
    .discuss-show-comments-btn {
        background-color: #3c4043;
        color: white;
        padding: 0.5rem 1rem;
        border-radius: 5px;
        cursor: pointer;
        margin-top: 1rem;
        border: none;
        transition: background-color 0.3s ease;
    }
    .discuss-show-comments-btn:hover {
        background-color: #4a4d52;
    }

    /* Comments Section Styling */
    .discuss-comments {
        background-color: #303134;
        padding: 1rem;
        border-radius: 8px;
        margin-top: 1rem;
    }
    .discuss-comment {
        margin-bottom: 1rem;
        border-bottom: 1px solid #5f6368;
        padding-bottom: 0.5rem;
    }
    .discuss-comment p {
        margin: 0;
        color: #bdc1c6;
    }
</style>
