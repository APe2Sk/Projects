import React from "react";
import "./ToDoList.scss";
import DeleteIcon from '@mui/icons-material/Delete';

export const ToDoList = (props) => {
    const todos = props.listOfToDo;
    const {handleRemoveTodo} = props;

    return (    
        <div className="results">
        {!!todos.length && <h2>Tasks:</h2>}
            <div>
                {todos.map((todo) => (
                    <div key={todo} className="results__todo">
                        <h4 className="results__todo__name">{todo}</h4>
                        <div className="results__todo__delete" onClick={() => handleRemoveTodo(todo)} >
                            <DeleteIcon />
                        </div>                        
                    </div>
                ))}
            </div>
        </div>

    );
};