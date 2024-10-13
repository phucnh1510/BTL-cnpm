<script>

</script>


<!-- topic-icon topic-description-icon -->

<main class="topic-header-main">
    <div class="topic-header">
        <div class="topic-header-item topic-active">
            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="memo" class="topic-icon topic-description-icon" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 384 512"><path fill="currentColor" d="M64 48c-8.8 0-16 7.2-16 16V448c0 8.8 7.2 16 16 16H320c8.8 0 16-7.2 16-16V64c0-8.8-7.2-16-16-16H64zM0 64C0 28.7 28.7 0 64 0H320c35.3 0 64 28.7 64 64V448c0 35.3-28.7 64-64 64H64c-35.3 0-64-28.7-64-64V64zm120 64H264c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24zm0 96H264c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24zm0 96h48c13.3 0 24 10.7 24 24s-10.7 24-24 24H120c-13.3 0-24-10.7-24-24s10.7-24 24-24z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
            </svg>
            <p> Description </p>
        </div>
        
        <div class="topic-header-item">
            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="flask" class="topic-icon topic-description-icon" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512"><path fill="currentColor" d="M176 196.8c0 20.7-5.8 41-16.6 58.7L119.7 320H328.3l-39.7-64.5c-10.9-17.7-16.6-38-16.6-58.7V48H176V196.8zM320 48V196.8c0 11.8 3.3 23.5 9.5 33.5L437.7 406.2c6.7 10.9 10.3 23.5 10.3 36.4c0 38.3-31.1 69.4-69.4 69.4H69.4C31.1 512 0 480.9 0 442.6c0-12.8 3.6-25.4 10.3-36.4L118.5 230.4c6.2-10.1 9.5-21.7 9.5-33.5V48h-8c-13.3 0-24-10.7-24-24s10.7-24 24-24h40H288h40c13.3 0 24 10.7 24 24s-10.7 24-24 24h-8z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
            </svg> Results
        </div>
        <div class="topic-header-item">
            <svg aria-hidden="true" focusable="false" data-prefix="far" data-icon="clock-rotate-left" class="topic-icon topic-description-icon" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512"><path fill="currentColor" d="M48 106.7V56c0-13.3-10.7-24-24-24S0 42.7 0 56V168c0 13.3 10.7 24 24 24H136c13.3 0 24-10.7 24-24s-10.7-24-24-24H80.7c37-57.8 101.7-96 175.3-96c114.9 0 208 93.1 208 208s-93.1 208-208 208c-42.5 0-81.9-12.7-114.7-34.5c-11-7.3-25.9-4.3-33.3 6.7s-4.3 25.9 6.7 33.3C155.2 496.4 203.8 512 256 512c141.4 0 256-114.6 256-256S397.4 0 256 0C170.3 0 94.4 42.1 48 106.7zM256 128c-13.3 0-24 10.7-24 24V256c0 6.4 2.5 12.5 7 17l72 72c9.4 9.4 24.6 9.4 33.9 0s9.4-24.6 0-33.9l-65-65V152c0-13.3-10.7-24-24-24z" data-darkreader-inline-fill="" style="--darkreader-inline-fill: currentColor;"></path>
            </svg>
             Submissions
        </div>
    </div>
</main>

<style>
.topic-header {
  display: flex;
  background-color: #1e1e1e; /* Dark background */
  padding-bottom: 10px;
  border-radius: 12px 12px 0 0;
  align-items: center;
  
}

.topic-header-item {
  margin-right: 20px;
  color: #9fa5b2; /* Inactive color */
  font-family: Arial, sans-serif; /* Replace with desired font */
  display: flex;
  align-items: center;
  cursor: pointer;
  margin-top: 12px;
  margin-left: 12px;
}

.topic-header-item svg {
  width: 13px;
  height: 13px;
  fill: #9fa5b2; /* Inactive icon color */
  margin-right: 5px;
}

.topic-header-item{
  font-size: 13px;
}

.topic-header-item.topic-active svg {
  fill: #60a5fa; /* Active icon color */
}

.topic-header-item.topic-active {
  color: #60a5fa; /* Active text color */
  font-weight: bold;
}

.topic-header-item.topic-active p {
  color: white; /* Active text color */
  font-weight: 700;
}

.topic-header-item:hover {
  color: #f0c674; /* Hover text color */
}

.topic-header-item.topic-active:hover {
  color: #60a5fa; /* Active text color */
}

.topic-header-item:hover svg {
  fill: #f0c674; /* Hover icon color */
}

</style>