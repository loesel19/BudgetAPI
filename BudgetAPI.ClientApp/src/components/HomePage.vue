<template>
    <v-container class="fill-height">
      <v-responsive class="align-center text-center fill-height">
        <v-img height="300" src="@/assets/logo.svg" />
  
        <div class="text-body-2 font-weight-light mb-n1">Welcome {{ state.User?.username }}!</div>
  
        <h1 class="text-h2 font-weight-bold">Spending Tracker</h1>
  
        <div class="text-body-2 font-weight-light mb-n1">Built with Vuetify 3</div>
  
        <div class="py-14" />
  
        <v-row class="d-flex align-center justify-center">
          <v-col cols="auto">
            <v-tooltip text="Enter bank statements/spending items" location="start">
              <template v-slot:activator="{ props }">
                <v-btn v-bind="props" min-width="164" rel="noopener noreferrer" target="_blank" variant="text"
                  v-on:click="goEntry">
                  <v-icon icon="mdi-view-dashboard" size="large" start />
  
                  Entry Form
                </v-btn>
              </template>
            </v-tooltip>
          </v-col>
  
          <v-col cols="auto">
            <v-tooltip text="View your progress with graphs">
              <template v-slot:activator="{ props }">
                <v-btn v-bind="props" min-width="164" rel="noopener noreferrer" target="_blank" variant="text"
                  tooltip="tototo" v-on:click="goAnalysis">
                  <v-icon icon="mdi-account-group" size="large" start />
  
                  Analytics
                </v-btn>
              </template>
            </v-tooltip>
          </v-col>
        </v-row>
      </v-responsive>
    </v-container>
  </template>
  
  <script setup>
  import router from '@/router';
  import state from '@/modules/state';
  //
  
  </script>
  <script>
  export default {
    methods:{
      goEntry(){
        router.push('/entry')
      },
      goAnalysis(){
        router.push('/analysis')
      }
    }
  }
  </script>
  