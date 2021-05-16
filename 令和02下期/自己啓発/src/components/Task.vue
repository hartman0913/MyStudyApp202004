<template>
  <div class="task">
     <h2>タスク</h2>
    <div>
      <input type="text" maxlength="100" v-model="newTodoName">
      <button style="margin-left:5px" class="btn-createtodo" type="submit" v-on:click="createTodo()">タスク作成</button>
    </div>
    <div id="todolist">
      <!-- todoの一覧表示 -->
      <ul class="list" v-for="(todo, key) in this.todos" :key="todo.id">
        <li>
          <div style="display:flex">
          <div style="margin: 0px 10px 0px 0px; min-width: 125px;">
              <button class="btn-left btn-delete" type="submit" v-on:click="deleteTodo(key)">削除</button>
              <button class="btn-right btn-notify" type="submit" v-on:click="notificationTodo(todo.name)">通知</button>
          </div>
          <div class="todo-text">{{ todo.name }}</div>
          
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import firebase from "firebase";
import axios from "axios";

export default {
  name: "Task",
  data() {
    return {
      database: null,
      todosRef: null,
      newTodoName: "",
      showTodoType: "all",
      todos: [],
      hookurl: "ディスコードのurl",
    };
  },
  created: function() {
    this.database = firebase.database();
    this.uid = firebase.auth().currentUser.uid;
    this.todosRef = this.database.ref("todos/" + this.uid);

    // データに変更があると実行されるfunction
    this.todosRef.on("value", (snapshot) => {
      this.todos = snapshot.val(); 
    });
  },
  methods: {
    notificationTodo(name) {
        const data = {
          content: name
        };
        axios.post(this.hookurl, data).then(() => {
         this.message = "";
        });
    },
    createTodo() {
      if (this.newTodoName == "") {
        return;
      }
      this.todosRef.push({
        name: this.newTodoName,
        isComplete: false
      });
      this.newTodoName = "";
    },
    deleteTodo(key) {
      this.todosRef.child(key).remove();
    }
  }
};
</script>

<style>
#todolist ul {
  padding: 0;
  color: #404040;
  border-left: solid 6px #1fa67a;
  border-bottom: solid 2px #dadada;
  background: whitesmoke;
  margin-bottom: 5px;
  line-height: 1.5;
  padding: 0.5em;
  list-style-type: none!important;
  font-weight: bold;
}
.btn-right 
{
  background: rgb(255, 255, 255);
  position: relative;
  display: inline-block;
  font-weight: bold;
  padding: 0.25em 0.5em;
  text-decoration: none;
  color: #006816;
  background: #00ff00;
  border-radius: 0 15px 15px 0;
  transition: .4s;
  font-size: 18px;
  border-color:#006816;
  border-right: solid 2px#006816;
}
.btn-left
{
  background: rgb(255, 255, 255);
  position: relative;
  display: inline-block;
  font-weight: bold;
  padding: 0.25em 0.5em;
  text-decoration: none;
  color: #00BCD4;
  background: #ECECEC;
  border-radius: 15px 0px 0px 15px;
  transition: .4s;
  font-size: 18px;
  margin-right: 5px;
}
.btn-left:hover {
  background: #6d6d6d;
}
.btn-right:hover {
  background: #6d6d6d;
}
.todo-text {
  word-break: break-word;
  text-align: left;
}
.btn-createtodo {
  position: relative;
  display: inline-block;
  font-weight: bold;
  padding: 7px 0 3px;
  color: #000000;
  transition: .4s;
  border:none;
}

.btn-createtodo:before {
  position: absolute;
  content: '';
  width: 100%;
  height: 4px;
  top:100%;
  left: 0;
  border-radius: 3px;
  background:#67c5ff;
  transition: .2s;
}

.btn-createtodo:after {
  position: absolute;
  content: '';
  width: 100%;
  height: 4px;
  top:0;
  left: 0;
  border-radius: 3px;
  background:#67c5ff;
  transition: .2s;
}

.btn-createtodo:hover:before {
  top: -webkit-calc(100% - 3px);
  top: calc(100% - 3px);
}

.btn-createtodo:hover:after {
  top: 3px;
}
</style>