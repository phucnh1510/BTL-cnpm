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
                    <span class="contest-rank">{participant.rank}</span>
                    <span class="contest-name">{participant.name}</span>
                    <span class="contest-contests">{participant.contests} contests attended</span>
                    <span class="contest-flag">{participant.flag}</span>
                </li>
            {/each}
        </ul>
    </section>
</main>

<!-- Styles for the contest ranking page -->
<style>
    .contest-main {
        background-color: #202124;
        color: #e8eaed;
        font-family: Arial, sans-serif;
        padding: 2rem;
    }

    .contest-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 1.5rem;
    }

    .contest-back {
        color: #8ab4f8;
        text-decoration: none;
        font-size: 1rem;
    }

    .contest-title {
        font-size: 2.5rem;
        color: #8ab4f8;
        margin: 0;
    }

    .contest-participants {
        font-size: 1rem;
        color: #bdc1c6;
    }

    .contest-ranking {
        margin-top: 1.5rem;
    }

    .contest-list {
        list-style: none;
        padding: 0;
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
        font-size: 1.5rem;
        font-weight: bold;
        margin-right: 1rem;
    }

    .contest-name {
        flex: 1;
        font-size: 1.2rem;
        color: #8ab4f8;
    }

    .contest-contests {
        font-size: 1rem;
        color: #9aa0a6;
        margin-right: 1rem;
    }

    .contest-flag {
        font-size: 1.5rem;
    }
</style>
