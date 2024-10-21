<script>
    import Header from "../components/Header.svelte";
    import Footer from "../components/Footer.svelte";
    import AdminHeader from "../components/AdminHeader.svelte";


    import { navigate } from "svelte-routing";

    const navigateTo = (route) => {
        navigate(route);
    };



</script>

<main class="adminMain">
    <AdminHeader />
    
    <div class="adminHome-grid-container">
        <button class="adminHome-card-button" on:click={() => navigateTo('/addAccount')}>
            <div class="adminHome-card-icon">🏛️</div>
            <div class="adminHome-card-label">Account Management</div>
        </button>

        <button class="adminHome-card-button" on:click={() => navigateTo('/addAssignment')}>
            <div class="adminHome-card-icon">📝</div>
            <div class="adminHome-card-label">Add Assignments</div>
        </button>

      
</div>
    
</main>

<style>
    .adminMain{
        height: 100vh;
        background-color: #121414;
    }

    .adminHome-grid-container {
       display: flex;
       gap: 20px;
       margin-top: 20px;
       margin-left: 3vw;
  
    }

    .adminHome-card-button {
        background-color: #0078d7;
        color: white;
        padding: 20px;
        border-radius: 10px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        border: none;
        cursor: pointer;
        transition: transform 0.2s ease-in-out;
        width: 375px;
        height: 200px;
    }

    .adminHome-card-button:hover {
        transform: scale(1.05);
    }

    .adminHome-card-icon {
        font-size: 50px;
        margin-bottom: 10px;
    }

    .adminHome-card-label {
        font-size: 20px;
        text-align: center;
        font-weight: 500;
    }
</style>