<template>
  <v-container style="margin-top:10px">
    <v-btn>
        upload
    </v-btn>
    <v-file-input></v-file-input>
  </v-container>
</template>

<script setup>
//
import HttpClient from '@/modules/HttpClient';
import Toast from '@/modules/Toast';
import state from '@/modules/state';

</script>

<script>
export default {
  mounted() {
    Toast.Error("")
  },
  data() {
    return {

    }
  },
  methods: {

  },
  getSets() {
    HttpClient.Get("set/user/" + state.User.id, (response) => {
      if (!response.isSuccess) {
        Toast.Error(response.message)
        return
      }
      this.sets = response.data
      this.originalSets = [...response.data]
      console.log("sets", response)
    })
  },
  checkboxChanged() {

  }
}

</script>