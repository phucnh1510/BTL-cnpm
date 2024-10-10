<script>
    import "../CSS/header.css";

    import { navigate } from "svelte-routing";

    import * as Avatar from "$lib/components/ui/avatar/index.js";
    import * as DropdownMenu from "$lib/components/ui/dropdown-menu";

    import * as Sheet from "$lib/components/ui/sheet";

    function signOut() {
        navigate("/login");
    }
    
    function profile() {
        navigate("/profile");
    }

    function goHome() {
        navigate("/home");
    }


</script>

<main>
    <div class="assignment-header">
        <div class="left-assignment">
            <img src="/leetcode.svg" alt="Logo" class="logo-assignment" />

            <Sheet.Root>
            <Sheet.Trigger class="sheet-trigger">
                <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="indent" class="sheet-trigger-img" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="currentColor" d="M0 64C0 77.3 10.7 88 24 88H424c13.3 0 24-10.7 24-24s-10.7-24-24-24H24C10.7 40 0 50.7 0 64zM192 192c0 13.3 10.7 24 24 24H424c13.3 0 24-10.7 24-24s-10.7-24-24-24H216c-13.3 0-24 10.7-24 24zm24 104c-13.3 0-24 10.7-24 24s10.7 24 24 24H424c13.3 0 24-10.7 24-24s-10.7-24-24-24H216zM0 448c0 13.3 10.7 24 24 24H424c13.3 0 24-10.7 24-24s-10.7-24-24-24H24c-13.3 0-24 10.7-24 24zM121 268.4c7.8-6.4 7.8-18.3 0-24.7L26.2 165.6C15.7 157 0 164.4 0 177.9V334.1c0 13.5 15.7 20.9 26.2 12.4L121 268.4z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
                </svg>
                <button class="problem-list">Problem List</button>
            </Sheet.Trigger>

            <Sheet.Content>
                <Sheet.Header>
                <Sheet.Title>Are you sure absolutely sure?</Sheet.Title>
                <Sheet.Description>
                    This action cannot be undone. This will permanently delete your account
                    and remove your data from our servers.
                </Sheet.Description>
                </Sheet.Header>
            </Sheet.Content>
            </Sheet.Root>

           
            
            <button>&lt;</button>
            <button>&gt;</button>
            <button>&#x21bb;</button>
        </div>

        <div class="middle-assignment">
            <button class="middle-submit" >Submit</button>
            <button class="middle-clock" >clock</button>
        </div>

        <div class="right-assignment">

            <div class="bell-a"><i class="fa-solid fa-bell"></i></div>
            <div class="fire-a"><i class="fa-solid fa-fire"></i></div>
            <div class="user">
                <DropdownMenu.Root >
            <!-- Avatar as Trigger for the Dropdown Menu -->
                <DropdownMenu.Trigger asChild let:builder>
                    <button use:builder.action class="header-dropdown-trigger">
                    <div class="avatar-root">
                        <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSweAHq4Ch8y2n6HvwAILhJx4-gPYf5rNkXwJcWGOTte2qbuar0" alt="avatar" class="avatar-image" />
                        <div class="avatar-fallback">CN</div>
                    </div>
                    </button>
                </DropdownMenu.Trigger>

            <!-- Dropdown Menu Content -->
                <DropdownMenu.Content class="header-dropdown-content w-56 ">
                    <DropdownMenu.Label class="header-dropdown-label">My Account</DropdownMenu.Label>
                    <DropdownMenu.Separator class="header-dropdown-separator" />
                    <DropdownMenu.Group class="header-dropdown-group">
                    <DropdownMenu.Item class="header-dropdown-item" on:click={profile}>
                        Profile
                        <DropdownMenu.Shortcut class="header-dropdown-shortcut">⇧⌘P</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                    <DropdownMenu.Item class="header-dropdown-item">
                        Billing
                        <DropdownMenu.Shortcut class="header-dropdown-shortcut">⌘B</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                    <DropdownMenu.Item class="header-dropdown-item">
                        Settings
                        <DropdownMenu.Shortcut class="header-dropdown-shortcut">⌘S</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                    <DropdownMenu.Item class="header-dropdown-item">
                        Keyboard shortcuts
                        <DropdownMenu.Shortcut class="header-dropdown-shortcut">⌘K</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                    </DropdownMenu.Group>
                    <DropdownMenu.Separator class="header-dropdown-separator" />
                    <DropdownMenu.Group class="header-dropdown-group">
                    <DropdownMenu.Item class="header-dropdown-item">Team</DropdownMenu.Item>
                    <DropdownMenu.Sub>
                        <DropdownMenu.SubTrigger class="header-dropdown-sub-trigger c-white">Invite users</DropdownMenu.SubTrigger>
                        <DropdownMenu.SubContent class="header-dropdown-sub-content">
                        <DropdownMenu.Item class="header-dropdown-item">Email</DropdownMenu.Item>
                        <DropdownMenu.Item class="header-dropdown-item">Message</DropdownMenu.Item>
                        <DropdownMenu.Separator class="header-dropdown-separator" />
                        <DropdownMenu.Item class="header-dropdown-item">More...</DropdownMenu.Item>
                        </DropdownMenu.SubContent>
                    </DropdownMenu.Sub>
                    <DropdownMenu.Item class="header-dropdown-item">
                        New Team
                        <DropdownMenu.Shortcut class="header-dropdown-shortcut">⌘+T</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                    </DropdownMenu.Group>
                    <DropdownMenu.Separator class="header-dropdown-separator" />
                    <DropdownMenu.Item class="header-dropdown-item">GitHub</DropdownMenu.Item>
                    <DropdownMenu.Item class="header-dropdown-item">Support</DropdownMenu.Item>
                    <DropdownMenu.Item class="header-dropdown-item">API</DropdownMenu.Item>
                    <DropdownMenu.Separator class="header-dropdown-separator" />
                    <DropdownMenu.Item class="header-dropdown-item" on:click={signOut}>
                    Log out
                    <DropdownMenu.Shortcut class="header-dropdown-shortcut">⇧⌘Q</DropdownMenu.Shortcut>
                    </DropdownMenu.Item>
                </DropdownMenu.Content>
                </DropdownMenu.Root>

        </div>

        </div>

    </div>
    

</main>

<style>
    .left-assignment {
        color: white;
        display: flex;
        align-items: center;
        padding: 0px 10px;
    }

    .middle-assignment {
        color: white;
    }

    .assignment-header {
        display: flex;
        justify-content: space-between;
        padding: 5px;
        background-color: #0b0c0d;
    }

    .right-assignment{
        display: flex;
        align-items: center;
        padding-right: 5%;
    }

    .avatar-root {
        display: inline-block;
        width: 30px;
        height: 30px;
        border-radius: 50%;
        overflow: hidden;
        position: relative;
        background-color: #e0e0e0;
    }

    .avatar-image {
        width: 100%;
        height: 100%;
        object-fit: cover;
        border-radius: 50%;
    }

    .bell-a i , .fire-a i{
        color: white;
        font-size: 18px;
    }

    .logo-assignment{
        width: 35px;
        height: 25px;
    }

    .sheet-trigger-img {
        color: #919088;
        width: 15px;
        height: auto;
        display: inline-block;
    }

    .sheet-trigger{
        display: flex;
    }

    .problem-list{
        color: #e8e6e3;
        background-color: #1d1f20;
        border: none;
        font-size: 14px;
        font-weight: 500;
    }

</style>