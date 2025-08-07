import { useParams } from "react-router-dom";
import { useToDos } from "../hooks/useToDos";
import UpdateToDoForm from "../components/UpdateToDoForm";


export default function ToDoPage() {
    const { id } = useParams();
    // console.log(`aaaaaa : ${id}`)
    const { todo, isLoadingToDo, todoError } = useToDos(id);

    if (isLoadingToDo) return <p>Loading ToDo...</p>;
    if (todoError) return <p>Error: {todoError.message}</p>;

    return (
        <div>
            <h2>{todo.name}</h2>
            <p>{todo.description}</p>
            <p>{todo.dealine}</p>
            <small>Status: {todo.status}</small>

            <UpdateToDoForm todo={todo} />
        </div>
    );
}
