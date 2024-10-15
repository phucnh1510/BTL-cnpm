<script>
    let submissions = [
        { status: 'Runtime Error', language: 'Python', time: 'a few seconds ago', runtime: 'N/A', memory: 'N/A', notes: '' },
        { status: 'Wrong Answer', language: 'C++', time: 'a minute ago', runtime: 'N/A', memory: 'N/A', notes: '' },
        { status: 'Compile Error', language: 'Java', time: '2 minutes ago', runtime: 'N/A', memory: 'N/A', notes: '' },
        { status: 'Compile Error', language: 'Java', time: '10 hours ago', runtime: 'N/A', memory: 'N/A', notes: '' },
        { status: 'Compile Error', language: 'C++', time: 'Oct 10, 2024', runtime: 'N/A', memory: 'N/A', notes: '' },
        // Add more rows here as needed
    ];
</script>

<style>

    .submission-main{
        background-color: #1d1f20;
        height: 100%;
    }


    table.submission-table {
        width: 100%;
        border-collapse: collapse;
        
    }

    th.submission-header, td.submission-cell {
        padding: 12px;
        text-align: left;
        color: #9aa5ac;
        
    }

    tr.submission-row:nth-child(even) {
        background-color: #1d1f20;
    }

    tr.submission-row:nth-child(odd) {
        background-color: #1d1f20;
    }

    .submission-error {
        color: red;
    }

    .submission-status-cell {
        font-weight: bold;
        color: red;
        padding-left: 10px;
    }

    .submission-notes-link {
        color: #9aa5ac;
        cursor: pointer;
    }

    .submission-cell{
        color: #9aa5ac;
    }

    .svg-sub{
        width: 15px;
        height: 15px;
        color: #9aa5ac;
        display: flex;
       
    }

    .submission-time{
        display: flex;
        
    }

</style>

<main class="submission-main">
    <table class="submission-table">
        <thead>
            <tr>
                <th class="submission-header">Status</th>
                <th class="submission-header">Language</th>
                <th class="submission-header">Time</th>
                <th class="submission-header">Runtime</th>
                <th class="submission-header">Memory</th>
                <th class="submission-header">Notes</th>
            </tr>
        </thead>
        <tbody>
            {#each submissions as submission}
                <tr class="submission-row">
                    <td class="submission-status-cell {submission.status.includes('Error') ? 'submission-error' : ''}">{submission.status}</td>
                    <td class="submission-cell">{submission.language}</td>
                    
                    <td class="submission-cell">{submission.time}</td>
                    
                    
                    <td class="submission-cell">{submission.runtime}</td>
                    <td class="submission-cell">{submission.memory}</td>
                    <td class="submission-cell"><span class="submission-notes-link">{submission.notes}</span></td>
                </tr>
            {/each}
        </tbody>
    </table>
</main>