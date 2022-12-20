import React, { useState } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import "./ToDo.scss";
import { ToDoList } from '../ToDoList/ToDoList';

export const ToDo = () => {
    const [toDoName, setToDo] = useState("");
    const [listOfToDo, setListOfToDo] = useState([]);

    const handleSetToDo = (event) => {
        const name = event.target.value;

        setToDo(name);
    };

    const handleAddingToDo = () => {
        setListOfToDo([...listOfToDo, toDoName]);
        setToDo("");
    };

    const handleRemoveTodo = (todoNameToRemove) => {
        const remainingTodos = listOfToDo.filter(
          (todo) => todo !== todoNameToRemove
        );
    
        setListOfToDo(remainingTodos);
      };

    return (
        <div className="todos">
            <TextField id="outlined-basic" label="Your new to do" variant="outlined" className="todos__input" value={toDoName  || ""} onChange={handleSetToDo} />
            <Button variant="contained" className="todos__add" onClick={handleAddingToDo}>Add</Button>

            <ToDoList 
                listOfToDo = {listOfToDo}   
                handleRemoveTodo = {handleRemoveTodo}
            />

        </div>
    );
};