<script>
  import { Router, Route, Link } from 'svelte-routing';
  
  import Home from './pages/home.svelte';
  import Login from './pages/login.svelte';
  import Profile from './pages/profile.svelte';
  import Assignment from './assignments/assignment.svelte';


</script>

<main>
  <!-- Cấu hình Router -->
  <Router>
    <Route component={Home} />

    <Route path="/home" component={Home} />
    <Route path="/login" component={Login} />
    <Route path="/profile" component={Profile} />
    <Route path="/assignment" component={Assignment} />
  </Router>


</main>