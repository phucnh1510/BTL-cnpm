<script>
    import { resultData } from '../store/store.js';

    let data;
    $: data = $resultData;

    // Update to check for "Compile error" in the result field
    function hasCompileError() {
        return data && data.result && data.result.includes("Compile error");
    }
</script>

<main class="result-main">

    {#if data}
        <p class="{hasCompileError() ? 'error-background' : 'success-background'}">
            {JSON.stringify(data, null, 2)}
        </p>
        
    {:else}
        <p>No result data available.</p>
    {/if}
</main>

<style>
    .result-main {
        height: 100%;
        background-color: #1e1e1e;
        font-family: Menlo, sans-serif;
        display: flex;
        flex-direction: column;
    }

    /* Define the class for when there's a compile error */
    .error-background {
        background-color: #362b2a;
        color: #dd5044; /* Optional: to make text stand out */
    }

    /* Define the class for success or no error */
    .success-background {
        background-color: green;
        color: white; /* Optional: adjust text color */
    }

    .error-background , .success-background {
        width: 80%;
        border-radius: 5px;
        margin: 0 auto;
        margin-top: 50px;

    }


</style>
