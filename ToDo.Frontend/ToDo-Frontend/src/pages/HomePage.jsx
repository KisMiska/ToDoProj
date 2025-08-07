import AddToDoForm from "../components/AddToDoForm";
import ToDoList from "../components/ToDoList";
import { useUIStore } from "../store/useUIStore";

export default function HomePage () {

    const {isAddToDoFromVisible, toggleToDoForm} = useUIStore();

    return (
        <div className="container">
            <header>
                <h1>
                    ToDoApp
                    <button onClick={toggleToDoForm}>
                        { isAddToDoFromVisible ? 'Cancel' : 'Add' }
                    </button>
                </h1>
            </header>
            {isAddToDoFromVisible && <AddToDoForm />}
            <main>    
                <ToDoList></ToDoList>
            </main>
        </div>
    )

} 