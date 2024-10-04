<script>
  export let href = "#";
  export let alt = "LeetCode";

  import * as Avatar from "$lib/components/ui/avatar/index.js";
</script>

<div class="header">

    <div class="nav-left">
      <img src="/leetcode.svg" {alt} class="logo" />
      <a {href}>Explore</a>
      <a {href}>Problems</a>
      <a {href}>Contest</a>
      <a {href}>Discuss</a>
    </div>

    <div class="nav-right">
      <div class="bell"><i class="fa-solid fa-bell"></i></div>
      <div class="fire"><i class="fa-solid fa-fire"></i></div>
      <div class="user">
        <Avatar.Root>
            <Avatar.Image src="https://github.com/shadcn.png" alt="@shadcn" />
            <Avatar.Fallback>CN</Avatar.Fallback>
        </Avatar.Root>  
      </div>
    </div>

  </div>