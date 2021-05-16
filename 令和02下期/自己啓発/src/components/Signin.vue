<template>
  <div id="signin">
    <button class="btn" @click="signInWithGoogle">Googleアカウントでサインイン</button>
  </div>
</template>

<script>
import firebase from "firebase";
 
export default {
  name: "Signin",
  data() {
    return {
      email: "",
      password: ""
    };
  },
  methods: {
    signInWithGoogle: function() {
      const provider = new firebase.auth.GoogleAuthProvider();
      firebase
        .auth()
        .signInWithPopup(provider)
        .then(() => {
          this.$router.push("/");
        }).catch(
          error => {
            alert(error.message)
          }
        );
    }
  }
};
</script>

<style>
.btn {
  display: inline-block;
  padding: 16px 32px;
  background: #00aeff;
  border-radius: 8px;
  color: #ffffff;
  text-decoration: none;
  font-size: 14px;
  font-weight: bold;
  -webkit-transition: .100s;
  transition: .100s;
}
.btn:hover {
  border-bottom: none;
  -webkit-transform: translateY(4px);
  transform: translateY(4px);
}

</style>