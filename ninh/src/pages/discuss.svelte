<script>
     import { navigate } from "svelte-routing";

    import Header from "../components/Header.svelte";

    let questions = [
        { title: "Google Online Assessment Questions", tags: ["google", "online assessment"], replies: "2.9K", views: "789.6K", created: "August 6, 2019" },
        { title: "How to write an Interview Question post", tags: [], replies: "614", views: "174.5K", created: "April 28, 2018" },
        { title: "L5 Google | Interview Exp. | Rejected", tags: ["google", "interview", "l5"], replies: "156", views: "9.1K", created: "3 days ago" },
        // Add more questions as needed
    ];
</script>

<main class="discuss-main">
    <Header /> 

    <header>
        <div class="discuss-nav">
            <button>All Interview Questions</button>
            <button>System Design</button>
            <button>Operating System</button>
            <button>Object-Oriented Design</button>
        </div>
        <div class="discuss-sort-options">
            <button>Hot</button>
            <button>Newest to Oldest</button>
            <button>Most Votes</button>
            <input type="text" placeholder="Search topics or comments..."/>
            <button class="discuss-new-btn">New +</button>
        </div>
    </header>

    <section class="discuss-question-list">
        {#each questions as question}
            <article class="discuss-question-item">
                <button class="discuss-post-title" on:click={() => navigate("/discussComment")}>
                    <h2>{question.title}</h2>
                    <p class="discuss-created-info">Created: {question.created}</p>
                </button   >
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
</main>

<style>
    .discuss-main {
        background-color: #202124;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 1rem;
        height: 100vh;
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
    }
    .discuss-sort-options input {
        background-color: #303134;
        border: none;
        padding: 0.5rem;
        color: white;
        border-radius: 5px;
    }
    .discuss-new-btn {
        background-color: #3c4043;
        color: white;
        padding: 0.5rem 1rem;
        border-radius: 5px;
        cursor: pointer;
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
</style>