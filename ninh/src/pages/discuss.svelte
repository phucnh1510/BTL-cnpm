<script lang="ts">
    import { navigate } from "svelte-routing";
    import * as Drawer from "$lib/components/ui/drawer";
    import Minus from "svelte-radix/Minus.svelte";
    import Plus from "svelte-radix/Plus.svelte";
    import { VisGroupedBar, VisXYContainer } from "@unovis/svelte";
    import { Button } from "$lib/components/ui/button/index.js";

    import Header from "../components/Header.svelte";

    let questions = [
        { title: "Google Online Assessment Questions", tags: ["google", "online assessment"], replies: "2.9K", views: "789.6K", created: "August 6, 2019" },
        { title: "How to write an Interview Question post", tags: [], replies: "614", views: "174.5K", created: "April 28, 2018" },
        { title: "L5 Google | Interview Exp. | Rejected", tags: ["google", "interview", "l5"], replies: "156", views: "9.1K", created: "3 days ago" },
        // Add more questions as needed
    ];

    const data = [
    {
      id: 1,
      goal: 400
    },
    {
      id: 2,
      goal: 300
    },
    {
      id: 3,
      goal: 200
    },
    {
      id: 4,
      goal: 300
    },
    {
      id: 5,
      goal: 200
    },
    {
      id: 6,
      goal: 278
    },
    {
      id: 7,
      goal: 189
    },
    {
      id: 8,
      goal: 239
    },
    {
      id: 9,
      goal: 300
    },
    {
      id: 10,
      goal: 200
    },
    {
      id: 11,
      goal: 278
    },
    {
      id: 12,
      goal: 189
    },
    {
      id: 13,
      goal: 349
    }
  ];
  const x = (d: { goal: number; id: number }) => d.id;
  const y = (d: { goal: number; id: number }) => d.goal;
 
  let goal = 350;
 
  function handleClick(adjustment: number) {
    goal = Math.max(200, Math.min(400, goal + adjustment));
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
                    <button class="discuss-new-btn">New +</button>
                    <Drawer.Root>
                        <Drawer.Trigger asChild let:builder>
                            <Button builders={[builder]} variant="outline">Open Drawer</Button>
                        </Drawer.Trigger>
                        <Drawer.Content>
                            <div class="mx-auto w-full max-w-sm" style="color: white;">
                            <Drawer.Header>
                                <Drawer.Title>Move Goal</Drawer.Title>
                                <Drawer.Description>Set your daily activity goal.</Drawer.Description>
                            </Drawer.Header>
                            <div class="p-4 pb-0" style="color: white;">
                                <div class="flex items-center justify-center space-x-2" style="color: white;">
                                <Button
                                    variant="outline"
                                    size="icon"
                                    class="h-8 w-8 shrink-0 rounded-full"
                                    on:click={() => handleClick(-10)}
                                    disabled={goal <= 200}
                                >
                                    <Minus class="h-4 w-4" />
                                    <span class="sr-only">Decrease</span>
                                </Button>
                                <div class="flex-1 text-center" style="color: white;">
                                    <div class="text-7xl font-bold tracking-tighter">
                                    {goal}
                                    </div>
                                    <div class="text-muted-foreground text-[0.70rem] uppercase">
                                    Calories/day
                                    </div>
                                </div>
                                <Button
                                    variant="outline"
                                    size="icon"
                                    class="h-8 w-8 shrink-0 rounded-full"
                                    on:click={() => handleClick(10)}
                                >
                                    <Plus class="h-4 w-4" />
                                    <span class="sr-only">Increase</span>
                                </Button>
                                </div>
                                <div class="mt-3 h-[120px]" style="color: white;">
                                <VisXYContainer {data} height={60}>
                                    <VisGroupedBar {x} {y} color="hsl(var(--primary) / 0.2)" />
                                </VisXYContainer>
                                </div>
                            </div>
                            <Drawer.Footer>
                                <Button>Submit</Button>
                                <Drawer.Close asChild let:builder>
                                <Button builders={[builder]} variant="outline">Cancel</Button>
                                </Drawer.Close>
                            </Drawer.Footer>
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