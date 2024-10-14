<script>
    import Header from "../components/Header.svelte";


    // Manage state for the account form and account list
    let newAccount = {
        name: '',
        email: '',
        role: ''
    };

    let accounts = [
        { name: 'John', email: '1234', role: 'Admin' },
        { name: 'Jane', email: '5432', role: 'User' }
    ];

    // Add a new account to the list
    function addAccount() {
        if (newAccount.name && newAccount.email && newAccount.role) {
            accounts = [...accounts, { ...newAccount }];
            clearForm();
        }
    }

    // Clear form after submission
    function clearForm() {
        newAccount = {
            name: '',
            email: '',
            role: ''
        };
    }

    // Delete account from the list
    function deleteAccount(index) {
        accounts = accounts.filter((_, i) => i !== index);
    }
</script>

<!-- Main Form for Adding Account -->
<main class="addAccount-main">
    <Header />

    <h2 class="addAccount-title">Add Account</h2>
    <form class="addAccount-form" on:submit|preventDefault={addAccount}>
        <label class="addAccount-label">Name:</label>
        <input class="addAccount-input" type="text" bind:value={newAccount.name} placeholder="Enter name" required />

        <label class="addAccount-label">Password:</label>
        <input class="addAccount-input" type="password" bind:value={newAccount.email} placeholder="Enter password" required />

        <label class="addAccount-label">Role:</label>
        <input class="addAccount-input" type="text" bind:value={newAccount.role} placeholder="Enter role" required />

        <button type="submit" class="addAccount-submit">Add Account</button>
    </form>

    <!-- Account List Section -->
    <h2 class="addAccount-title">Account Details</h2>
    <table class="addAccount-table">
        <thead>
            <tr>
                <th class="addAccount-th">Name</th>
                <th class="addAccount-th">Password</th>
                <th class="addAccount-th">Role</th>
                <th class="addAccount-th">Actions</th>
            </tr>
        </thead>
        <tbody>
            {#each accounts as account, index}
                <tr>
                    <td class="addAccount-td">{account.name}</td>
                    <td class="addAccount-td">{account.email}</td>
                    <td class="addAccount-td">{account.role}</td>
                    <td class="addAccount-td">
                        <button class="addAccount-update">Update</button>
                        <button class="addAccount-delete" on:click={() => deleteAccount(index)}>Delete</button>
                    </td>
                </tr>
            {/each}
        </tbody>
    </table>
</main>

<style>
    .addAccount-main {
        padding: 20px;
        color: white;
        background-color: #1e1e1e;
    }

    .addAccount-title {
        margin-top: 20px;
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

    .addAccount-submit {
        padding: 10px 20px;
        font-size: 1rem;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

    .addAccount-submit:hover {
        background-color: #0056b3;
    }

    .addAccount-table {
        width: 100%;
        border-collapse: collapse;
    }

    .addAccount-th, .addAccount-td {
        padding: 10px;
        text-align: left;
        border: 1px solid #ddd;
    }

    .addAccount-update {
        background-color: #ffc107;
        color: white;
        border: none;
        padding: 5px 10px;
        border-radius: 5px;
        cursor: pointer;
    }

    .addAccount-delete {
        background-color: #dc3545;
        color: white;
        border: none;
        padding: 5px 10px;
        border-radius: 5px;
        cursor: pointer;
        margin-left: 5px;
    }

    .addAccount-update:hover {
        background-color: #e0a800;
    }

    .addAccount-delete:hover {
        background-color: #c82333;
    }
</style>
