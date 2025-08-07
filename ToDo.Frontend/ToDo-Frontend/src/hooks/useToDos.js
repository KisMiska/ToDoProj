import {useQuery, useMutation, useQueryClient, QueryClient} from '@tanstack/react-query'
import {getAllToDos, addToDo, deleteToDo, updateToDo, getToById} from '../api/todoApi'

export const useToDos = (id) => {
    
    const client = useQueryClient();
    
    const {
        data: todos,
        isLoading,
        isError,
        error
    } = useQuery({
        queryKey: [`todos`],
        queryFn: getAllToDos
    });

    const {
        data: todo,
        isLoading: isLoadingToDo,
        isError: isErrorToDo,
        error: todoError
    } = useQuery({
        queryKey: ['todo', id],
        queryFn: () => getToById(id),
        enabled: !!id
    });

    const {mutate: addToDoMutate, isPending: isAdding} = useMutation({
        mutationFn: addToDo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: [`todos`]
            });
        }
    });

    const {mutate: updateToDoMutate, isPending: isUpdating} = useMutation({
        mutationFn: updateToDo,
        onSuccess: (data, variables) => {
            client.invalidateQueries({
                queryKey: [`todos`]
            });
            client.invalidateQueries({
                queryKey : ['todos', variables.id]
            })
        }
    }); 

    const {mutate: deleteToDoMutate, isPending: isDeleting} = useMutation({
        mutationFn: deleteToDo,
        onSuccess: () => {
            client.invalidateQueries({
                queryKey: [`todos`]
            });
        }
    });



    return {todos, isLoading, isError, error, addToDoMutate, isAdding, updateToDoMutate, isUpdating, deleteToDoMutate, isDeleting, todo, isLoadingToDo, isErrorToDo, todoError}

}