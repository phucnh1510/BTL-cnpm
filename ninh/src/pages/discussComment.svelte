<script>
    import Header from "../components/Header.svelte";

    let post = {
        title: "Google Online Assessment Questions",
        author: "Sithis",
        authorAvatar: "https://us-tuna-sounds-images.voicemod.net/03145e93-631a-4fc3-8d7f-8bf3f7c6276e-1699154623596.jpg", // Replace with the actual path of the user's avatar
        created: "February 6, 2021",
        replies: "2.9K",
        views: "795.1K",
        rating: "24043",
        content: {
            "US/EU": {
                "New Grad": [
                    "Min Amplitude [New Grad]",
                    "Ways to Split String [New Grad] ⭐⭐⭐",
                    "Maximum Time ⭐⭐⭐ [Intern]"
                ],
                "Intern": [
                    "Min Abs Difference of Server Loads ⭐ [Intern]",
                    "Most Booked Hotel Room ⭐⭐⭐ [Intern]",
                    "Minimum Domino Rotations For Equal Row [New Grad]"
                ],
                "General": [
                    "License Key Formatting",
                    "Unique Email Addresses",
                    "Fruit Into Baskets",
                    "Min Days to Bloom"
                ]
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
    <div class="addComment-content">
        <header class="discuss-header">
            <div class="discuss-post-info">
                <!-- User Avatar -->
                <img src={post.authorAvatar} alt="User Avatar" class="author-avatar">
                
                <!-- User Info -->
                <div class="discuss-post-meta">
                    <h1 class="discuss-title">{post.title}</h1>
                    <p class="discuss-author"><strong>{post.author}</strong> ⭐ {post.rating}</p>
                    <p class="discuss-meta">Last Edit: {post.created} | {post.views} VIEWS</p>
                </div>
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
    </div>
</main>

<style>
    .discuss-main {
        background-color: #1e2021;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 1rem;
    }
    .discuss-header {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        margin-bottom: 1rem;
    }
    .discuss-post-info {
        display: flex;
        align-items: center;
    }
    .author-avatar {
        width: 50px;
        height: 50px;
        border-radius: 50%;
        margin-right: 20px;
        object-fit: cover;
    }
    .discuss-post-meta {
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
    .discuss-title {
        font-size: 20px;
        color: white;
    }
    .discuss-author {
        font-size: 0.9rem;
        color: #9aa0a6;
    }
    .discuss-meta {
        font-size: 0.8rem;
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
        background-color: #181a1b;
        padding: 5px;
        border-radius: 8px;
    }
    .discuss-comment-box textarea {
        background-color: black;
        color: #e8eaed;
        border: 1px solid #5f6368;
        padding: 0.5rem;
        resize: none;
        border-radius: 5px;
        height: 70px;
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

    .addComment-content {
        margin: 0 auto;
        max-width: 1000px;
        background-color: #181a1b;
        padding: 15px;
        margin-top: 20px;
    }
</style>
