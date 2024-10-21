<script>
    import "../CSS/login.css";
    import { Input } from "$lib/components/ui/input";
    import { navigate } from "svelte-routing";
    import { Button } from "$lib/components/ui/button";
    import { accessTokenStore } from "../store/store";
    

    let username = '';
	let password = '';

    // $: {
    //     console.log(username);
    //     console.log(password);
    // }

    const handleSubmit = async () => {
        const loginDetails = {
			username: username,
			password: password
		};

		const options = {
			method: 'POST',
			body: JSON.stringify(loginDetails),
			headers: {
				'Content-Type': 'application/json'
			},
		};
		const url = 'http://localhost:5292/Auth/login';

        try {
			const res = await fetch(url, options);
            // console.log(res);
			const accessToken = await res.json();
			console.log(accessToken);
			accessTokenStore.set(accessToken);
            if (accessToken.role === 1) {
                navigate('/teacherHome2');
            } else if (accessToken.role === 2) {
                navigate('/teacherHome');
            } else {
                navigate('/home');
            }
		} catch (err) {
			alert("Invalid Credentials");
		}
    };
</script>

<main class="login-main">
    <div class="login-body">
        <div class="login-left">
            <div class="login-image-container">
                <img src="https://images.unsplash.com/photo-1590069261209-f8e9b8642343?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1376&q=80;" alt="">
                <div class="login-image-overlay">
                    <h2 class="login-company-name">Acme Inc</h2>
                    <p class="login-testimonial">“Now I have become death <br> The destroyer of worlds.”</p>
                    <p class="login-author">Nguyễn Hải Ninh & Phúc</p>
                </div>
            </div>

        <div class="login-right">
            <div class="login ">
                <form on:submit|preventDefault={handleSubmit}>
                    <h1 class="create-account">Sign in</h1>
                    <p class="description">Enter your email below to create your account</p>
                    <Input label="Username" placeholder="Enter your username" class="login-username" bind:value={username}/>
                    <Input label="Password" placeholder="Enter your password" type="password"  class="login-password" bind:value={password}/>
                    <Button class="custom-signin-button" type="submit">Login to your account</Button>
                </form>
            </div>
    </div>

</main>