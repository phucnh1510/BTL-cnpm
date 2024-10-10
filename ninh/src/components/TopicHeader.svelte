<script>

</script>


<main class="topic-header">
    <div class="topic-header">
        <div class="topic-header-item topic-active">
            <svg class="topic-icon topic-description-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <!-- Replace this with your Description SVG -->
            <path fill="currentColor" d="M64 48c-8.8 0-16 7.2-16 16V448c0 8.8 7.2 16 16 16H320c8.8 0 16-7.2 16-16V64c0-8.8-7.2-16-16-16H64zM0 64C0 28.7 28.7 0 64 0H320c35.3 0 64 28.7 64 64V448c0 35.3-28.7 64-64 64H64c-35.3 0-64-28.7-64-64V64zm120 64H264c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24zm0 96H264c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24zm0 96h48c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
            </svg> Description
        </div>
        <div class="topic-header-item">
            <svg class="topic-icon topic-editorial-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <!-- Replace this with your Editorial SVG -->
            <path d="M..." />
            </svg> Editorial
        </div>
        <div class="topic-header-item">
            <svg class="topic-icon topic-solutions-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <!-- Replace this with your Solutions SVG -->
            <path d="M..." />
            </svg> Solutions
        </div>
        <div class="topic-header-item">
            <svg class="topic-icon topic-submissions-icon" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <!-- Replace this with your Submissions SVG -->
            <path d="M..." />
            </svg> Submissions
        </div>
    </div>
</main>

<style>
.topic-header {
  display: flex;
  background-color: #1e1e1e; /* Dark background */
  padding: 10px;
  border-bottom: 1px solid #333;
}

.topic-header-item {
  margin-right: 20px;
  color: #9fa5b2; /* Inactive color */
  font-family: Arial, sans-serif; /* Replace with desired font */
  display: flex;
  align-items: center;
  cursor: pointer;
}

.topic-header-item svg {
  width: 16px;
  height: 16px;
  fill: #9fa5b2; /* Inactive icon color */
  margin-right: 5px;
}

.topic-header-item.topic-active svg {
  fill: #60a5fa; /* Active icon color */
}

.topic-header-item.topic-active {
  color: #60a5fa; /* Active text color */
  font-weight: bold;
}

.topic-header-item:hover {
  color: #f0c674; /* Hover text color */
}

.topic-header-item:hover svg {
  fill: #f0c674; /* Hover icon color */
}

</style>