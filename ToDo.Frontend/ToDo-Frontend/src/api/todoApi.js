import axios from 'axios'

const API_URL = "http://localhost:7190/api";

const apiCLient = axios.create({
    baseURL : API_URL,
    headers : {
        "Content-Type": "application/json"
    }
});

export const getAllToDos = async () => {
    const res = await apiCLient.get("/todos");
    return res.data;
}

export const getToById = async (id) => {
    const res = await apiCLient.get(`/todos/${id}`);
    return res.data;
}

export const deleteToDo = async (id) => {
    const res = await apiCLient.delete(`/todos/${id}`);
    return res.data;
}

export const addToDo = async (item) => {
    const res = await apiCLient.post(`/todos`, item);
    return res.data;
}

export const updateToDo = async ({id, ...item}) => {
    const res = await apiCLient.patch(`/todos/${id}`,item);
    return res.data;
}
