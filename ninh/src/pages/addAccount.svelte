<script>
    import Header from "../components/Header.svelte";

    // Manage state for the account form and account list
    let newAccount = {
        userid: '',
        username: '',
        password: '',
        className: '', // Renamed from 'class' to 'className'
        role: ''
    };

    // Simulate class data fetched from the database
    let classes = ['Math', 'Science', 'History']; // Replace this with actual DB data

    // Role options
    let roles = ['Admin', 'User', 'Moderator']; 

    // Add a new account to the list
    function addAccount() {
        if (newAccount.userid && newAccount.username && newAccount.password && newAccount.className && newAccount.role) {
            // Push the new account (here you can handle the API call for account creation)
            accounts = [...accounts, { ...newAccount }];
            clearForm();
        }
    }

    // Clear form after submission or cancellation
    function clearForm() {
        newAccount = {
            userid: '',
            username: '',
            password: '',
            className: '', // Reset to empty string
            role: ''
        };
    }

    // Delete account from the list (optional if you have a delete feature)
    function deleteAccount(index) {
        accounts = accounts.filter((_, i) => i !== index);
    }
</script>

<main class="addAccount-main">
    <Header />

    <h2 class="addAccount-title">Add Account</h2>
    <form class="addAccount-form" on:submit|preventDefault={addAccount}>
        <!-- User ID input -->
        <label class="addAccount-label">User ID:</label>
        <input class="addAccount-input" type="text" bind:value={newAccount.userid} placeholder="Enter user ID" required />

        <!-- Username input -->
        <label class="addAccount-label">Username:</label>
        <input class="addAccount-input" type="text" bind:value={newAccount.username} placeholder="Enter username" required />

        <!-- Password input -->
        <label class="addAccount-label">Password:</label>
        <input class="addAccount-input" type="password" bind:value={newAccount.password} placeholder="Enter password" required />

        <!-- Select Class (Dropdown) -->
        <label class="addAccount-label">Class:</label>
        <select class="addAccount-input" bind:value={newAccount.className} required>
            <option value="" disabled selected>Select class</option>
            {#each classes as className}
                <option value={className}>{className}</option>
            {/each}
        </select>

        <!-- Select Role (Dropdown) -->
        <label class="addAccount-label">Role:</label>
        <select class="addAccount-input" bind:value={newAccount.role} required>
            <option value="" disabled selected>Select role</option>
            {#each roles as role}
                <option value={role}>{role}</option>
            {/each}
        </select>

        <!-- Buttons -->
        <div class="button-group">
            <button type="button" class="addAccount-cancel" on:click={clearForm}>Cancel</button>
            <button type="submit" class="addAccount-submit">Submit</button>
        </div>
    </form>
</main>

<style>
    .addAccount-main {
        padding: 20px;
        color: white;
        background-color: #1e1e1e;
    }

    .addAccount-title {
        font-size: 2rem;
        margin-bottom: 20px;
        font-weight: 700;
    }

    .addAccount-form {
        display: flex;
        flex-direction: column;
        gap: 10px;
        margin-bottom: 30px;
    }

    .addAccount-label {
        font-size: 1rem;
    }

    .addAccount-input {
        padding: 8px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 5px;
        color: black;
    }

    .button-group {
        display: flex;
        justify-content: flex-start;
        gap: 10px;
        margin-top: 20px;
    }

    .addAccount-submit, .addAccount-cancel {
        padding: 10px 20px;
        font-size: 1rem;
        border-radius: 5px;
        cursor: pointer;
        border: none;
    }

    .addAccount-submit {
        background-color: #007bff;
        color: white;
    }

    .addAccount-cancel {
        background-color: #6c757d;
        color: white;
    }

    .addAccount-submit:hover {
        background-color: #0056b3;
    }

    .addAccount-cancel:hover {
        background-color: #5a6268;
    }
</style>
