<script>
  import "./app.css";
  import Header from "./components/Header.svelte";
  import Footer from "./components/Footer.svelte";
  import * as Collapsible from "$lib/components/ui/collapsible";
  import * as DropdownMenu from "$lib/components/ui/dropdown-menu";
  import { createPagination, melt } from '@melt-ui/svelte';
  import { RangeCalendar } from "bits-ui";

  import { NextButton, PrevButton} from '$lib/components/ui/range-calendar';

  import { onMount } from 'svelte';

  let href = "";
  let alt = "";
  let isExpanded = false;

  let listsExpanded = false;
  let difficultyExpanded = false;
  let statusExpanded = false;
  let tagsExpanded = false;

  let perPage = 51;

  // Function to toggle the expanded state for each dropdown
  function toggleDropdown(dropdown) {
    switch(dropdown) {
      case 'lists':
        listsExpanded = !listsExpanded;
        break;
      case 'difficulty':
        difficultyExpanded = !difficultyExpanded;
        break;
      case 'status':
        statusExpanded = !statusExpanded;
        break;
      case 'tags':
        tagsExpanded = !tagsExpanded;
        break;
    }
  }

  const solutionIcons = {
    blueCode: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" style="color: #33a0f6;" class="text-blue dark:text-dark-blue h-5 w-5" aria-label="Blue Code Icon" role="img"><path d="M15.207 11.293a1 1 0 010 1.414l-3.5 3.5a1 1 0 01-1.414 0l-2-2a1 1 0 111.414-1.414L11 14.086l2.793-2.793a1 1 0 011.414 0z"></path><path d="M4 5a3 3 0 013-3h7.039a3 3 0 012.342 1.126l2.962 3.701A3 3 0 0120 8.702V19a3 3 0 01-3 3H7a3 3 0 01-3-3V5zm3-1a1 1 0 00-1 1v14a1 1 0 001 1h10a1 1 0 001-1V9h-3a2 2 0 01-2-2V4H7zm8 .6V7h1.92L15 4.6z"></path></svg>`,
    purpleCode: `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" style="color: #af5ade;" class="text-purple dark:text-dark-purple h-5 w-5" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><path d="M10 15.464v-3.927a.8.8 0 011.259-.656l2.805 1.964a.8.8 0 010 1.31l-2.805 1.964A.8.8 0 0110 15.464z"></path><path d="M7 4a1 1 0 00-1 1v14a1 1 0 001 1h10a1 1 0 001-1V9h-3a2 2 0 01-2-2V4H7zm8 .6V7h1.92L15 4.6zM4 5a3 3 0 013-3h7.039a3 3 0 012.342 1.126l2.962 3.701A3 3 0 0120 8.702V19a3 3 0 01-3 3H7a3 3 0 01-3-3V5z"></path></svg>`
  };

  const problems = [
    { status: "calendar", title: "1590. Make Sum Divisible by P", solution: "blueCode", acceptance: "33.9%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "1. Two Sum", solution: "blueCode", acceptance: "53.9%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "2. Add Two Numbers", solution: "purpleCode", acceptance: "44.2%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "3. Longest Substring Without Repeating Characters", solution: "purpleCode", acceptance: "35.5%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "4. Median of Two Sorted Arrays", solution: "purpleCode", acceptance: "41.6%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "5. Longest Palindromic Substring", solution: "purpleCode", acceptance: "34.5%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "6. Zigzag Conversion", solution: "purpleCode", acceptance: "49.4%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "7. Reverse Integer", solution: "purpleCode", acceptance: "29.2%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "8. String to Integer (atoi)", solution: "blueCode", acceptance: "18.0%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "9. Palindrome Number", solution: "purpleCode", acceptance: "57.6%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "10. Regular Expression Matching", solution: "purpleCode", acceptance: "28.4%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "11. Container With Most Water", solution: "blueCode", acceptance: "56.3%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "12. Integer to Roman", solution: "purpleCode", acceptance: "66.4%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "13. Roman to Integer", solution: "purpleCode", acceptance: "62.8%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "14. Longest Common Prefix", solution: "purpleCode", acceptance: "43.9%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "15. 3Sum", solution: "purpleCode", acceptance: "35.4%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "16. 3Sum Closest", solution: "purpleCode", acceptance: "46.1%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "17. Letter Combinations of a Phone Number", solution: "blueCode", acceptance: "61.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "18. 4Sum", solution: "blueCode", acceptance: "36.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "19. Remove Nth Node From End of List", solution: "purpleCode", acceptance: "46.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "20. Valid Parentheses", solution: "purpleCode", acceptance: "41.1%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "21. Merge Two Sorted Lists", solution: "purpleCode", acceptance: "65.4%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "22. Generate Parentheses", solution: "purpleCode", acceptance: "75.6%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "23. Merge k Sorted Lists", solution: "purpleCode", acceptance: "54.3%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "24. Swap Nodes in Pairs", solution: "blueCode", acceptance: "65.4%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "25. Reverse Nodes in k-Group", solution: "blueCode", acceptance: "60.6%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "26. Remove Duplicates from Sorted Array", solution: "purpleCode", acceptance: "57.8%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "27. Remove Element", solution: "purpleCode", acceptance: "58.3%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "28. Find the Index of the First Occurrence in a String", solution: "blueCode", acceptance: "43.5%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "29. Divide Two Integers", solution: "blueCode", acceptance: "17.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "30. Substring with Concatenation of All Words", solution: "purpleCode", acceptance: "32.5%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "31. Next Permutation", solution: "purpleCode", acceptance: "41.2%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "32. Longest Valid Parentheses", solution: "purpleCode", acceptance: "34.8%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "33. Search in Rotated Sorted Array", solution: "blueCode", acceptance: "41.6%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "34. Find First and Last Position of Element in Sorted Array", solution: "blueCode", acceptance: "45.3%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "35. Search Insert Position", solution: "blueCode", acceptance: "47.3%", difficulty: "Easy", frequency: "lock" },
    { status: "check", title: "36. Valid Sudoku", solution: "purpleCode", acceptance: "60.7%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "37. Sudoku Solver", solution: "purpleCode", acceptance: "63.0%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "38. Count and Say", solution: "purpleCode", acceptance: "56.5%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "39. Combination Sum", solution: "purpleCode", acceptance: "72.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "40. Combination Sum II", solution: "purpleCode", acceptance: "56.5%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "41. First Missing Positive", solution: "purpleCode", acceptance: "40.0%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "42. Trapping Rain Water", solution: "purpleCode", acceptance: "63.2%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "43. Multiply Strings", solution: "purpleCode", acceptance: "41.0%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "44. Wildcard Matching", solution: "purpleCode", acceptance: "28.7%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "45. Jump Game II", solution: "blueCode", acceptance: "40.8%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "46. Permutations", solution: "blueCode", acceptance: "79.3%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "47. Permutations II", solution: "blueCode", acceptance: "60.1%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "48. Rotate Image", solution: "blueCode", acceptance: "76.0%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "49. Group Anagrams", solution: "purpleCode", acceptance: "69.5%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "50. Pow(x, n)", solution: "blueCode", acceptance: "35.6%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "51. N-Queens", solution: "blueCode", acceptance: "70.1%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "52. N-Queens II", solution: "blueCode", acceptance: "75.0%", difficulty: "Hard", frequency: "lock" },
    { status: "check", title: "53. Maximum Subarray", solution: "purpleCode", acceptance: "51.2%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "54. Spiral Matrix", solution: "blueCode", acceptance: "51.4%", difficulty: "Medium", frequency: "lock" },
    { status: "check", title: "55. Jump Game", solution: "blueCode", acceptance: "38.8%", difficulty: "Medium", frequency: "lock" },
    ];

  const totalProblems = problems.length;

  const {
    elements: { root, pageTrigger, prevButton, nextButton },
    states: { pages, range }
  } = createPagination({
    count: totalProblems,
    perPage: perPage,
    defaultPage: 1,
    siblingCount: 1
  });

  // Calculate paginated problems reactively based on range
  $: paginatedProblems = problems.slice(range.start, range.end);
  // Reactive statement to slice problems based on valid range
  $: {
  console.log('Range:', $range);

  // Ensure the range start is never 0
  const start = Math.max($range.start - 1, 0); // Make sure we start from at least 0
  const end = Math.min($range.end, totalProblems); // Ensure we do not exceed the total length of problems

  // Slice the problems array based on the validated start and end values
  paginatedProblems = problems.slice(start, end);

  // console.log('Paginated Problems:', paginatedProblems);
}

// Reactive data for progress
  let progressData = {
    total: 3308,
    easy: { solved: 0, total: 828 },
    medium: { solved: 0, total: 1731 },
    hard: { solved: 0, total: 749 }
  };

</script>

<main>
  <Header />

  <div class="body">
    <div class="body-left">
      <div class="img-container">
        <div class="image-1">
          <a {href}><img src="https://assets.leetcode.com/users/images/49479bba-73b3-45d2-9272-99e773d784b2_1687290663.3168745.jpeg" class="object-cover md:h-full md:w-full h-[100px] w-[200px]" {alt} /></a>
        </div>

        <div class="image-2">
          <a {href}><img src="https://assets.leetcode.com/users/images/770789b0-c96b-4663-86d1-baab25534864_1669795265.8012726.png" class="object-cover md:h-full md:w-full h-[100px] w-[200px]" {alt} /></a>
        </div>

        <div class="image-3">
          <a {href}><img src="https://assets.leetcode.com/users/images/b0a08a5c-c575-48f6-9110-b6ae4e011e98_1655746322.579097.png" class="object-cover md:h-full md:w-full h-[100px] w-[200px]" {alt} /></a>
        </div>
      </div>

      <p class="studyPlan">Study Plan</p>

      <div class="categories">
        <a {href}  class="category">Array  </a >
        <a {href} class="category">String </a >
        <a {href} class="category">Hash Table </a >
        <a {href} class="category">Dynamic Programming </a >
        <a {href} class="category">Math </a >
        <a {href} class="category">Sorting </a >
        <a {href} class="category">Greedy </a >

        <Collapsible.Root open={isExpanded}>
          <Collapsible.Trigger asChild>
            <button class="expand" on:click={() => isExpanded = !isExpanded}>
              <p class="separator" style="color: white; display:inline"> | </p>
              {isExpanded ? 'Collapse' : ' Expand'} 
              <i class={`fa fa-caret-${isExpanded ? 'up' : 'down'}`}></i>
            </button>
          </Collapsible.Trigger>

          <Collapsible.Content>
            <div class="grid-container expanded">
              <a {href} class="category">Depth-First Search</a>
              <a {href} class="category">Database</a>
              <a {href} class="category">Binary Search</a>
              <a {href} class="category">Matrix</a>
              <a {href} class="category">Bit Manipulation</a>
              <a {href} class="category">Heap</a>
              <!-- Add as many categories as needed -->
            </div>
          </Collapsible.Content>

        </Collapsible.Root>
      </div>

      <div class="nav-container">
        <div class="nav-item active">
          <svg class="svg-all-topics" xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" viewBox="0 0 24 24">
            <polyline points="21 8 21 21 3 21 3 8"></polyline>
            <rect x="1" y="3" width="22" height="5"></rect>
            <line x1="10" y1="12" x2="14" y2="12"></line>
          </svg>
          <span>All Topics</span>
        </div>
    
        <div class="nav-item">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" class="text-brand-orange mr-0 hidden h-[18px] w-[18px] lg:block" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><path fill-rule="evenodd" d="M5.828 1.793a1 1 0 011.415 0L10.45 5h8.05a1 1 0 011 1v2.895a3.502 3.502 0 010 6.71V18.5a1 1 0 01-1 1H10V21a1 1 0 01-1 1H4a1 1 0 01-1-1v-5a1 1 0 011-1h5a1 1 0 011 1v1.5h7.5v-1.895a3.502 3.502 0 010-6.71V7h-6.98l-3.277 3.278a1 1 0 01-1.415 0L2.293 6.743a1 1 0 010-1.415l3.535-3.535zm.708 2.121L4.414 6.036l2.122 2.12 2.12-2.12-2.12-2.122zM18.5 10.75a1.5 1.5 0 100 3 1.5 1.5 0 000-3zM5 20v-3h3v3H5z" clip-rule="evenodd"></path></svg>
          
          <span>Algorithms</span>
        </div>
    
        <div class="nav-item">
          <svg  xmlns="http://www.w3.org/2000/svg" width="28" height="28" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="icon">
            <ellipse cx="12" cy="5" rx="8" ry="3"></ellipse>
            <path d="M4 5v6c0 1.656 3.582 3 8 3s8-1.344 8-3V5"></path>
            <path d="M4 11v6c0 1.656 3.582 3 8 3s8-1.344 8-3v-6"></path>
          </svg>
          <span>Database</span>
        </div>
    
        <div class="nav-item">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" class="text-green-s dark:text-dark-green-s mr-0 hidden h-[18px] w-[18px] lg:block" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><path d="M8 2a1 1 0 011 1v1.7h.877c.307 0 .565.107.783.325.218.218.325.476.325.783v.027c0 .306-.107.559-.323.767l-.002.002a1.062 1.062 0 01-.783.325H7.225c-.55 0-1.02.193-1.405.577l-.001.002a1.947 1.947 0 00-.576 1.403c0 .38.09.72.276 1.014.185.292.46.531.816.719.12.063.385.153.775.27.396.12.936.27 1.62.452 1.01.289 1.73.654 2.178 1.085h.001c.636.603.965 1.483.965 2.667 0 1.164-.408 2.155-1.228 2.984A4.15 4.15 0 019 19.126V21a1 1 0 11-2 0v-1.67H4.094c-.296 0-.55-.107-.769-.326l-.002-.002A1.017 1.017 0 013 18.235v-.027c0-.306.107-.564.325-.782.22-.22.473-.326.77-.326h3.704c.55 0 1.021-.193 1.405-.577.384-.384.577-.855.577-1.405 0-.363-.091-.687-.278-.965-.187-.278-.463-.5-.818-.674h-.002a7.78 7.78 0 00-.728-.24c-.395-.12-.948-.28-1.659-.48-1-.297-1.72-.67-2.18-1.111-.637-.63-.966-1.534-.966-2.737 0-1.163.409-2.15 1.228-2.97C5.12 5.2 5.992 4.791 7 4.714V3a1 1 0 011-1zM14.496 9.532a1 1 0 10-.992 1.736l5.48 3.132-5.48 3.132a1 1 0 10.992 1.736l5.48-3.132c1.344-.767 1.344-2.705 0-3.473l-5.48-3.131z"></path></svg>
          <span>Shell</span>
        </div>
    
        <div class="nav-item">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" class="text-purple dark:text-dark-purple mr-0 hidden h-[18px] w-[18px] lg:block" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><path fill-rule="evenodd" d="M16.664 3.48C16.02 2.905 15 3.363 15 4.226v3.546c0 .863 1.02 1.32 1.664.748l1.995-1.774a1 1 0 000-1.494l-1.995-1.774zM4 9a4 4 0 014-4h5a1 1 0 110 2H8a2 2 0 100 4h8a4 4 0 110 8h-6a1 1 0 010-2h6a2 2 0 000-4H8a4 4 0 01-4-4zm4 10.773v-3.546c0-.863-1.02-1.32-1.664-.748L4.34 17.253a1 1 0 000 1.494l1.995 1.773c.645.574 1.664.116 1.664-.747z" clip-rule="evenodd"></path></svg>
          <span>Concurrency</span>
        </div>
    
        <div class="nav-item">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 18 18" width="1em" height="1em" fill="currentColor" class="mr-0 hidden h-[18px] w-[18px] lg:block text-teal dark:text-dark-teal" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><mask id="javascript_svg__a" width="16" height="18" x="0.8" y="0.081" maskUnits="userSpaceOnUse"><path d="M.8.081h16v18H.8z"></path><path d="M11.221 11.254a3.236 3.236 0 01-1.735-.314 1.135 1.135 0 01-.425-.798.175.175 0 00-.18-.174 37.413 37.413 0 00-.753 0 .167.167 0 00-.183.147 1.843 1.843 0 00.597 1.456 3.175 3.175 0 001.767.663c.67.078 1.349.049 2.01-.085a2.484 2.484 0 001.332-.714c.402-.494.521-1.16.313-1.762a1.481 1.481 0 00-.975-.864c-1.016-.356-2.114-.328-3.15-.598-.18-.055-.4-.117-.48-.306a.673.673 0 01.225-.755 2.037 2.037 0 011.071-.265 3.248 3.248 0 011.494.213c.288.169.488.456.545.783a.192.192 0 00.181.186c.25.006.498.002.749.002a.18.18 0 00.195-.132 1.92 1.92 0 00-.942-1.664 4.685 4.685 0 00-2.553-.388 2.788 2.788 0 00-1.726.69 1.712 1.712 0 00-.344 1.786 1.529 1.529 0 00.966.84c1.014.363 2.124.246 3.145.569.2.067.432.17.493.39a.782.782 0 01-.214.748 2.366 2.366 0 01-1.423.346zm4.361-6.669a6909.08 6909.08 0 00-5.934-3.336 1.336 1.336 0 00-1.298 0L2.438 4.572a1.217 1.217 0 00-.638 1.06v6.692a1.226 1.226 0 00.663 1.07c.566.306 1.116.645 1.693.931a2.441 2.441 0 002.172.06 1.678 1.678 0 00.79-1.518c.003-2.208 0-4.417.001-6.625a.173.173 0 00-.164-.201 31.753 31.753 0 00-.756 0 .167.167 0 00-.182.168c-.003 2.194.002 4.39 0 6.585 0 .31-.193.588-.485.697a1.22 1.22 0 01-.984-.132l-1.572-.884a.187.187 0 01-.107-.186V5.667a.204.204 0 01.124-.205l5.891-3.306a.204.204 0 01.232 0l5.892 3.305a.207.207 0 01.123.205v6.624a.191.191 0 01-.106.188c-1.934 1.089-3.87 2.176-5.805 3.262-.092.05-.202.133-.31.07-.508-.285-1.007-.582-1.513-.87a.163.163 0 00-.183-.012c-.222.13-.456.24-.7.326-.109.044-.244.057-.32.158.096.104.213.187.344.245l1.773 1.02a1.298 1.298 0 001.314.036c1.97-1.105 3.941-2.211 5.912-3.319a1.229 1.229 0 00.663-1.07V5.631a1.216 1.216 0 00-.618-1.046z"></path></mask><path d="M11.221 11.254a3.236 3.236 0 01-1.735-.314 1.135 1.135 0 01-.425-.798.175.175 0 00-.18-.174 37.413 37.413 0 00-.753 0 .167.167 0 00-.183.147 1.843 1.843 0 00.597 1.456 3.175 3.175 0 001.767.663c.67.078 1.349.049 2.01-.085a2.484 2.484 0 001.332-.714c.402-.494.521-1.16.313-1.762a1.481 1.481 0 00-.975-.864c-1.016-.356-2.114-.328-3.15-.598-.18-.055-.4-.117-.48-.306a.673.673 0 01.225-.755 2.037 2.037 0 011.071-.265 3.248 3.248 0 011.494.213c.288.169.488.456.545.783a.192.192 0 00.181.186c.25.006.498.002.749.002a.18.18 0 00.195-.132 1.92 1.92 0 00-.942-1.664 4.685 4.685 0 00-2.553-.388 2.788 2.788 0 00-1.726.69 1.712 1.712 0 00-.344 1.786 1.529 1.529 0 00.966.84c1.014.363 2.124.246 3.145.569.2.067.432.17.493.39a.782.782 0 01-.214.748 2.366 2.366 0 01-1.423.346zm4.361-6.669a6909.08 6909.08 0 00-5.934-3.336 1.336 1.336 0 00-1.298 0L2.438 4.572a1.217 1.217 0 00-.638 1.06v6.692a1.226 1.226 0 00.663 1.07c.566.306 1.116.645 1.693.931a2.441 2.441 0 002.172.06 1.678 1.678 0 00.79-1.518c.003-2.208 0-4.417.001-6.625a.173.173 0 00-.164-.201 31.753 31.753 0 00-.756 0 .167.167 0 00-.182.168c-.003 2.194.002 4.39 0 6.585 0 .31-.193.588-.485.697a1.22 1.22 0 01-.984-.132l-1.572-.884a.187.187 0 01-.107-.186V5.667a.204.204 0 01.124-.205l5.891-3.306a.204.204 0 01.232 0l5.892 3.305a.207.207 0 01.123.205v6.624a.191.191 0 01-.106.188c-1.934 1.089-3.87 2.176-5.805 3.262-.092.05-.202.133-.31.07-.508-.285-1.007-.582-1.513-.87a.163.163 0 00-.183-.012c-.222.13-.456.24-.7.326-.109.044-.244.057-.32.158.096.104.213.187.344.245l1.773 1.02a1.298 1.298 0 001.314.036c1.97-1.105 3.941-2.211 5.912-3.319a1.229 1.229 0 00.663-1.07V5.631a1.216 1.216 0 00-.618-1.046z"></path><path stroke-width="0.48" d="M11.221 11.254a3.236 3.236 0 01-1.735-.314 1.135 1.135 0 01-.425-.798.175.175 0 00-.18-.174 37.413 37.413 0 00-.753 0 .167.167 0 00-.183.147 1.843 1.843 0 00.597 1.456 3.175 3.175 0 001.767.663c.67.078 1.349.049 2.01-.085a2.484 2.484 0 001.332-.714c.402-.494.521-1.16.313-1.762a1.481 1.481 0 00-.975-.864c-1.016-.356-2.114-.328-3.15-.598-.18-.055-.4-.117-.48-.306a.673.673 0 01.225-.755 2.037 2.037 0 011.071-.265 3.248 3.248 0 011.494.213c.288.169.488.456.545.783a.192.192 0 00.181.186c.25.006.498.002.749.002a.18.18 0 00.195-.132 1.92 1.92 0 00-.942-1.664 4.685 4.685 0 00-2.553-.388 2.788 2.788 0 00-1.726.69 1.712 1.712 0 00-.344 1.786 1.529 1.529 0 00.966.84c1.014.363 2.124.246 3.145.569.2.067.432.17.493.39a.782.782 0 01-.214.748 2.366 2.366 0 01-1.423.346zm4.361-6.669a6909.08 6909.08 0 00-5.934-3.336 1.336 1.336 0 00-1.298 0L2.438 4.572a1.217 1.217 0 00-.638 1.06v6.692a1.226 1.226 0 00.663 1.07c.566.306 1.116.645 1.693.931a2.441 2.441 0 002.172.06 1.678 1.678 0 00.79-1.518c.003-2.208 0-4.417.001-6.625a.173.173 0 00-.164-.201 31.753 31.753 0 00-.756 0 .167.167 0 00-.182.168c-.003 2.194.002 4.39 0 6.585 0 .31-.193.588-.485.697a1.22 1.22 0 01-.984-.132l-1.572-.884a.187.187 0 01-.107-.186V5.667a.204.204 0 01.124-.205l5.891-3.306a.204.204 0 01.232 0l5.892 3.305a.207.207 0 01.123.205v6.624a.191.191 0 01-.106.188c-1.934 1.089-3.87 2.176-5.805 3.262-.092.05-.202.133-.31.07-.508-.285-1.007-.582-1.513-.87a.163.163 0 00-.183-.012c-.222.13-.456.24-.7.326-.109.044-.244.057-.32.158.096.104.213.187.344.245l1.773 1.02a1.298 1.298 0 001.314.036c1.97-1.105 3.941-2.211 5.912-3.319a1.229 1.229 0 00.663-1.07V5.631a1.216 1.216 0 00-.618-1.046z" mask="url(#javascript_svg__a)"></path></svg>
          
          <span>JavaScript</span>
        </div>
      </div>
    
      <div class="selector-1">
        <div class="selector-1-container">
           <!-- Dropdown Menu for Lists -->
            <DropdownMenu.Root>
              <DropdownMenu.Trigger class="dropdown-trigger" on:click={() => toggleDropdown('lists')}>
                Lists
                <svg class="caret-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  {#if listsExpanded}
                    <path d="M7 10l5 5 5-5H7z" />
                  {:else}
                    <path d="M7 14l5-5 5 5H7z" />
                  {/if}
                </svg>
              </DropdownMenu.Trigger>
              <DropdownMenu.Content class="dropdown-content">
                <DropdownMenu.Item class="dropdown-item">Array</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item">Linked List</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item">Graph</DropdownMenu.Item>
              </DropdownMenu.Content>
            </DropdownMenu.Root>

            <!-- Dropdown Menu for Difficulty -->
            <DropdownMenu.Root>
              <DropdownMenu.Trigger class="dropdown-trigger" on:click={() => toggleDropdown('difficulty')}>
                Difficulty
                <svg class="caret-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  {#if difficultyExpanded}
                    <path d="M7 10l5 5 5-5H7z" />
                  {:else}
                    <path d="M7 14l5-5 5 5H7z" />
                  {/if}
                </svg>
              </DropdownMenu.Trigger>
              <DropdownMenu.Content class="dropdown-content">
                <DropdownMenu.Item style="color:#2ff1de"  class="dropdown-item" >Easy</DropdownMenu.Item>
                <DropdownMenu.Item style="color:orange" class="dropdown-item">Medium</DropdownMenu.Item>
                <DropdownMenu.Item style="color: red" class="dropdown-item">Hard</DropdownMenu.Item>
              </DropdownMenu.Content>
            </DropdownMenu.Root>

            <!-- Dropdown Menu for Status -->
            <DropdownMenu.Root>
              <DropdownMenu.Trigger class="dropdown-trigger" on:click={() => toggleDropdown('status')}>
                Status
                <svg class="caret-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  {#if statusExpanded}
                    <path d="M7 10l5 5 5-5H7z" />
                  {:else}
                    <path d="M7 14l5-5 5 5H7z" />
                  {/if}
                </svg>
              </DropdownMenu.Trigger>
              <DropdownMenu.Content class="dropdown-content">
                <DropdownMenu.Item class="dropdown-item"><span class="status-icon dash">—</span> Todo</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item"><span class="status-icon check">✔</span>Solved</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item"><span class="status-icon dot">•</span>Attempt</DropdownMenu.Item>
              </DropdownMenu.Content>
            </DropdownMenu.Root>

            <!-- Dropdown Menu for Tags -->
            <DropdownMenu.Root>
              <DropdownMenu.Trigger class="dropdown-trigger" on:click={() => toggleDropdown('tags')}>
                Tags
                <svg class="caret-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                  {#if tagsExpanded}
                    <path d="M7 10l5 5 5-5H7z" />
                  {:else}
                    <path d="M7 14l5-5 5 5H7z" />
                  {/if}
                </svg>
              </DropdownMenu.Trigger>
              <DropdownMenu.Content class="dropdown-content">
                <DropdownMenu.Item class="dropdown-item">Algorithm</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item">Data Structure</DropdownMenu.Item>
                <DropdownMenu.Item class="dropdown-item">System Design</DropdownMenu.Item>
              </DropdownMenu.Content>
            </DropdownMenu.Root>
    
          <!-- Search Bar -->
          <div class="search-bar">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="icon" viewBox="0 0 16 16">
              <path fill-rule="evenodd" d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001l3.85 3.85a1 1 0 0 0 1.414-1.415l-3.85-3.849zm-5.242 1.101a5.5 5.5 0 1 1 0-11 5.5 5.5 0 0 1 0 11z"/>
            </svg>
            <input type="text" placeholder="Search questions" />
          </div>
    
          <!-- Icons -->
          <div class="nav-icons">           
            <a {href}><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="1em" height="1em" fill="currentColor" class="h-[18px] w-[18px] fill-none stroke-current text-white" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.398 18.296H5.38a3.6 3.6 0 002.93-1.508l1.023-1.433m11.522-9.71h-2.98a3.6 3.6 0 00-2.93 1.507l-1.146 1.603m5.298-5.747l2.502 2.636-2.502 2.637m0 7.438l2.502 2.636-2.502 2.637M2.398 6.052H5.38a3.6 3.6 0 012.93 1.507l6.635 9.289a3.6 3.6 0 002.93 1.507h2.98"></path></svg>
            Pick One
            </a>            
          </div>
        
        </div>
      </div>

      <div class="selector-2">
        <div class="table-container">
          <!-- Table Header -->
          <div class="table-header">
            <div class="table-column">Status</div>
            <div class="table-column title-column">Title</div>
            <div class="table-column">Solution</div>
            <div class="table-column">Acceptance</div>
            <div class="table-column">Difficulty</div>
            <div class="table-column">Frequency</div>
          </div>
  
          <!-- Table Rows -->
        {#if paginatedProblems.length > 0}
          {#each paginatedProblems as problem}
            <div class="table-row">
              <div class="table-column">
                {#if problem.status === "calendar"}
                  <svg class="icon-calendar"></svg>
                {:else if problem.status === "check"}
                  <svg class="icon-check"></svg>
                {/if}
              </div>
      
              <div class="table-column title-column">{problem.title}</div>
              <div class="table-column">{@html solutionIcons[problem.solution]}</div>
              <div class="table-column">{problem.acceptance}</div>
              <div class="table-column">
                {#if problem.difficulty === "Easy"}
                  <span class="text-easy">{problem.difficulty}</span>
                {:else if problem.difficulty === "Medium"}
                  <span class="text-medium">{problem.difficulty}</span>
                {:else}
                  <span class="text-hard">{problem.difficulty}</span>
                {/if}
              </div>
      
              <div class="table-column">
                <svg class="icon-lock"></svg>
              </div>
            </div>
          {/each}
        {:else}
          <div>No data available</div>
        {/if}
      
  
          <!-- Pagination Component -->
        <nav class="pagination-container" use:melt={$root}>
          <div class="per-page">
            50 / page
          </div>
          <div class="pagination-controls">
            <button use:melt={$prevButton}>
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <polyline points="15 18 9 12 15 6"></polyline>
            </button>
            {#each $pages as page (page.key)}
              {#if page.type === 'ellipsis'}
                <span>...</span>
              {:else}
                <button use:melt={$pageTrigger(page)}>{page.value}</button>
              {/if}
            {/each}
            <button use:melt={$nextButton}>
                <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="14" height="24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <polyline points="9 18 15 12 9 6"></polyline>
            </button>
          </div>
        </nav>
      </div>
    </div>

      

    </div>

    <div class="body-right">
      <!-- Calendar placed inside body-right -->
      <RangeCalendar.Root let:months let:weekdays class='range-calendar-root'>
        <RangeCalendar.Header class="range-calendar-header">

          <RangeCalendar.PrevButton class="range-calendar-prev-button">
            <!-- Left Arrow SVG -->
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" class="w-6 h-6">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
            </svg>
          </RangeCalendar.PrevButton>

          <RangeCalendar.Heading class="range-calendar-heading" />
    
          <RangeCalendar.NextButton class="range-calendar-next-button">
            <!-- Right Arrow SVG -->
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor" class="w-6 h-6">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
            </svg>
          </RangeCalendar.NextButton>


        </RangeCalendar.Header>

        {#each months as month}
          <RangeCalendar.Grid class="range-calendar-grid">
            <RangeCalendar.GridHead class="range-calendar-grid-head">
              <RangeCalendar.GridRow class="range-calendar-grid-row">
                {#each weekdays as day}
                  <RangeCalendar.HeadCell class="range-calendar-head-cell">
                    {day}
                  </RangeCalendar.HeadCell>
                {/each}
              </RangeCalendar.GridRow>
            </RangeCalendar.GridHead>

            <RangeCalendar.GridBody>
              {#each month.weeks as weekDates}
                <RangeCalendar.GridRow class="range-calendar-grid-row">
                  {#each weekDates as date}
                    <RangeCalendar.Cell {date} class="range-calendar-cell">
                      <RangeCalendar.Day {date} month={month.value} class="range-calendar-day" />
                    </RangeCalendar.Cell>
                  {/each}
                </RangeCalendar.GridRow>
              {/each}
            </RangeCalendar.GridBody>
          </RangeCalendar.Grid>
        {/each}
      </RangeCalendar.Root>

    <div class="session-container">
      <div class="session-header">
        <span>Session</span>
        <span>Anonymous</span>
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" class="settings-icon">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4m0 4h.01M4.5 4.5l3.9 3.9M12 3v1m8.5 2.5l-3.9 3.9M3 12h1m16-1h1m-7 7v1m3.9-2.9l-3.9 3.9"></path>
        </svg>
      </div>
      <div class="session-body">
        <div class="session-all">
          <div class="session-circle">
            <div class="total-count ">0</div>
            <div>All</div>
            <div class="total-attempts">3308</div>
          </div>
        </div>
        <div class="session-difficulty">
          <div class="difficulty-level">
            <span class="text-easy">Easy</span>
            <span class="count">0/828</span>
          </div>
          <div class="difficulty-level">
            <span class="text-medium">Medium</span>
            <span class="count">0/1731</span>
          </div>
          <div class="difficulty-level">
            <span class="text-hard">Hard</span>
            <span class="count">0/749</span>
          </div>
        </div>
      </div>
  </div>
      
    <!-- Body right -->
    </div> 

  </div>



  <Footer />
</main>
