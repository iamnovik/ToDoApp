import React, { useEffect, useState } from 'react';
import TodoItem from './ToDoItem.js';
import axios from 'axios';
import './ToDoList.css'
const TodoList = () => {
  const [todos, setTodos] = useState([]);
  const [newTodoText, setNewTodoText] = useState('');
  const [statusFilter, setStatusFilter] = useState('all');
  useEffect(() => {
    const fetchTodos = async () => {
      const response = await axios.get('http://localhost:5118/api/todo');
      setTodos(response.data);
    };
    fetchTodos();
  }, []);

  const updateTodo = async (updatedTodo) => {
    try {
        console.log(updatedTodo)
      await axios.put(`http://localhost:5118/api/todo`, updatedTodo); 
      setTodos(todos.map((todo) => (todo.id === updatedTodo.id ? updatedTodo : todo)));
    } catch (error) {
      console.error('Ошибка при обновлении задачи:', error);
    }
  };

  const deleteTodo = async (id) => {
    try {
      await axios.delete(`http://localhost:5118/api/todo/${id}`);
      setTodos(todos.filter((todo) => todo.id !== id));
    } catch (error) {
      console.error('Ошибка при удалении задачи:', error);
    }
  };
  const addTodo = async (e) => {
    e.preventDefault();

    if (!newTodoText.trim()) {
      return;
    }

    const newTodo = {
      text: newTodoText,
    };

    try {
      const response = await axios.post('http://localhost:5118/api/todo', newTodo); 
      setTodos([...todos, response.data]); 
      setNewTodoText(''); 
    } catch (error) {
      console.error('Error:', error);
    }
  };
  const filteredTodos = todos.filter((todo) => {
    if (statusFilter === 'all') return true; 
    return todo.itemStatus === parseInt(statusFilter, 10); 
  });
  return (
    <div  className="todo-item-container">
    <h1>Todo List</h1>
    <label htmlFor="statusFilter">Filter by Status: </label>
      <select
        id="statusFilter"
        value={statusFilter}
        onChange={(e) => setStatusFilter(e.target.value)}
      >
        <option value="all">All</option>
        <option value="0">Active</option>
        <option value="1">Completed</option>
      </select>
    <form onSubmit={addTodo}>
      <input
        type="text"
        placeholder="Set a name"
        value={newTodoText}
        onChange={(e) => setNewTodoText(e.target.value)}
      />
      <button type="submit">Create a task</button>
    </form>

    <ul>
      {filteredTodos.map((todo) => (
        <TodoItem key={todo.id} todo={todo} updateTodo={updateTodo} deleteTodo={deleteTodo} />
      ))}
    </ul>
  </div>
  );
};

export default TodoList;
