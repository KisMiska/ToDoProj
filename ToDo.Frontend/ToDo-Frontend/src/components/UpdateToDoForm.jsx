import { useState } from "react";
import { useToDos } from "../hooks/useToDos";
import { useUIStore } from "../store/useUIStore";
import { useNavigate} from 'react-router-dom';

export default function UpdateToDoForm({ todo }) {
    const {
        updateToDoMutate,
        isUpdating
    } = useToDos(todo.guid);

    const [title,setTitle] = useState(todo.title);
    const [description,setDescription] = useState("");
    const [deadline, setDeadline] = useState("");
    const [importance, setImportance] = useState(todo.importance);

    const navigate = useNavigate();
    const handleSubmit = (e) => {
        e.preventDefault();

        updateToDoMutate(
            {
                id: todo.guid,
                title,
                description,
                deadline,
                importance
            },
            {
                onSuccess: () => {
                    navigate("/")
                }
            }
        );
    };

    return (
        <form className="add-form" onSubmit={handleSubmit}>
            <h3>Update To-Do</h3>

            <label htmlFor="title">Title</label>
            <input
                type="text"
                name="title"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                disabled={isUpdating}
            />

            <label htmlFor="description">Description</label>
            <input
                type="text"
                name="description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                disabled={isUpdating}
            />

            <label htmlFor="deadline">Deadline</label>
            <input
                type="date"
                name="deadline"
                value={deadline}
                onChange={(e) => setDeadline(e.target.value)}
                disabled={isUpdating}
            />

            <label htmlFor="importance">Importance</label>
            <select
                name="importance"
                value={importance}
                onChange={(e) => setImportance(e.target.value)}
                disabled={isUpdating}
            >
                <option value="0">Not Important</option>
                <option value="1">Slightly Important</option>
                <option value="2">Important</option>
                <option value="3">Urgent</option>
            </select>

            <button type="submit" disabled={isUpdating}>
                {isUpdating ? "Saving..." : "Update"}
            </button>
        </form>
    );
}
