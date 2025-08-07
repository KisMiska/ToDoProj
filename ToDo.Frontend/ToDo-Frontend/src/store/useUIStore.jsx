import { create } from 'zustand'

export const useUIStore = create((set) => ({
    isAddToDoFromVisible: false,
    toggleToDoForm: () => set((state) => ({
        isAddToDoFromVisible: !state.isAddToDoFromVisible
    }))
}))