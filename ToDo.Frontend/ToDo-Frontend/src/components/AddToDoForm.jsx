import { useState } from "react";
import { useToDos } from "../hooks/useToDos"
import { useUIStore } from "../store/useUIStore";

export default function AddTodoForm(){

    const {addToDoMutate,isAdding} = useToDos();

    const [title,setTitle] = useState("");
    const [description,setDescription] = useState("");
    const [deadline, setDeadline] = useState("");
    const [importance, setImportance] = useState(0);
    const {toggleToDoForm} = useUIStore();


    const handleSubmit = (e) =>{
        e.preventDefault();

        addToDoMutate({title,description,deadline,importance},{onSuccess:() =>{setTitle("");setDescription(""),setDeadline(""),setImportance(0), toggleToDoForm()}});
    }

    return(
        <form className="add-form" onSubmit={handleSubmit}>
            <h3>New todo</h3>
            <label htmlFor="title">Title</label>
            <input type="text" name="title" value={title} onChange={(e) => {setTitle(e.target.value)}} placeholder="Title" disabled={isAdding}/>
            <label htmlFor="description">Description</label>
            <input type="text" value={description} onChange={(e) => {setDescription(e.target.value)}} placeholder="Description" disabled={isAdding}/>
            <label htmlFor="deadline">Deadline</label>
            <input type="date" name="deadline" value={deadline} onChange={(e) => {setDeadline(e.target.value)}} disabled={isAdding} />
            <label htmlFor="importance">Importance</label>
            <select name="importance" id="importance" onChange={(e) => setImportance(e.target.value)} disabled={isAdding}>
                <option value="0">Not Important</option>
                <option value="1">Slightly Important</option>
                <option value="2">Important</option>
                <option value="3">Urgent</option>
            </select>
            <button type="submit" disabled={isAdding}>{isAdding?"Saving":"Add"}</button>
        </form>

    )


}