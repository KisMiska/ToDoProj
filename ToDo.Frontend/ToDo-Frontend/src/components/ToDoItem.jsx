import { useToDos } from "../hooks/useToDos";
import { useNavigate} from 'react-router-dom';

export default function ToDoItem ({todo}) {

    const {deleteToDoMutate, isDeleting} = useToDos();
    const navigate = useNavigate();

    const handleUpdate = () => {
        // console.log({todo})
        navigate(`todos/${todo.guid}`)
    }

    return (
        <li className="todo-item">
            <div>
                <h4>
                    {todo.name}
                </h4>
                <p>
                    {todo.description || "NONE"}
                </p>
                <small>
                    status: {todo.status}
                </small>
            </div>
            <button onClick={()=>{deleteToDoMutate(todo.guid)}} disabled={isDeleting}>Delete</button>
            <button onClick={handleUpdate}>View</button>
        </li>
    )
}