
<script>
    import TopicHeader from "../components/TopicHeader.svelte";

    const questions = {
        id: 1,
        title: "Two Sum",
        difficulty: "Easy",
        description: `
            Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
            You may assume that each input would have exactly one solution, and you may not use the same element twice.
            <br>
            You can return the answer in any order.
        `,
        examples: [
            {
                input: "nums = [2,7,11,15], target = 9",
                output: "[0, 1]",
                explanation: "Because nums[0] + nums[1] == 9, we return [0, 1]."
            },
            {
                input: "nums = [3,2,4], target = 6",
                output: "[1, 2]"
            },
            {
                input: "nums = [3,3], target = 6",
                output: "[0, 1]"
            }
        ],
        constraints: [
            "2 <= nums.length <= 10^4",
            "-10^9 <= nums[i] <= 10^9",
            "-10^9 <= target <= 10^9",
            "Only one valid answer exists."
        ]     
    };

        let difficultyClass;
        if (questions.difficulty === "Easy") {
            difficultyClass = "text-easy";
        } else if (questions.difficulty === "Medium") {
            difficultyClass = "text-medium";
        } else if (questions.difficulty === "Hard") {
            difficultyClass = "text-hard";
        }

</script>

<main class = "code1-main">

    <article class="coding1-article">
    <h1 class="coding1-title">{questions.id} . {questions.title}</h1>
    <p class={`coding1-difficulty ${difficultyClass}`}>{questions.difficulty}</p>
    <p class="coding1-description">{@html  questions.description}</p>

    
    {#each questions.examples as example, index}
        <div class="coding1-example">
            <h3 class="coding1-example-title">Example {index + 1}:</h3>
            <p class="coding-1-input" ><strong>Input:</strong> {example.input}</p>
            <p class="coding-1-input" ><strong>Output:</strong> {example.output}</p>
            {#if example.explanation}
                <p class="coding-1-input"><strong>Explanation:</strong> {example.explanation}</p>
            {/if}
        </div>
    {/each}

    <h2 class="coding1-constraints-title">Constraints:</h2>
    <ul class="coding1-constraints-list">
        {#each questions.constraints as constraint}
            <li class="coding1-constraint">{constraint}</li>
        {/each}
    </ul>
</article>

</main>



<style>
    .code1-main {
        background-color: #1d1f20;
        color: white;
        border: 0px solid gray;
        border-radius: 0px ;
        height: 100%;
        padding: 20px;
        position: relative;
    }

    .coding1-title{
        font-size: 1.5rem;
        font-weight: bold;
        padding: 1vh 0;
        padding-top: 0px;
    }

    .coding1-difficulty {
        font-size: 12px;
        font-weight: 100;
        border: 1px solid black;
        display: inline-block;
        background-color: #1d1f20;
        padding: 2px 10px;
        border-radius: 12px;
    }

    .coding1-description {
        font-size: 0.875rem;
        padding-top: 1.5vh;
        padding-bottom: 5vh;
        line-height: 35px;
    }

    .coding-1-input{
        margin-left: 20px;
        font-size: 14px;
        color: #979695;
    }

    .coding-1-input strong{
        color: white;
        padding-right: 5px;
    }

    .coding1-example-title{
        font-weight: 500;
        padding: 10px 0px;
    }

    .coding1-constraints-title{
        padding-top: 7vh;
        
    }

    .coding1-constraints-list{
        margin-left: 20px;
        font-size: 14px;
        color: #979695;
        padding-top: 10px;
    
    }

    .coding1-constraint{
        padding: 2px 0;
    }

    .coding1-constraints-list li::before {
        content: '•'; /* Add bullet point */
        color: white; /* Set bullet point color */
        font-weight: bold; /* Make bullet point bold */
        display: inline-block; /* Ensure it behaves like a bullet */
        width: 1em; /* Space between bullet and text */
        margin-left: -1em; /* Align bullet with text */
    }

    .coding1-constraints-list{
        margin-left: 20px;
        font-size: 14px;
        color: #979695;
        padding-top: 10px;
    
    }

    .coding1-constraints-list li:last-child {
        color: white /* Set different text color for last child */
    }

</style>

