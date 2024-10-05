<script>
    import "../CSS/login.css";
    import { Input } from "$lib/components/ui/input";
    import { navigate } from "svelte-routing";
    import { Button } from "$lib/components/ui/button";
    
    import Footer from "../components/Footer.svelte";
</script>

<main class="login-main">
    <div class="login-body">
        <div class="login-left">
            <div class="login-image-container">
                <img src="https://images.unsplash.com/photo-1590069261209-f8e9b8642343?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1376&q=80;" alt="">
                <div class="login-image-overlay">
                    <h2 class="login-company-name">Acme Inc</h2>
                    <p class="login-testimonial">“Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vehicula congue massa, eu scelerisque sem maximus a. <br> Donec nec consequat nulla . ”</p>
                    <p class="login-author">Nguyễn Hải Ninh</p>
                </div>
            </div>

        <div class="login-right">
            <div class="login ">
                <h1 class="create-account">Sign in</h1>
                <p class="description">Enter your email below to create your account</p>
                <Input label="Username" placeholder="Enter your username" class="login-username" />
                <Input label="Password" placeholder="Enter your password" type="password"  class="login-password" />
                <Button class="custom-signin-button" on:click={() => navigate("/home")}>Login to your account</Button>
            </div>
    </div>

</main>