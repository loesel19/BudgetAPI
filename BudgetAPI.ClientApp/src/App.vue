<template>
  <v-app>
    <v-main>
      <router-view />
      <div id="snackbar">
        <v-btn elevation="0" v-on:click="closeToast()" size="x-small" id="toast-close">X</v-btn>
        <div id="toast-content"></div>
      </div>
    </v-main>
  </v-app>
</template>

<script setup>
  //
  function closeToast(){
    console.log("here")
    var x = document.getElementById("snackbar")
    x.className = x.className.replace("show", "")
  }
</script>

<style>
#toast-close{
  left: 49%;
  bottom: 18px
}

#snackbar {
  visibility: hidden;
  /* Hidden by default. Visible on click */
  min-width: 250px;
  /* Set a default minimum width */
  margin-left: -125px;
  /* Divide value of min-width by 2 */
  background-color: #333;
  /* Black background color */
  color: #fff;
  /* White text color */
  text-align: center;
  /* Centered text */
  border-radius: 2px;
  /* Rounded borders */
  padding: 16px;
  /* Padding */
  position: fixed;
  /* Sit on top of the screen */
  z-index: 1;
  /* Add a z-index if needed */
  left: 50%;
  /* Center the snackbar */
  bottom: 30px;
  /* 30px from the bottom */
}

/* Show the snackbar when clicking on a button (class added with JavaScript) */
#snackbar.show {
  visibility: visible;
  /* Show the snackbar */
  /* Add animation: Take 0.5 seconds to fade in and out the snackbar.
  However, delay the fade out process for 2.5 seconds */
  -webkit-animation: fadein 0.5s, fadeout .5s 10s;
  animation: fadein 0.5s, fadeout .5s 10s;
}

/* Animations to fade the snackbar in and out */
@-webkit-keyframes fadein {
  from {
    bottom: 0;
    opacity: 0;
  }

  to {
    bottom: 30px;
    opacity: 1;
  }
}

@keyframes fadein {
  from {
    bottom: 0;
    opacity: 0;
  }

  to {
    bottom: 30px;
    opacity: 1;
  }
}

@-webkit-keyframes fadeout {
  from {
    bottom: 30px;
    opacity: 1;
  }

  to {
    bottom: 0;
    opacity: 0;
  }
}

@keyframes fadeout {
  from {
    bottom: 30px;
    opacity: 1;
  }

  to {
    bottom: 0;
    opacity: 0;
  }
}
</style>