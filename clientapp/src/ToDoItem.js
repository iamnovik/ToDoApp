import React, { useState } from 'react';
import './ToDoList.css'
const ToDoItem = ({ todo, updateTodo, deleteTodo }) => {
  const [status, setStatus] = useState(todo.itemStatus);

  const handleStatusChange = async (e) => {
    const updatedStatus = parseInt(e.target.value, 10);
    setStatus(updatedStatus);

    const updatedTodo = { ...todo, itemStatus: updatedStatus };

    await updateTodo(updatedTodo);
  };

  return (
    <li key={todo.id} className="todo-item">
      <div className="todo-item-container">
        <div>Task: {todo.text}</div>
        <div>Created at: {todo.createdAt}</div>
        <div>
          <select value={status} onChange={handleStatusChange}>
            <option value={0}>Active</option>
            <option value={1}>Completed</option>
          </select>
        </div>
        <button onClick={() => deleteTodo(todo.id)}>Delete</button>
      </div>
      
    </li>
  );
};

export default ToDoItem;