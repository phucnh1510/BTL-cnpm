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

           
            
            <button class="problem-list-2" >&lt;</button>
            <button class="problem-list-2">&gt;</button>
            <button class="problem-list-2">&#x21bb;</button>
        </div>

        <div class="middle-assignment">
            <div class="middle-submit">
                <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="cloud-arrow-up"  role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512"><path fill="currentColor" d="M354.9 121.7c13.8 16 36.5 21.1 55.9 12.5c8.9-3.9 18.7-6.2 29.2-6.2c39.8 0 72 32.2 72 72c0 4-.3 7.9-.9 11.7c-3.5 21.6 8.1 42.9 28.1 51.7C570.4 276.9 592 308 592 344c0 46.8-36.6 85.2-82.8 87.8c-.6 0-1.3 .1-1.9 .2H504 144c-53 0-96-43-96-96c0-41.7 26.6-77.3 64-90.5c19.2-6.8 32-24.9 32-45.3l0-.2v0 0c0-66.3 53.7-120 120-120c36.3 0 68.8 16.1 90.9 41.7zM512 480v-.2c71.4-4.1 128-63.3 128-135.8c0-55.7-33.5-103.7-81.5-124.7c1-6.3 1.5-12.8 1.5-19.3c0-66.3-53.7-120-120-120c-17.4 0-33.8 3.7-48.7 10.3C360.4 54.6 314.9 32 264 32C171.2 32 96 107.2 96 200l0 .2C40.1 220 0 273.3 0 336c0 79.5 64.5 144 144 144H464h40 8zM223 255c-9.4 9.4-9.4 24.6 0 33.9s24.6 9.4 33.9 0l39-39V384c0 13.3 10.7 24 24 24s24-10.7 24-24V249.9l39 39c9.4 9.4 24.6 9.4 33.9 0s9.4-24.6 0-33.9l-80-80c-9.4-9.4-24.6-9.4-33.9 0l-80 80z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path></svg>
                <button >Submit</button>
            </div>
            
            <button class="middle-clock" ><svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="alarm-clock" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path fill="currentColor" d="M160 25.4C143 9.6 120.2 0 95.2 0C42.6 0 0 42.6 0 95.2c0 18.8 5.5 36.3 14.9 51.1L160 25.4zM256 112a176 176 0 1 1 0 352 176 176 0 1 1 0-352zm0 400c53.2 0 102.1-18.6 140.5-49.5L439 505c9.4 9.4 24.6 9.4 33.9 0s9.4-24.6 0-33.9l-42.5-42.5c31-38.4 49.5-87.3 49.5-140.5C480 164.3 379.7 64 256 64S32 164.3 32 288c0 53.2 18.6 102.1 49.5 140.5L39 471c-9.4 9.4-9.4 24.6 0 33.9s24.6 9.4 33.9 0l42.5-42.5c38.4 31 87.3 49.5 140.5 49.5zM497.1 146.4C506.5 131.6 512 114 512 95.2C512 42.6 469.4 0 416.8 0C391.8 0 369 9.6 352 25.4L497.1 146.4zM280 184c0-13.3-10.7-24-24-24s-24 10.7-24 24V288c0 6.4 2.5 12.5 7 17l48 48c9.4 9.4 24.6 9.4 33.9 0s9.4-24.6 0-33.9l-41-41V184z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path></svg></button>
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
        margin-left: 20px;
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
        margin-top: 5px;
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
        padding-right: 15px;
        margin-right: 20px;
    }

    .sheet-trigger-img {
        color: #919088;
        width: 15px;
        height: auto;
        display: inline-block;
       
    }

    .problem-list{
        padding-left: 20px;
    }

    .sheet-trigger{
        display: flex;
    }

    .problem-list{
        color: #e8e6e3;
        background-color: #0b0c0d;
        border: none;
        font-size: 14px;
        font-weight: 500;
        padding-left: 5px;
    }

    .problem-list-2{
        padding: 0;
        font-size: 20px;
        margin-left: 20px;
        color: #bbb5ac;
    }

    .middle-submit{
        display: flex;
        color: #47c95f;   
        border-radius: 10px;
        
    }

    .middle-submit svg{
        color: #47c95f;
        width: 25px;
        padding-right: 5px;
    }

    .middle-submit button{
        font-size: 14px;
        font-weight: 500;
    }

    .middle-clock{
       
        color: #8e8880;
        margin-left: 10px;
    }

    .middle-clock svg{
        color: #8e8880;
        width: 18px;
    }

    .middle-assignment{
        display: flex;
        padding: 0px 10px;
    }

    .middle-submit:hover{
        background-color: #1a1b1c;
    }
    
    .middle-clock:hover{
        background-color: #1a1b1c;
    }
</style>