import {useToDos} from '../hooks/useToDos'
import ToDoItem from './ToDoItem'

export default function ToDoList () {

    const {
        todos,
        isLoading,
        isError,
        error
    } = useToDos();

    if (isLoading) {
        return (
            <div>
                Loadng todos...
            </div>
        )
    } 
    
    if (isError) {
        return (
            <div className='error'>
                Error occured: {error.message}
            </div>
        )
    }



    return (
        <ul className='todo-list'>
            {todos?.map((todo) => (
                <ToDoItem key={todo.guid} todo={todo}></ToDoItem>
            ))}
        </ul>
    )
}