<script>
    import Header from "../components/Header.svelte";


    // Sample data for the ranking table
    let participants = [
        { rank: 1, name: "Neal Wu", contests: 51, flag: "🇺🇸" },
        { rank: 2, name: "灵策山艾府", contests: 239, flag: "🇨🇳" },
        { rank: 3, name: "Joshua Chen", contests: 98, flag: "🇦🇺" },
        { rank: 4, name: "何钊", contests: 143, flag: "🇨🇳" },
        { rank: 5, name: "小羊肖恩", contests: 103, flag: "🇨🇳" },
        { rank: 6, name: "SSenxhs", contests: 55, flag: "🇨🇳" },
        { rank: 7, name: "dnialh", contests: 58, flag: "🇨🇳" },
        { rank: 8, name: "fjzzq2002", contests: 22, flag: "🇨🇳" },
        { rank: 9, name: "pandaforever", contests: 40, flag: "🇨🇳" }
    ];

    let totalParticipants = 558518;
</script>

<main class="contest-main">
    <Header />


    <div class="contest-header">
        
        <h1 class="contest-title">Global Ranking</h1>
        <p class="contest-participants">Total Participants: {totalParticipants}</p>
    </div>

    <!-- Leaderboard -->
    <section class="contest-ranking">
        <ul class="contest-list">
            {#each participants as participant}
                <li class="contest-item">
                    
                    <div class="contest-name-main">
                        <span class="contest-name"> <span class="contest-rank">{participant.rank}</span>  {participant.name}</span>
                        <span class="contest-contests">{participant.contests} contests attended</span>
                    </div>
                        
                    <span class="contest-flag">{participant.flag}</span>
                </li>
            {/each}
        </ul>
    </section>
</main>

<!-- Styles for the contest ranking page -->
<style>
    .contest-main {
        background-color: #1b1d1e;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        height: 200vh;    
    }

    .contest-header {
        display: flex;
        align-items: center;
        margin-bottom: 1.5rem;
        width: 50%;
        margin: 0 auto;
        justify-content: space-between;
    }

    .contest-back {
        color: #8ab4f8;
        text-decoration: none;
        font-size: 1rem;
    }

    .contest-title {
        font-size: 30px;
        color: #9d9d92;
        font-weight: 600;
        margin: 0;
        margin-top: 5px;
    }

    .contest-participants {
        font-size: 13px;
        color: #938678;
    }

    .contest-ranking {
        margin-top: 1.5rem;
        display: flex;
        justify-content: center;
        
        
    }

    .contest-list {
        list-style: none;
        padding: 0;
        width: 50%;
    }

    .contest-item {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 1rem;
        background-color: #303134;
        margin-bottom: 0.5rem;
        border-radius: 8px;
    }

    .contest-rank {
        font-size: 16px;
        font-weight: bold;
        margin-right: 1rem;
        color: #7e989e;
    }

    .contest-name-main {
        display: flex;
        justify-content: start;
        flex-direction: column;
    }

    .contest-name {
        flex: 1;
        font-size: 16px;
        color: #ea771c;
    }

    .contest-contests {
        font-size: 12px;
        color: #9aa0a6;
        margin-right: 1rem;
    }

    .contest-flag {
        font-size: 1.5rem;
    }
</style>
