<script>
    // import Header from "../components/Header.svelte";
    import AdminHeader from "../components/AdminHeader.svelte";
    import { onMount } from 'svelte';
    import MultiSelect from "svelte-multiselect";

    // Manage state for the account form and account list
    let newAccount = {
        userid: '',
        username: '',
        password: '',
        className: [],
        role: ''
    };

    // Simulate class data fetched from the database
    let classes = [];

    // Role options
    let roles = ['Admin', 'Student', 'Teacher'];

    // Store accounts
    let accounts = [];

    // Add a new account to the list
    function addAccount() {
        if (newAccount.userid && newAccount.username && newAccount.password && newAccount.className && newAccount.role) {
            // Push the new account to the list
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
            className: [],
            role: ''
        };
    }

    // Delete account from the list
    function deleteAccount(index) {
        accounts = accounts.filter((_, i) => i !== index);
    }

    onMount(() => {
        const getalluserurl = 'http://localhost:5292/api/admin/get/all-users';
        fetch(getalluserurl)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                accounts = data;
                for (let account of accounts) {
                    if (account.userRole === 0) {
                        account.userRole = 'Student';
                    } else if (account.userRole === 1) {
                        account.userRole = 'Teacher';
                    } else {
                        account.userRole = 'Admin';
                    }
                }
            });
        const getallclassurl = 'http://localhost:5292/api/admin/get/all-class';
        fetch(getallclassurl)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                classes = data;
            });
    });



</script>

<main class="addAccount-main">
    <AdminHeader />

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
<!--        <select class="addAccount-input" bind:value={newAccount.className} required>-->
<!--            <option value="" disabled selected>Select class</option>-->
<!--            {#each classes as className}-->
<!--                <option value={className.className}>{className.className}</option>-->
<!--            {/each}-->
<!--        </select>-->

        <MultiSelect
            --sms-options-bg="#1e1e1e"
            --sms-text-color="white"
            bind:value={newAccount.className}
            options={classes.map(c => c.className)}
            placeholder="Select class"
            required
        />
        <!-- Select Role (Dropdown) -->
        <label class="addAccount-label">Role:</label>
        <select class="addAccount-input" bind:value={newAccount.role} required>
            <option value="" disabled selected >Select role</option>
            {#each roles as role}
                <option value={role} >{role}</option>
            {/each}
        </select>

        <!-- Buttons -->
        <div class="button-group">
            <button type="button" class="addAccount-cancel" on:click={clearForm}>Cancel</button>
            <button type="submit" class="addAccount-submit">Submit</button>
        </div>
    </form>

    <!-- Account List Table -->
    {#if accounts.length > 0}
        <table class="addAccount-table">
            <thead>
                <tr>
                    <th>User ID</th>
                    <th>Username</th>
                    <th>Role</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {#each accounts as account, index}
                    <tr>
                        <td>{account.userId}</td>
                        <td>{account.username}</td>
                        <td>{account.userRole}</td>
                        <td>
                            <button class="delete-button" on:click={() => deleteAccount(index)}>Delete</button>
                        </td>
                    </tr>
                {/each}
            </tbody>
        </table>
    {/if}
</main>

<style>

    .addAccount-main {
        color: white;
        background-color: #1e1e1e;
        height: 100vh;
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
        border: 1px solid #8c9495;
        border-radius: 5px;
        color: white;
        background-color: #181C14;
    }

    .addAccount-input option {
        padding: 8px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 5px;
        color: white;
        background-color: #181C14;
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

    /* Table Styles */
    .addAccount-table {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
        color: white;
        background-color: #1e1e1e;
    }

    .addAccount-table th, .addAccount-table td {
        padding: 10px;
        text-align: left;
        border: 1px solid #ddd;
    }

    .delete-button {
        background-color: #ff4d4d;
        color: white;
        border: none;
        padding: 5px 10px;
        cursor: pointer;
        border-radius: 5px;
    }

    .delete-button:hover {
        background-color: #cc0000;
    }

</style>
