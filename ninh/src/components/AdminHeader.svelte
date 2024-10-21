<script>
    import "../CSS/header.css";
    export let href = "#";
    export let alt = "LeetCode";
  
    import { navigate } from "svelte-routing";
    import {accessTokenStore} from "../store/store.js";
    import AddAccount from "../pages/addAccount.svelte";
  
    import * as Avatar from "$lib/components/ui/avatar/index.js";
    import * as DropdownMenu from "$lib/components/ui/dropdown-menu";
    import { Button } from "$lib/components/ui/button/index.js";
  
    
    let notifications = [
      {
        title: "New Assignment",
        date: "July 26, 2024 12:49 AM",
        description: "Regular Expression Matching",
        points: "+10",
      },
      {
        title: "New Assignment",
        date: "May 9, 2024 3:02 PM",
        description: "Longest Palindromic Substring",
        points: "+10",
      },
      {
        title: "New Assignment",
        date: "April 1, 2024 9:00 AM",
        description: "Two Sum",
        points: "+10",
      },
      {
        title: "New Assignment",
        date: "March 1, 2024 9:00 AM",
        description: "Add Two Numbers",
        points: "+10",
      },
      {
        title: "New Assignment",
        date: "February 1, 2024 9:00 AM",
        description: "Reverse Integer",
        points: "+10",
      },
      {
        title: "New Assignment",
        date: "January 1, 2024 9:00 AM",
        description: "Two Sum",
        points: "+10",
      },
      
    ];
  
  
    function signOut() {
      accessTokenStore.set({});
      navigate("/login");
    }
    
    function profile() {
      navigate("/profile");
    }
  
    function goHome() {
      navigate("/teacherHome");
    }
  
    function discuss() {
      navigate("/discuss");
    }
  
  </script>-
  
  <div class="header">
  
      <div class="nav-left">
        <button on:click={goHome}><img src="/logo1.webp" {alt} class="logo" /></button>
        <a href = "/addAccount"> Management</a>
        <a href = "/addAssignment">Add Assign</a>
        
        
      </div>
  
      <div class="nav-right">
  
        <div class="user">
          <DropdownMenu.Root >
      <!-- Avatar as Trigger for the Dropdown Menu -->
            <DropdownMenu.Trigger asChild let:builder>
              <button use:builder.action class="header-dropdown-trigger">
                <Avatar.Root>
                  <Avatar.Image src="https://github.com/shadcn.png" alt="@shadcn" />
                  <Avatar.Fallback>CN</Avatar.Fallback>
                </Avatar.Root>
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
              <DropdownMenu.Item class="header-dropdown-item" on:click= {() => navigate("/teacherHome2")} >Support</DropdownMenu.Item>
              <DropdownMenu.Item class="header-dropdown-item" on:click= {() => navigate("/teacherHome")} >API</DropdownMenu.Item>
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
  
  <style>
    .dropdown-content {
      background-color: white;
      padding: 1rem;
      border-radius: 8px;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    }
  
    .notification-item {
      margin-bottom: 10px;
    }
  
    .notification-header {
      font-weight: bold;
    }
  
    .notification-date {
      font-size: 0.8rem;
      color: gray;
    }
  
    .notification-desc {
      font-size: 0.9rem;
      font-weight: bold;
    }
  
    .notification-points {
      color: orange;
      font-weight: bold;
    }
  </style>
  